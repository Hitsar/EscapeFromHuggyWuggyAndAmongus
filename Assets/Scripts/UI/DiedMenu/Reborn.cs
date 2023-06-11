using Enemy;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UI.DiedMenu
{
    public class Reborn : MonoBehaviour
    {
        [SerializeField] private EnemyMovement[] _enemies;

        [DllImport("__Internal")]
        private static extern void RewardedAdExtern();

        public void ShowAd() => RewardedAdExtern();
        
        public void OnRewarded()
        {
            StartCoroutine(StopEnemies());
            GetComponent<DiedMenuAnimator>().Disable();
        }
        
        private IEnumerator StopEnemies()
        {
            FindObjectOfType<FirstPersonController>().IsMove();
            yield return new WaitForSeconds(5);
            foreach (EnemyMovement enemy in _enemies)
                enemy.StopMove(false);
        }
    }
}