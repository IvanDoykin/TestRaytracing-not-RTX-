using UnityEngine;

namespace Raytracing
{
    public class RaytracingController : MonoBehaviour
    {
        private void Start()
        {
            Ray.ReflectorHasHit += ReflectRay;
        }

        private void OnDisable()
        {
            Ray.ReflectorHasHit -= ReflectRay;
        }

        private void ReflectRay(Ray ray, Vector3 reflectorNormal, Vector3 hitPoint)
        {
            if (ray.Power > 0f && ray.Length > 0f)
            {
                Vector3 reflectedDirection = Vector3.Reflect(ray.Rotation * Vector3.up, reflectorNormal);
                Ray _ray = new Ray(ray.Power, ray.Length, Quaternion.FromToRotation(Vector3.up, reflectedDirection), hitPoint);
                _ray.Trace();
            }
        }
    }
}
