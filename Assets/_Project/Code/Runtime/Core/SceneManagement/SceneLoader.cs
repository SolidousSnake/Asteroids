using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace _Project.Code.Runtime.Core.SceneManagement
{
    public sealed class SceneLoader : ISceneLoader
    {
        public async UniTask LoadScene(string name)
        {   
            AsyncOperationHandle<SceneInstance> handler = Addressables.LoadSceneAsync(name, LoadSceneMode.Single, false);

            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
        }
    }
}