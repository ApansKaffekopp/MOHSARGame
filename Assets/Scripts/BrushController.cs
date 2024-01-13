using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class BrushController : MonoBehaviour
{
    [SerializeField]
    private Brush brush;

    [SerializeField]
    private float maxPower;

    //Aiming varibales
    private Touch touch;

    private Vector3 dragStartPos;

    private Vector3 dragReleasePos;

    private Vector3 direction;

    private float power;

    private Vector3 currentDragPos;

    private Vector3 currentDir;

    private float currentPow;

    [NonSerialized]
    public bool shooting;

    [NonSerialized] public bool canShoot;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        brush.Reload();
    }

    private void OnEnable() {
        canShoot = true;
        if(gameManager != null) {
        gameManager.toggleShooting += toggleShooting;
        }
    }

    private void OnDisable() {
        if(gameManager != null) {
        gameManager.toggleShooting -= toggleShooting;
        }
    }

    private void toggleShooting(bool inp) {
        canShoot = inp;
    }

    private void Update()
    {
        if(canShoot) {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                
                //Start touch
                if (touch.phase == TouchPhase.Began && !shooting)
                {
                    dragStartPos = touch.position;
                    
                    shooting = true;
                }

                //Moving touch
                if (touch.phase == TouchPhase.Moved && shooting)
                {
                    currentDragPos = touch.position;
                    currentDir = calcDirection(dragStartPos, currentDragPos);
                    currentPow = calcPower(dragStartPos, currentDragPos);
                    brush.renderTrejectory(currentDir, currentPow);
                    //brush.transform.eulerAngles = new Vector3(currentPow*-1, 0, 0);
                }
                
                //Released touch
                if (touch.phase == TouchPhase.Ended && shooting)
                {
                    dragReleasePos = touch.position;
                    direction = calcDirection(dragStartPos, dragReleasePos);

                    //Power based on length of direction vector.
                    power = calcPower(dragStartPos, dragReleasePos);

                    brush.Shoot(direction, power);
                    brush.resetTrejectory();

                    //Reset paint ball
                    direction = new Vector3(0, 0, 0);
                    power = 0;
                    shooting = false;
                }
            }
        } else {
                brush.resetTrejectory();

                //Reset paint ball
                direction = new Vector3(0, 0, 0);
                power = 0;
                shooting = false;
        }
        /*
        if(!shooting) {
            if(brush.transform.rotation.x < 0) {
                brush.transform.Rotate(new Vector3(1, 0, 0));
            } else {
                brush.transform.rotation = Quaternion.identity;
            }
        }
        */
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

    public float getCurrentPower()
    {
        return power;
    }

    public float getMaxPower()
    {
        return maxPower;
    }
}