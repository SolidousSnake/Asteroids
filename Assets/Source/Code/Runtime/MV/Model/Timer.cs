using System.Threading;
using Cysharp.Threading.Tasks;
using Source.Code.Runtime.MV.View;
using UnityEngine;
using Zenject;

namespace Source.Code.Runtime.MV.Model
{
    public sealed class Timer : IInitializable
    {
        private readonly TimeView _timeView;
        private readonly CancellationTokenSource _cancellationTokenSource;
        
        private float _elapsedTime;
        private int _minutes;

        private int _seconds;

        public Timer(TimeView timeView)
        {
            _timeView = timeView;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async void Initialize()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                _elapsedTime += Time.deltaTime;
                _minutes = Mathf.FloorToInt(_elapsedTime / 60);
                _seconds = Mathf.FloorToInt(_elapsedTime % 60);
                _timeView.SetValue(_minutes, _seconds);
                await UniTask.WaitForSeconds(Time.deltaTime);
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}