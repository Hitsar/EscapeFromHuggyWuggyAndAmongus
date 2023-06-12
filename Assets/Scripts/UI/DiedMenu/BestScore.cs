using TMPro;
using UnityEngine;

namespace UI.DiedMenu
{
    public class BestScore : MonoBehaviour
    {
        private TMP_Text _text;
        private FirstPersonController _player;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            _player = FindObjectOfType<FirstPersonController>();
            _player.OnAttacked += SetScore;
        }

        private void SetScore(bool _) => _text.text = "Рекорд: __"; // + Progress.Instance.PlayerInfo.Score;
    }
}