using UnityEngine;

namespace UI
{
    public class InvertControl : MonoBehaviour
    {
        [SerializeField] private Transform _joystick;
        [SerializeField] private Transform _sprint;
        
       // public void ChangeValue(bool isInvert) => Progress.Instance.IsInvertControl = isInvert;

        private void Start()
        {
            return;
            Transform sprint = _sprint;
            _sprint = _joystick;
            _joystick = sprint;
        }
    }
}