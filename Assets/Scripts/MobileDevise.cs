using UnityEngine;

public class MobileDevise : MonoBehaviour
{
    private void Start()
    {
        if (Progress.Instance.IsPhone == false) gameObject.SetActive(false);
    }
}
