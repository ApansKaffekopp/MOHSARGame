using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private bool isRotating = false;
    private Vector2 previousTouchPosition;
    private float rotationSpeed = 30f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform == transform)
                        {
                            isRotating = true;
                            previousTouchPosition = touch.position;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        Vector2 touchDelta = touch.position - previousTouchPosition;
                        //ToDo change to be called by buttons.
                        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); //Rotates object to the right
                        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime); //Rotates object to the left
                        previousTouchPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
