using _Project.Code.Runtime.Core.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.Core.States.View
{
    public sealed class FailureStateView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _loadMenuButton;

        private UniTaskCompletionSource<TargetScene> _result;

        public UniTask<TargetScene> Show()
        {
            gameObject.SetActive(true);
            _result = new UniTaskCompletionSource<TargetScene>();
            return _result.Task;
        }

        public void Hide() => gameObject.SetActive(false);
        
        private void OnEnable()
        {
            _restartButton.onClick.AddListener(() => _result.TrySetResult(TargetScene.Gameplay));
            _loadMenuButton.onClick.AddListener(() => _result.TrySetResult(TargetScene.Menu));
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _loadMenuButton.onClick.RemoveAllListeners();
        }
    }
}