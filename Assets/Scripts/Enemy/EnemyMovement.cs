using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private FirstPersonController _player;
        private bool _seePlayer;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<FirstPersonController>();
        }

        private void FixedUpdate()
        {
            if (_seePlayer) _navMeshAgent.SetDestination(_player.transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out FirstPersonController player))
                _seePlayer = true;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out FirstPersonController player))
            {
                _seePlayer = false;
                _navMeshAgent.SetDestination(transform.position);
            }
        }

        public void ChangeSpeed()
        {
            _navMeshAgent.speed = _navMeshAgent.speed + 0.15f;
        }
    }
}