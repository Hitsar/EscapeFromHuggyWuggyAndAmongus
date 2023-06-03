using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out FirstPersonController player))
            {
                player.playerCanMove = false;
                player.cameraCanMove = false;
            }
        }
    }
}