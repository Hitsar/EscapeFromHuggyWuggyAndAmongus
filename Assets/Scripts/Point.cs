using UI;
using UnityEngine;

public class Point : MonoBehaviour
{
    private PointsDisplay _display;

    private void Start()
    {
        _display = FindObjectOfType<PointsDisplay>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PointsCounter counter))
        {
            counter.AddPoint();
            _display.ChangeValue();
            gameObject.SetActive(false);
        }
    }
}
