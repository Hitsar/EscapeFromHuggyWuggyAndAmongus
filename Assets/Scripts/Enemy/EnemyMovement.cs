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
        private bool _seePlayer;
        private float _maxSpeed;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<FirstPersonController>();
            StartCoroutine(RayCheck());
        }

        private void FixedUpdate() { if (_seePlayer) _navMeshAgent.SetDestination(_player.transform.position); }

        private void OnTriggerEnter(Collider other) { if (other.gameObject.TryGetComponent(out FirstPersonController _)) _seePlayer = true; }
        
        private void OnTriggerExit(Collider other) { if (other.gameObject.TryGetComponent(out FirstPersonController _)) _seePlayer = false; }

        #region SpeedControl
        
        public void SpeedUp()
        {
            if (_navMeshAgent.speed >= 4.7f) return;
            _navMeshAgent.speed += 0.15f;
            _maxSpeed = _navMeshAgent.speed;
        }

        public void StopMove() => _navMeshAgent.speed = 0;

        public void ResumeMove() => _navMeshAgent.speed = _maxSpeed;
        
        #endregion

        private IEnumerator RayCheck()
        {
            WaitForSeconds second = new WaitForSeconds(1);
            while (true)
            {
                Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit);
                _seePlayer = hit.collider.TryGetComponent(out FirstPersonController _) ? true : false;
                yield return second;
            }
        }

        private IEnumerator MoveTargetPoint()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(2, 8));
                _navMeshAgent.SetDestination(_targetPoints[Random.Range(0, _targetPoints.Length - 1)].position);
            }
        }
    }
}