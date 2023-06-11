using UnityEngine;

namespace Point
{
    public class PointVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        private void OnDisable() => _particle.Play();
    }
}