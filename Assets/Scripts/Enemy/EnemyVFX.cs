using UnityEngine;

namespace Enemy
{
    public class EnemyVFX : MonoBehaviour
    {
        private Animator _animator;

        private void Start() => _animator = GetComponentInChildren<Animator>();

        public void OnAttack() => _animator.SetTrigger("Attack");

        public void Move(bool isStop) => _animator.SetBool("Stop", isStop);
    }
}