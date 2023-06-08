using UI.DiedMenu;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out FirstPersonController player))
            {
                player.IsMove(false);
                GetComponent<EnemyVFX>().OnAttack();
                FindObjectOfType<DiedMenuAnimator>(true).gameObject.SetActive(true);
            }
        }
    }
}