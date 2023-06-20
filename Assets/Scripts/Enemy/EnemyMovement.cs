using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _targetPoints;
        private NavMeshAgent _navMeshAgent;
        private FirstPersonController _player;
        private EnemyVFX _vfx;
        private bool _seePlayer;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<FirstPersonController>();
            _vfx = GetComponent<EnemyVFX>();
            
            _player.OnAttacked += StopMove;
            StartCoroutine(MoveToTargetPoint());
        }

        private void FixedUpdate()
        {
            if (_seePlayer) _navMeshAgent.SetDestination(_player.transform.position);
            _vfx.OnStopMove(_navMeshAgent.velocity.x == 0 || _navMeshAgent.velocity.z == 0);
        }
        
        private void OnTriggerStay(Collider other) { if (other.gameObject.TryGetComponent(out FirstPersonController _)) _seePlayer = true; }
        
        private void OnTriggerExit(Collider other) { if (other.gameObject.TryGetComponent(out FirstPersonController _)) _seePlayer = false; }
        
        public void SpeedUp()
        {
            if (_navMeshAgent.speed >= 4.7f) return;
            _navMeshAgent.speed += 0.15f;
        }

        public void StopMove(bool isStop = true) => _navMeshAgent.isStopped = isStop;

        private IEnumerator MoveToTargetPoint()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(7, 14));
                _navMeshAgent.SetDestination(_targetPoints[Random.Range(0, _targetPoints.Length - 1)].position);
            }
        }
    }
}