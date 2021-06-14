using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBack : MonoBehaviour
{
    public GameObject bullet;

    private float turnSpeed = 10;

    private float maxOffsetAngle = 120f;

    [SerializeField]
    private Vector3 thisAngle;

    private Transform target;

    public Camera camera;

    private float nextATK = 0;

    private float atkInterval = 5;
    private void Start()
    {
        target = camera.transform;

        thisAngle = this.transform.localEulerAngles;

    }
    // Update is called once per frame
    void Update()
    {

        viewMove();

        if (Input.GetMouseButtonDown(0))
        {//朝向枪口正前方发射子弹
            Fire();
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

    private void viewMove()
    {
        float angle;

        if ((this.transform.localEulerAngles.y - thisAngle.y) * (target.localEulerAngles.y - thisAngle.y) < 0)
        {

            if ((target.localEulerAngles.y - thisAngle.y) > 0)
            {
                angle = turnSpeed * Time.deltaTime;
            }
            else
            {
                angle = -turnSpeed * Time.deltaTime;
            }

        }
        else
        {
            if ((target.localEulerAngles.y - this.transform.localEulerAngles.y) > 0)
            {
                angle = turnSpeed * Time.deltaTime;
            }
            else
            {
                angle = -turnSpeed * Time.deltaTime;
            }
        }

        if (Mathf.Abs(angle + this.transform.localEulerAngles.y - thisAngle.y) > maxOffsetAngle)
        {
            angle = 0;
        }

        this.transform.Rotate(0, angle, 0);
    }

    private void Fire()
    {

        if (FireReady())
        {
            GameObject bulletGO = Instantiate(bullet, this.transform.position, this.transform.rotation.normalized) as GameObject;
            //初始化，传递攻击力、攻击距离
            bulletGO.GetComponent<Bullet>().Init(camera.transform.eulerAngles.x, 2);
        }
    }

    private bool FireReady()
    {
        float thisY = this.transform.localEulerAngles.y;

        float targetY = target.localEulerAngles.y;

        if (Mathf.Abs(thisY - targetY) < 1 && Time.time >= nextATK)
        {
            nextATK = Time.time + atkInterval;
            return true;
        }

        return false;
    }
}
