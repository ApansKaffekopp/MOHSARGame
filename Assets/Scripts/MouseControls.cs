using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    [SerializeField]
    private Brush brush;

    [SerializeField]
    private float maxPower;

    //Aiming varibales

    private Vector3 mouseDownPos;

    private Vector3 mouseUpPos;

    private Vector3 direction;

    private float power;

    private Vector3 currentMousePos;

    private Vector3 currentDir;

    private float currentPow;

    private bool shooting;

    [NonSerialized] public bool canShoot;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        brush.Reload();

        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() {
        gameManager.toggleShooting += toggleShooting;
    }

    private void toggleShooting(bool inp) {
        canShoot = inp;
    }

    private void Update()
    {
        if(canShoot) {
            //Start shooting process
            if (Input.GetMouseButtonDown(0) && !shooting)
            {
                mouseDownPos = Input.mousePosition;
                shooting = true;
            }

            if (shooting)
            {
                currentMousePos = Input.mousePosition;
                currentDir = calcDirection(mouseDownPos, currentMousePos);
                currentPow = calcPower(mouseDownPos, currentMousePos);

            brush.renderTrejectory(currentDir, currentPow);
            //brush.transform.eulerAngles = new Vector3(currentPow * -1, 0, 0);
        }


            if (shooting && Input.GetMouseButtonUp(0))
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
                shooting = false;
            }
        } else {
                    brush.resetTrejectory();

                    //Reset paint ball
                    direction = new Vector3(0, 0, 0);
                    power = 0;
                    shooting = false;
        }
    }

    private Vector3 calcDirection(Vector3 startPoint, Vector3 endPoint)
    {
        return Vector3.Normalize(startPoint - endPoint);
    }

    private float calcPower(Vector3 startPoint, Vector3 endPoint)
    {
        float distance = Mathf.Max(Vector3.Distance(startPoint, endPoint), 1f);
        float scaledPower = distance * 0.1f;
        return Mathf.Min(scaledPower, maxPower);
    }
}
