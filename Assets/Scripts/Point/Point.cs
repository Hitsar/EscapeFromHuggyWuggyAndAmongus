using UnityEngine;

namespace Point
{
    public class Point : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PointsCounter counter))
            {
                counter.AddPoint();
                gameObject.SetActive(false);
            }
        }
    }
}
