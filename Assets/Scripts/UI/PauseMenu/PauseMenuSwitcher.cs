using UnityEngine;

namespace UI.PauseMenu
{
    public class PauseMenuSwitcher : MonoBehaviour
    {
        [SerializeField] private PauseMenuAnimator _pauseMenu;
        private InputManager _inputManager;

        private void Awake()
        {
            _inputManager = new InputManager();
            _inputManager.Enable();
            _inputManager.UI.Pause.performed += _ => Switch();
        }

        public void Switch()
        {
            bool active = _pauseMenu.gameObject.activeSelf == true;
            _pauseMenu.gameObject.SetActive(!active);
            Cursor.lockState = active ? CursorLockMode.Locked : CursorLockMode.None;
            Time.timeScale = active ? 1 : 0;
        }
    }
}