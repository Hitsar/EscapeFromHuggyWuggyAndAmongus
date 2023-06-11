using UnityEngine;

namespace UI.PauseMenu
{
    public class PauseMenuSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        private InputManager _inputManager;
        private bool _diedMenuIsActive;

        private void Awake()
        {
            _inputManager = new InputManager();
            _inputManager.Enable();
            _inputManager.UI.Pause.performed += _ => Switch();
        }

        private void Switch()
        {
            if (_diedMenuIsActive) return;
            bool active = _pauseMenu.gameObject.activeSelf;
            _pauseMenu.gameObject.SetActive(!active);
            Cursor.lockState = active ? CursorLockMode.Locked : CursorLockMode.None;
            Time.timeScale = active ? 1 : 0;
        }
        
        public void DiedMenuIsActive(bool active) => _diedMenuIsActive = active;
    }
}