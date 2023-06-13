using UnityEngine;

public class MobileDevice : MonoBehaviour
{
    private void Start()
    {
        if (Progress.Instance.IsPhone == false) gameObject.SetActive(false);
    }
}
