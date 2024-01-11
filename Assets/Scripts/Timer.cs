using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.SetText(gameManager.GetTimer());
    }
}
