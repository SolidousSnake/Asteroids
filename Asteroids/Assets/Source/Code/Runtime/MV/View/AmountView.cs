using UnityEngine;
using TMPro;

namespace Code.Runtime.MV.View
{
    public abstract class AmountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _prefix;

        public virtual void SetAmount(float amount)
        {
            _label.text = _prefix + amount.ToString();
        }
    }
}