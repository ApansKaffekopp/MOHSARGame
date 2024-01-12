using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PixelChangeColor : MonoBehaviour
{
    private Renderer cubeRenderer;
    public Color currentColor;
    public UnityAction<PixelChangeColor> ColorChanged;

    void Start()
    {
        // Get the Renderer component of the cube
        cubeRenderer = GetComponent<Renderer>();
    }


     void OnCollisionEnter(Collision collision)
     {
         // Check if the collision is with another GameObject
         if (collision.gameObject.CompareTag("ColorChanger"))
         {
             // Get the Renderer component of the collided object
             Renderer collidedRenderer = collision.gameObject.GetComponent<Renderer>();

             // Get the color of the collided object
             Color newColor = collidedRenderer.material.color;

             // Apply the color to the cube
             cubeRenderer.material.color = newColor;
             currentColor = newColor;
             ColorChanged?.Invoke(this);
         }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
