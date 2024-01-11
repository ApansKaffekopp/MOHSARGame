using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject time;

    [SerializeField] GameObject escapeMenu;

    private void OnEnable() {
        if(gameManager = null) {
        time.SetActive(false);
        }
        escapeMenu.SetActive(false);
    }

    public void ToggleEscapeMenu() {
        escapeMenu.SetActive(!escapeMenu.activeSelf);
    }

    public void MainMenu() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
