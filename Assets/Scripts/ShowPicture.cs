using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPicture : MonoBehaviour
{
    [SerializeField] GameObject picture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TogglePicture() {
        picture.SetActive(!picture.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
