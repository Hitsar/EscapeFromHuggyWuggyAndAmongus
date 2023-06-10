using Enemy;
using System.Collections;
using UnityEngine;

namespace UI.DiedMenu
{
    public class Reborn : MonoBehaviour
    {
        [SerializeField] private EnemyMovement[] _enemies;

        public void StartCoroutine() => StartCoroutine(StopEnemies());
        
        private IEnumerator StopEnemies()
        {
            FindObjectOfType<FirstPersonController>().IsMove();
            yield return new WaitForSeconds(5);
            foreach (EnemyMovement enemy in _enemies)
                enemy.StopMove(false);
        }
    }
}