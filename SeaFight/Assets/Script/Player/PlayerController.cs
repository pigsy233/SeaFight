using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    private float xP;
    private float yP;
    private float xT;
    private float yT;
    [SerializeField]
    private float xDegree;
    private float yDegree;




    public Vector3 pos;

    [SerializeField]
    private Camera camera;

    public Vector3 ss;

    public GameObject playerGO;

    [Tooltip("视角旋转速度")]
    public float rotateSpeed = 50;

    [Tooltip("视角移动速度")]
    public float moveSpeed = 0.5f;

    private void Start()
    {
        camera = this.GetComponentInChildren<Camera>();
        ss = camera.transform.rotation.eulerAngles;
        camera.transform.LookAt(new Vector3(0, 40, 0));
    }

    // Start is called before the first frame update
    private void Update()
    {
        xP = Input.GetAxis("Mouse Y");

        yP = Input.GetAxis("Mouse X");


        if (xP != 0 || yP != 0)
        {
            RotateView();
        }



        yT = Input.GetAxis("Vertical");

        xT = Input.GetAxis("Horizontal");

        Movement();
    }

    private void Movement()
    {




        this.transform.Translate(xT * moveSpeed, 0, yT * moveSpeed);
    }

    private void RotateView()
    {
        //处于update中需要乘以时间
        xP *= Time.deltaTime * rotateSpeed;

        yP *= Time.deltaTime * rotateSpeed;

        camera.transform.Rotate(-xP, 0, 0, Space.Self);

        camera.transform.Rotate(0, yP, 0, Space.World);

        xDegree = camera.transform.eulerAngles.x;

        yDegree = camera.transform.eulerAngles.y;

        Vector3 position = new Vector3(0, 30 + 40 * Mathf.Sin(Mathf.Deg2Rad * xDegree), -150 * Mathf.Cos(Mathf.Deg2Rad * xDegree));

        //Debug.Log(Vector3.Distance(Vector3.zero, position));

        camera.transform.position = this.transform.position + new Vector3(-Mathf.Sin(Mathf.Deg2Rad * yDegree) * Vector3.Distance(Vector3.zero, position), position.y, -Mathf.Cos(Mathf.Deg2Rad * yDegree) * Vector3.Distance(Vector3.zero, position));

        //camera.transform.LookAt(new Vector3(0,40,0));
    }
}
