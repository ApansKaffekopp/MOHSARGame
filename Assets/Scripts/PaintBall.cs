using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbodyColor;
    public GameObject brush;

    //ToDo
    //Set dynamically based on the current target
    [SerializeField]
    public Material[] materials;
    private Renderer objectRenderer;

    public int currentMaterialIndex;

    public void Move(Vector3 force)
    {
        rigidbodyColor.isKinematic = false;
        rigidbodyColor.AddForce(force, ForceMode.Impulse);
        transform.SetParent(null);
    }

    void Start()
    {
        // Get the Renderer component attached to the GameObject


        objectRenderer = GetComponent<Renderer>();
        if (materials.Length > 0)
        {
            // Set the initial material
            objectRenderer.material = materials[currentMaterialIndex];
        }
        else
        {
            Debug.LogError("No materials assigned to the MaterialCycler script on " + gameObject.name);
        }


    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}