using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private float accelerateSpeed = 3f;

    [Tooltip("移动速度")]
    [SerializeField]
    private float speed = 0;

    private float maxPositiveSpeed = 50f;

    private float maxNegetiveSpeed = -15f;

    private float turnSpeed = 0;

    private float turnAccelerateSpeed = 1f;

    private float maxTurnSpeed = 10;

    public void Movement(float xT, float yT)
    {
        if (speed >= maxNegetiveSpeed && speed <= maxPositiveSpeed)
        {
            speed += yT * Time.deltaTime * accelerateSpeed;
            if (speed > maxPositiveSpeed)
                speed = maxPositiveSpeed;
            if (speed < maxNegetiveSpeed)
                speed = maxNegetiveSpeed;

        }

        if (turnSpeed >= maxNegetiveSpeed && turnSpeed <= maxPositiveSpeed)
        {
            turnSpeed += xT * Time.deltaTime * turnAccelerateSpeed;
            if (turnSpeed > maxTurnSpeed)
                turnSpeed = maxTurnSpeed;
            if (turnSpeed < -maxTurnSpeed)
                turnSpeed = -maxTurnSpeed;

        }

        this.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
