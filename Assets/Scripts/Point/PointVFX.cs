using UnityEngine;

namespace Point
{
    public class PointVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        public void OnDisable() => _particle.Play();
    }
}