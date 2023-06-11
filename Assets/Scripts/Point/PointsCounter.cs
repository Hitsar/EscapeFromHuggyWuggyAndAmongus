using Enemy;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private EnemyMovement[] _enemies;
    [SerializeField] private Point.Point[] _points;
    private byte _value;

    public void AddPoint()
    {
        _value++;
        switch (_value)
        {
            case 57:
                foreach (EnemyMovement enemy in _enemies)
                    enemy.SpeedUp();
                break;
            
            case >= 171:
                _value = 0;
                foreach (Point.Point point in _points)
                    point.gameObject.SetActive(true);
                break;
        }
    }
}
