using UnityEngine;
using DG.Tweening;

namespace UI.MainMenu
{
    public class SettingsAnimator : MonoBehaviour
    {
        public void Enable()
        {
            transform.DOLocalMoveY(0, 1).SetEase(Ease.OutCubic);
        }

        public void Disable()
        {
            transform.DOLocalMoveY(-1000, 1).SetEase(Ease.OutCubic);
        }
    }
}