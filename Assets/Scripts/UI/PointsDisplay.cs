using TMPro;
using UnityEngine;

namespace UI
{
    public class PointsDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void Display(int value)
        {
            _text.text = value.ToString();
        }
    }
}