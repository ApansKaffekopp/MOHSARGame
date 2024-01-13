using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] GameObject rotateInput;

    private bool isRotating = false;
    private Vector2 previousTouchPosition;
    private float rotationSpeed = 30f;
    bool rotateRight = false;
    bool rotateLeft = false;

    void Update()
    {
        if (rotateRight)
        {
            RotateCanvasClockWise();
        }

        if (rotateLeft)
        {
            RotateCanvasCounterClockWise();
        }
        /*if (Input.touchCount == 1)
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
                        
                        
                        previousTouchPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    gameObject.AddComponent<ARAnchor>();
                    GameObject.Find("Paint Brush").SetActive(false);
                    break;
            }
        }*/

    }

    private void RotateCanvasClockWise()
    {
        GameObject.Find("Plane(Clone)").transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void RotateCanvasCounterClockWise()
    {
        GameObject.Find("Plane(Clone)").transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }

    public void ToggleRotateRight(bool value)
    {
        rotateRight = value;
    }

    public void ToggleRotateLeft(bool value)
    {
        rotateLeft = value;
    }

    public void AnchorObject()
    {
        GameObject.Find("Plane(Clone)").AddComponent<ARAnchor>();
        rotateInput.SetActive(false);
    }
}