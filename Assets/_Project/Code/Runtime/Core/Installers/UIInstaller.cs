using _Project.Code.Runtime.Core.States.View;
using _Project.Code.Runtime.MV.View;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Code.Runtime.Core.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [FormerlySerializedAs("_timerView")] [FormerlySerializedAs("_timeView")] [SerializeField] private StopwatchView _stopwatchView;
        [SerializeField] private PlayingStateView _playingStateView;
        [SerializeField] private FailureStateView _failureStateView;
        
        public override void InstallBindings()
        {
            // Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();
            // Container.Bind<TimeView>().FromInstance(_timeView).AsSingle();
            Container.BindInstance(_scoreView);
            Container.BindInstance(_stopwatchView);
            Container.BindInstance(_playingStateView);
            Container.BindInstance(_failureStateView);
        }
    }
}