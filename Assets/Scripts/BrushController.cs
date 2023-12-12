using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushController : MonoBehaviour
{

    [SerializeField]
    private Brush brush;

    [SerializeField]
    private float maxPower;

    //Aiming varibales
    [SerializeField]
    private float powerDivider;

    private Vector3 mouseDownPos;

    private Vector3 mouseUpPos;

    private Vector3 direction;

    private float power;

    private Vector3 currentMousePos;

    [NonSerialized]
    public Vector3 currentDir;

    [NonSerialized]
    public float currentPow;

    [NonSerialized]
    public bool shoot;

    private void Start()
    {
        brush.Reload();

        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Start shooting process
        if (Input.GetMouseButtonDown(0) && !shoot)
        {
            mouseDownPos = Input.mousePosition;
            shoot = true;
        }

        if(shoot)
        {
            currentMousePos = Input.mousePosition;
            currentDir = calcDirection(mouseDownPos, currentMousePos);
            currentPow = calcPower(mouseDownPos, currentMousePos);

            brush.renderTrejectory(currentDir, currentPow);
            brush.transform.eulerAngles = new Vector3(currentPow*-1, 0, 0);
        }


        if (shoot && Input.GetMouseButtonUp(0))
        {
            mouseUpPos = Input.mousePosition;
            direction = calcDirection(mouseDownPos, mouseUpPos);

            //Power based on length of direction vector.
            power = calcPower(mouseDownPos, mouseUpPos);

            brush.Shoot(direction, power);
            brush.resetTrejectory();

            //Reset paint ball
            direction = new Vector3(0, 0, 0);
            power = 0;
            shoot = false;
        }

        if(!shoot) {
            if(brush.transform.rotation.x < 0) {
                brush.transform.Rotate(new Vector3(1, 0, 0));
            } else {
                brush.transform.rotation = Quaternion.identity;
            }
        }
    }

    private Vector3 calcDirection(Vector3 startPoint, Vector3 endPoint)
    {
        return Vector3.Normalize(startPoint - endPoint);
    }

    private float calcPower(Vector3 startPoint, Vector3 endPoint)
    {
        return Mathf.Min(Vector3.Distance(startPoint, endPoint) / powerDivider, maxPower);
    }
}