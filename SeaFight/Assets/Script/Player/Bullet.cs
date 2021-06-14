using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int atk;

    private float zSpeed = 200;

    private float ySpeed;

    private float gravity = 10;
    public void Init(float angle, int atk)
    {
        ySpeed = 5*Mathf.Tan(angle * Mathf.Deg2Rad)/4;
        this.atk = atk;
    }

    private void Update()
    {
        transform.Translate(0, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);

        ySpeed -= gravity * Time.deltaTime;
    }
}
