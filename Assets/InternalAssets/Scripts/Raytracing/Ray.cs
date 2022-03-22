using System;
using UnityEngine;

namespace Raytracing
{
    public class Ray
    {
        public static event Action<Vector3> ObjectHasHit;
        public static event Action<Ray, Vector3, Vector3> ReflectorHasHit;

        private float _power;
        public float Power => _power;

        private float _length;
        public float Length => _length;

        private Quaternion _rotation;
        public Quaternion Rotation => _rotation;

        private Vector3 _origin;

        public Ray(float power, float length, Quaternion rotation, Vector3 origin)
        {
            _power = power;
            _length = length;
            _rotation = rotation;
            _origin = origin;
        }

        public void Trace()
        {
            if (_power < 0f || _length < 0f)
            {
                throw new UnityException("Incorrect ray power/length. Set them more than zero.");
            }

            TryHitObject();
        }

        private void TryHitObject()
        {
            UnityEngine.Ray ray = new UnityEngine.Ray(_origin, _rotation * Vector3.up);

            if (Physics.Raycast(ray, out RaycastHit hit, _length))
            {
                ObjectHasHit(hit.point);
                if (hit.transform.GetComponent<Reflector>() is Reflector reflector)
                {
                    _power -= reflector.ReflectionCoefficient;
                    _length -= hit.distance;

                    ReflectorHasHit(this, hit.normal, hit.point);
                }
            }
        }
    }
}
