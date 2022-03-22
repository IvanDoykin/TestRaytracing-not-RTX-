using UnityEngine;

namespace Raytracing
{
    public class RaytracePipe : MonoBehaviour
    {
        [SerializeField] private float _rayPower = 0f;
        [SerializeField] private float _rayLength = 0f;

        public float RayPower => _rayPower;
        public float RayLength => _rayLength;
    }
}