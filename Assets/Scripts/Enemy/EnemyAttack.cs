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
                GetComponent<EnemyVFX>().OnAttack();
                player.IsAttacked();
                FindObjectOfType<DiedMenuAnimator>(true).gameObject.SetActive(true);
            }
        }
    }
}