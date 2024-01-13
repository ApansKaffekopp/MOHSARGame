using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayButtonSound : MonoBehaviour
{

    public AudioSource soundPlayer;
    public AudioClip hover;
    public AudioClip clicked;
    public AudioClip backgroundMusic;

    public void HoverSound()
    {
        soundPlayer.PlayOneShot(hover);
    }

    public void ClickedSound()
    {
        soundPlayer.PlayOneShot(clicked);
    }


}
