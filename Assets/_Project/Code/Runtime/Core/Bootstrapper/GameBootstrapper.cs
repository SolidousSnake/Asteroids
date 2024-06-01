using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Data;
using _Project.Code.Runtime.Services.SaveLoadService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private TextMeshProUGUI _timeLabel;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _resetSaveButton;
        
        [Inject] private ISceneLoader _sceneLoader;
        [Inject] private ISaveLoadService _saveLoadService;
        [Inject] private AssetProvider _assetProvider;

        private async void Start()
        {
            InitializeView(_saveLoadService.Load());
            Application.targetFrameRate = 60;
            await InitializeServices();
            await _assetProvider.WarmupAssetsByLabel(Constants.AssetLabel.Menu);
        }

        private async UniTask InitializeServices()
        {
            await _assetProvider.InitializeAsync();
        }

        private void InitializeView(PlayerProgress playerProgress)
        {
            _scoreLabel.text = $"BEST SCORE: {playerProgress.BestScore}";
            _timeLabel.text = $"BEST TIME: " + playerProgress.BestTime.ToString(@"mm\:ss");
            
            _playButton.onClick.AddListener(OnClicked_LoadScene);
            _resetSaveButton.onClick.AddListener(OnClicked_ResetSave);
        }

        private async void OnClicked_LoadScene()
        {
            await _assetProvider.ReleaseAssetsByLabel(Constants.AssetLabel.Menu);
            await _sceneLoader.LoadScene(Constants.AssetPath.GameplayScene);
        }

        private void OnClicked_ResetSave()
        {
            _saveLoadService.Reset();
        }
    }
}