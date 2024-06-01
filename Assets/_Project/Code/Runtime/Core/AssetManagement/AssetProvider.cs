using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Project.Code.Runtime.Core.AssetManagement
{
    public sealed class AssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _assetRequests = new ();

        public async UniTask InitializeAsync()
        {
            await Addressables.InitializeAsync().ToUniTask();
        }

        public async UniTask<T> Load<T>(AssetReference assetReference) where T : class
        {
            return await Load<T>(assetReference.AssetGUID);
        }

        public async UniTask<T> Load<T>(string key) where T : class
        {
            if (!_assetRequests.TryGetValue(key, out var handle))
            {
                handle = Addressables.LoadAssetAsync<T>(key);
                _assetRequests.Add(key, handle);
            }
            
            await handle.ToUniTask();
            return handle.Result as T;
        }

        public async UniTask<T[]> LoadAll<T>(List<string> keys) where T : class
        {
            List<UniTask<T>>  tasks = new List<UniTask<T>>(keys.Count);

            foreach (var key in keys) 
                tasks.Add(Load<T>(key));

            return await UniTask.WhenAll(tasks);
        }
        
        public async UniTask<List<string>> GetAssetsListByLabel(string label, Type type = null)
        {
            var operationHandle = Addressables.LoadResourceLocationsAsync(label, type);
            var locations = await operationHandle.ToUniTask();

            var assetKeys = new List<string>(locations.Count);
        
            foreach (var location in locations) 
                assetKeys.Add(location.PrimaryKey);
            
            Addressables.Release(operationHandle);
            return assetKeys;
        }

        public async UniTask<T> Warmup<T>(string path) where T : class
        {
            return await Load<T>(path);
        }
        
        public async UniTask WarmupAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);
        }
        
        public async UniTask ReleaseAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);
            
            foreach (var assetKey in assetsList)
                if (_assetRequests.TryGetValue(assetKey, out var handler))
                {
                    Addressables.Release(handler);
                    _assetRequests.Remove(assetKey);
                }
        }
        
        public void Cleanup()
        {
            foreach (var assetRequest in _assetRequests) 
                Addressables.Release(assetRequest.Value);
            
            _assetRequests.Clear();
        }
    }
}