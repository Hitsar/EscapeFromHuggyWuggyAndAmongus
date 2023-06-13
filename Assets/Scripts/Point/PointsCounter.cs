using Enemy;
using UI;
using UnityEngine;

namespace Point
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private EnemyMovement[] _enemies;
        [SerializeField] private Point[] _points;
        private PointsDisplay _display;
        private byte _value;
        private int _score;

        private void Start() => _display = FindObjectOfType<PointsDisplay>();

        public void AddPoint()
        {
            _score++;
            _display.Display(_score);
            
            _value++;
            switch (_value)
            {
                case 57:
                    foreach (EnemyMovement enemy in _enemies)
                        enemy.SpeedUp();
                    break;
            
                case >= 171:
                    _value = 0;
                    foreach (Point point in _points)
                        point.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
