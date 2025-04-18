﻿using UnityEngine;

namespace ObservableKT._Source.DayCycle.SunLogic
{
    public class SunView : MonoBehaviour
    {
        private const float SUN_ROTATE_DEGREES = 360f;
        
        [SerializeField] private Transform sunPivot;
        [SerializeField] private float sunOffset;
        
        private Sun _sun;

        private void OnDestroy() => Expose();

        public void Init(Sun sun)
        {
            _sun = sun;
            
            Bind();
        }

        private void SetSunPosition(float cycleProgress)
        {
            var newRotation = -Vector3.forward * (SUN_ROTATE_DEGREES * cycleProgress);
            newRotation.z -= sunOffset;
            sunPivot.rotation = Quaternion.Euler(newRotation);
        }

        private void Bind() => _sun.OnSunNotified += SetSunPosition;

        private void Expose() => _sun.OnSunNotified -= SetSunPosition;
    }
}