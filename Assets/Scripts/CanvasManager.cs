using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
public class CanvasManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject time;
    [SerializeField] GameObject escapeMenu;
    [SerializeField] Brush brush;

    private void OnEnable() {
        if(gameManager = null) {
        }
        escapeMenu.SetActive(false);
    }

    public void ToggleEscapeMenu() {
        escapeMenu.SetActive(!escapeMenu.activeSelf);
    }

    public void RotateColor() {
        brush.RotateColor();
    }

    public void MainMenu() {
        SceneManager.LoadScene("StartMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
