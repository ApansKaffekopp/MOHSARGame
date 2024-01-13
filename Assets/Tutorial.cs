using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] GameObject brush;
    [SerializeField] GameObject tutorials;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndTutorial(){
        tutorials.SetActive(false);
        brush.SetActive(true);
    }
}
