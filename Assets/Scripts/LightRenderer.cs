using UnityEngine;

public class LightRenderer : MonoBehaviour
{
    [SerializeField] private Light _directionalLight;
    private Camera _cameraMain;

    private void OnEnable()
    {
        _cameraMain = Camera.main;
        Camera.onPreRender += OnPreRenderCallback;
    }

    private void OnDisable() => Camera.onPreRender -= OnPreRenderCallback;

    private void OnPreRenderCallback(Camera camera) => _directionalLight.gameObject.SetActive(camera == _cameraMain);
}