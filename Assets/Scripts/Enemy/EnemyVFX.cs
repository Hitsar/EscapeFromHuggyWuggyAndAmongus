using UnityEngine;

namespace Enemy
{
    public class EnemyVFX : MonoBehaviour
    {
        private Animator _animator;
        private AudioSource _walk;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _walk = GetComponent<AudioSource>();
        }

        public void OnAttack() => _animator.SetTrigger("Attack");

        public void OnStopMove(bool isStop = true)
        {
            _animator.SetBool("Stop", isStop);
            _walk.mute = isStop;
        }
    }
}