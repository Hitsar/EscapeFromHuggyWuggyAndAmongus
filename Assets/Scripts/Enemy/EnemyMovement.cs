using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
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
            StartCoroutine(MoveToPlayer());
            StartCoroutine(MoveToTargetPoint());
            _player.OnAttacked += StopMove;
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

        public void StopMove(bool isStop = true)
        {
            _navMeshAgent.velocity = Vector3.zero;
            _navMeshAgent.isStopped = isStop;
        }

        private IEnumerator MoveToPlayer()
        {
            WaitForSeconds second = new WaitForSeconds(1);
            while (true)
            {
                Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit);
                _seePlayer = hit.collider.TryGetComponent(out FirstPersonController _);
                yield return second;
            }
        }

        private IEnumerator MoveToTargetPoint()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(7, 13));
                _navMeshAgent.SetDestination(_targetPoints[Random.Range(0, _targetPoints.Length - 1)].position);
            }
        }
    }
}