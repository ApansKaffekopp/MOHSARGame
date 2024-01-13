using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaySound : MonoBehaviour
{

    public AudioSource soundPlayer;
    public AudioClip hover;
    public AudioClip clicked;
    public AudioClip backgroundMusic;
    public AudioClip shoot;
    public AudioClip hit;

    public void HoverSound()
    {
        soundPlayer.PlayOneShot(hover);
    }

    public void ClickedSound()
    {
        soundPlayer.PlayOneShot(clicked);
    }

    public void ShootSound()
    {
        soundPlayer.PlayOneShot(shoot);
    }

    public void HitSound()
    {
        soundPlayer.PlayOneShot(hit);
    }
}
