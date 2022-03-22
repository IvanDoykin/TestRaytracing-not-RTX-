using UnityEngine;

namespace Raytracing
{
    public class RaytracerLine : MonoBehaviour
    {
        private Raytracer _raytracer;
        private LineRenderer _line;

        private void Start()
        {
            _raytracer = GetComponentInParent<Raytracer>();
            _line = GetComponent<LineRenderer>();

            SetStartPoint();
            Ray.ObjectHasHit += AddPoint;
        }

        private void SetStartPoint()
        {
            _line.positionCount = 1;
            _line.SetPosition(0, _raytracer.transform.position);
        }

        private void AddPoint(Vector3 point)
        {
            _line.positionCount++;
            _line.SetPosition(_line.positionCount - 1, point);
        }

        public void ResetRay()
        {
            SetStartPoint();
        }
    }
}