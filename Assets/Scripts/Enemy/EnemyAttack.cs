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
                player.IsAttacked();
                GetComponent<EnemyVFX>().OnAttack();
                FindObjectOfType<DiedMenuAnimator>(true).Enable();
            }
        }
    }
}