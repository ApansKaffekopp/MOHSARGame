using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelChangeColor : MonoBehaviour
{
    private Renderer cubeRenderer;

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
         }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
