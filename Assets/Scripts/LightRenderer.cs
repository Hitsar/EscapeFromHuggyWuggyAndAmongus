using UnityEngine;

public class LightRenderer : MonoBehaviour
{
    [SerializeField] private Light _directionalLight;
    private Camera _cameraMain;

    private void Start()
    {
        _cameraMain = Camera.main;
        Camera.onPreRender += OnPreRenderCallback;
    }

    private void OnPreRenderCallback(Camera camera) => _directionalLight.gameObject.SetActive(camera == _cameraMain);
}