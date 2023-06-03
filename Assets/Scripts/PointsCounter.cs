using Enemy;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private Point[] _points;
    [SerializeField] private EnemyMovement[] _enemies;
    private byte _value;

    public void AddPoint()
    {
        _value++;
        if (_value == 5)
        {
            foreach (EnemyMovement enemy in _enemies)
                enemy.ChangeSpeed();
        }

        if (_value >= 10)
        {
            _value = 0;
            foreach (Point point in _points)
                point.gameObject.SetActive(true);
            return;
        }
    }
}
