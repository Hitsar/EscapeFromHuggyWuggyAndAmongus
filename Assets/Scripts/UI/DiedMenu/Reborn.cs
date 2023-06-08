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
            Cursor.lockState = CursorLockMode.Locked;
            FindObjectOfType<FirstPersonController>().IsMove(true);
            yield return new WaitForSeconds(10);
            foreach (EnemyMovement enemy in _enemies)
                enemy.IsAttackedMove(false);
            gameObject.SetActive(false);
        }
    }
}