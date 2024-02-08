using Code.Runtime.MV.View;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Infrastructure.Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private TimerView _timerView;

        public override void InstallBindings()
        {
            Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();
            Container.Bind<TimerView>().FromInstance(_timerView).AsSingle();
        }
    }
}