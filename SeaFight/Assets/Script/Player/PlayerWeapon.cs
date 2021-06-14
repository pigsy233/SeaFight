using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private float turnSpeed = 10;

    private float maxOffsetAngle = 100f;

    [SerializeField]
    private Vector3 thisAngle;

    private Transform target;

    public Camera camera;

    private void Start()
    {
        target = camera.transform;

        thisAngle = this.transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {

        if ((this.transform.eulerAngles.y - thisAngle.y) * (target.eulerAngles.y - thisAngle.y) < 0)
        {
            if ((target.eulerAngles.y - thisAngle.y) > 0 )
            {
                this.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
            
        }
        else
        {
            if ((target.eulerAngles.y - this.transform.eulerAngles.y) > 0)
            {
                this.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            }
            else
            {
                this.transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            }
        }


        //Vector3 nowCross = Vector3.Cross(thisAngle, this.transform.eulerAngles);

        //Vector3 targetCross = Vector3.Cross(thisAngle, target.eulerAngles);




        //float angle;

        //if (nowCross.y * targetCross.y < 0)
        //{
        //    if (targetCross.y < 0)
        //    {
        //        angle = -turnSpeed * Time.deltaTime;
        //    }
        //    else
        //    {
        //        angle = turnSpeed * Time.deltaTime;
        //    }
            
        //}
        //else
        //{
        //    Vector3 cross = Vector3.Cross(this.transform.eulerAngles, target.eulerAngles);

        //    if (cross.y < 0)
        //    {
        //        angle = -turnSpeed * Time.deltaTime;
        //    }
        //    else
        //    {
        //        angle = turnSpeed * Time.deltaTime;
        //    }

        //}

        //if (Mathf.Abs(angle + this.transform.eulerAngles.y) > maxOffsetAngle)
        //{
        //    angle = 0;
        //}

        //this.transform.eulerAngles = Quaternion.Euler(0, angle, 0) * this.transform.rotation.eulerAngles;
    }
}
