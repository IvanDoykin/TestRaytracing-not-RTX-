using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace Raytracing
{
    public enum RotationAxis
    {
        Horizontal,
        Vertical
    }

    public class RaytracerTurnerUI : MonoBehaviour
    {
        public static event Action<float, RotationAxis> DegreeHasChanged;

        [SerializeField] private Raytracer _raytracer;
        private Slider _slider;
        private TMP_InputField _inputField;

        private void Start()
        {
            _slider = GetComponentInChildren<Slider>();
            _inputField = GetComponentInChildren<TMP_InputField>();
        }

        public void ChangeVerticalDegree()
        {
            DegreeHasChanged(GetDegree(), RotationAxis.Vertical);
        }

        public void ChangeHorizontalDegree()
        {
            DegreeHasChanged(GetDegree(), RotationAxis.Horizontal);
        }

        public void SyncWithInputField()
        {
            _inputField.text = GetDegree().ToString();
        }

        private float GetDegree()
        {
            return (4 * _slider.value - 2) * Raytracer.MaxDegree;
        }
    }
}