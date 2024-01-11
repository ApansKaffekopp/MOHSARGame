using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        //Might want to use string name instead of index if we add more scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Player started game.");
    }

    public void Qut()
    {
        Application.Quit();
        Debug.Log("Player quit game.");
    }
}
