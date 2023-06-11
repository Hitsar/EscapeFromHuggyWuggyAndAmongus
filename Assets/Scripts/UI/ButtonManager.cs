using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ButtonManager : MonoBehaviour
    {
        public void StartGame() => SceneManager.LoadScene(1);

        public void ExitToMenu() { SceneManager.LoadScene(0); Time.timeScale = 1; }

        public void ExitGame() => Application.Quit();
    }
}