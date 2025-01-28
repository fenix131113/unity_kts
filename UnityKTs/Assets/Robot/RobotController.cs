using System.Collections;
using UnityEngine;

namespace Robot
{
    public class RobotController : MonoBehaviour
    {
        [SerializeField] private HingeJoint[] firstPair;
        [SerializeField] private HingeJoint[] secondPair;
        [SerializeField] private HingeJoint[] inverseFirstPair;
        [SerializeField] private HingeJoint[] inverseSecondPair;

        private void Start()
        {
            Time.timeScale = 2;
            StartCoroutine(MoveSeparate(false, false));
            //StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            var motor = firstPair[0].motor;
            motor.force = 50; // Устанавливаем силу мотора
            motor.targetVelocity = 90; // Устанавливаем целевую скорость
            firstPair[0].motor = motor;
            firstPair[0].useMotor = true;
            yield break;
        }

        private IEnumerator Move(bool reverse)
        {
            var constant = 1.5f;

            foreach (var leg in secondPair)
                leg.useMotor = false;
            foreach (var leg in firstPair)
            {
                var motor = leg.motor;
                motor.force = reverse ? 50 : 25; // Устанавливаем силу мотора
                motor.targetVelocity = reverse ? -180 : 90; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            yield return new WaitForSeconds(constant);

            foreach (var leg in firstPair)
                leg.useMotor = false;

            foreach (var leg in secondPair)
            {
                var motor = leg.motor;
                motor.force = !reverse ? 50 : 25; // Устанавливаем силу мотора
                motor.targetVelocity = !reverse ? -90 : 180; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            yield return new WaitForSeconds(constant);
            StartCoroutine(Move(!reverse));
        }

        private IEnumerator MoveSeparate(bool reverse, bool afterFirst)
        {
            var constant = 1f;
            var degress = 100f;

            if (afterFirst)
                foreach (var leg in secondPair)
                {
                    var motor = leg.motor;
                    motor.force = 1000; // Устанавливаем силу мотора
                    motor.targetVelocity = !reverse ? -degress : degress; // Устанавливаем целевую скорость
                    leg.motor = motor;
                    leg.useMotor = true;
                }

            foreach (var leg in firstPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = reverse ? -degress : degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }
            
            foreach (var leg in inverseFirstPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = reverse ? degress : -degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            foreach (var leg in inverseSecondPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = !reverse ? degress : -degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            yield return new WaitForSeconds(constant);

            foreach (var leg in firstPair)
            {
                var motor = leg.motor;
                motor.force = 5000; // Устанавливаем силу мотора
                motor.targetVelocity = !reverse ? -degress : degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            foreach (var leg in secondPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = reverse ? -degress : degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }
            
            foreach (var leg in inverseFirstPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = !reverse ? degress : -degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            foreach (var leg in inverseSecondPair)
            {
                var motor = leg.motor;
                motor.force = 1000; // Устанавливаем силу мотора
                motor.targetVelocity = reverse ? degress : -degress; // Устанавливаем целевую скорость
                leg.motor = motor;
                leg.useMotor = true;
            }

            yield return new WaitForSeconds(constant);
            StartCoroutine(MoveSeparate(!reverse, true));
        }
    }
}