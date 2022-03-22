using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raytracing
{
    public class Reflector : MonoBehaviour
    {
        [SerializeField] private float _reflectionPower = 0f;
        public float ReflectionCoefficient
        {
            get
            {
                return _reflectionPower;
            }
            private set
            {
                _reflectionPower = value;
            }
        }

        private void Start()
        {
            if (_reflectionPower < 0f)
            {
                Debug.LogError("Incorrect reflection power. Set it more than zero.");
                _reflectionPower = 0f;
            }
        }
    }
}