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
        
        ySpeed = Mathf.Abs(5/(4*Mathf.Tan(angle*Mathf.Deg2Rad)));
        Debug.Log(Mathf.Tan(angle * Mathf.Deg2Rad));
        Debug.Log(ySpeed);
        this.atk = atk;
    }

    private void Update()
    {
        transform.Translate(0, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime,Space.Self);

        ySpeed -= gravity * Time.deltaTime;
    }
}
