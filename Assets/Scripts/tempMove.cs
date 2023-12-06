using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMove : MonoBehaviour
{
    //ToDo
    //Remove script and replace with actual player movement
    
    //Temporary movement script
    [SerializeField]
    public float speed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}