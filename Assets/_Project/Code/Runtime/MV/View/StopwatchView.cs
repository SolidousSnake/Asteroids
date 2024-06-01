using System;
using _Project.Code.Runtime.MV.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.MV.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class StopwatchView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _prefix = "Time: ";
        [SerializeField] private string _format = "mm\\:ss";

         private Stopwatch _stopwatch;
        
        [Inject]
        private void Construct(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        private void SetValue(TimeSpan value)
        {
            _label.text = _prefix + value.ToString(@_format);
        }

        public void Subscribe() => _stopwatch.Ticked += SetValue;
        public void Unsubscribe() => _stopwatch.Ticked -= SetValue;
    }
}