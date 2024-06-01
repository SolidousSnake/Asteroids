using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.MV.View
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _prefix;

        public void SetAmount(float amount)
        {
            _label.text = _prefix + $"{amount}";
        }
    }
}