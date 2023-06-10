using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.DiedMenu
{
    public class DiedMenuAnimator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lose;
        
        public void Enable()
        {
            transform.DOLocalMoveY(0, 1).SetDelay(1).SetEase(Ease.OutCubic).OnComplete((() =>
            {
                _lose.transform.DOScale(Vector2.one, 0.6f).SetEase(Ease.OutCubic);
                _lose.DOFade(1, 0.5f);
            }));
        }

        public void Disable()
        {
            _lose.transform.DOScale(new Vector2(11, 11), 0.6f).SetEase(Ease.InCubic);
            _lose.DOFade(0, 0.4f);
            transform.DOLocalMoveY(-1010, 1).SetDelay(0.2f).SetEase(Ease.OutCubic);
        }
    }
}