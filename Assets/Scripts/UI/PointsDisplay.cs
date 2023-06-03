using TMPro;
using UnityEngine;

namespace UI
{
    public class PointsDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private int _value;
        
        public void ChangeValue()
        {
            _value++;
            _text.text = _value.ToString();
        }
    }
}