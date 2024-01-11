using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void Play(String scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Player started" + scene);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player quit game.");
    }

    //ToDo Add if we have time.
    public void Settings()
    {
        //ToDo add implementation.
        Debug.Log("SETTINGS FUNCTION NOT YET IMPLEMENTED");
    }
}
