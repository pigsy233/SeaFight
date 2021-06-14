using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private float turnSpeed = 10;

    private float maxOffsetAngle = 100f;

    [SerializeField]
    private float thisAngle;

    public Camera camera;

    private void Start()
    {
        thisAngle = this.transform.eulerAngles.y;
    }
    // Update is called once per frame
    void Update()
    {
        Transform target = camera.transform;

        Transform now = this.transform;

        if (Mathf.Abs(now.eulerAngles.y - target.eulerAngles.y) > 1)
        {
            Vector3 cross = Vector3.Cross(now.position, target.position);

            if (cross.y < 0)
            {
                if (now.eulerAngles.y + turnSpeed * Time.deltaTime > thisAngle + maxOffsetAngle)
                {

                }
                else
                {
                    this.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                }
            }
            else
            {
                if (now.eulerAngles.y - turnSpeed * Time.deltaTime < thisAngle - maxOffsetAngle)
                {

                }
                else
                {
                    this.transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                }
                    
            }

        }
    }
}
