using UnityEngine;

namespace Raytracing
{
    public class Raytracer : MonoBehaviour
    {
        public const float MaxDegree = 90f;

        private RaytracerLine _line;
        private RaytracePipe _pipe;

        private void Start()
        {
            _pipe = GetComponentInChildren<RaytracePipe>();
            _line = GetComponentInChildren<RaytracerLine>();

            RaytracerTurnerUI.DegreeHasChanged += Rotate;
        }

        private void OnDestroy()
        {
            RaytracerTurnerUI.DegreeHasChanged -= Rotate;
        }

        public void TraceRay()
        {
            _line.ResetRay();

            Ray ray = new Ray(_pipe.RayPower, _pipe.RayLength, _pipe.transform.rotation, transform.position);
            ray.Trace();
        }

        public void Rotate(float degree, RotationAxis axis)
        {
            if (axis == RotationAxis.Vertical)
            {
                _pipe.transform.localEulerAngles = new Vector3(degree, 0f, 0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, degree, 0f);
            }
        }
    }
}