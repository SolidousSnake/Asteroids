using Source.Code.Runtime.MV.View;
using UnityEngine;
using Zenject;

namespace Source.Code.Runtime.Core.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private TimeView _timeView;

        public override void InstallBindings()
        {
            Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle();
            Container.Bind<TimeView>().FromInstance(_timeView).AsSingle();
        }
    }
}