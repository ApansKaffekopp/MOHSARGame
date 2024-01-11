using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private bool isRotating = false;
    private Vector2 previousTouchPosition;

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
                        transform.Rotate(Vector3.forward, -touchDelta.y, Space.World); // Adjust rotation sensitivity by multiplying touchDelta.x hej
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