using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXMNG : MonoBehaviour
{
    private static SoundFXMNG ins;
    public static SoundFXMNG Ins => ins;

    [Header("-----------Audio Source-----------")]
    public AudioSource SFXSource;

    [Header("-----------Audio Clip-----------")]
    public AudioClip bounce;
    public AudioClip button;
    public AudioClip coin;
    public AudioClip dead;
    public AudioClip door;
    public AudioClip jump;
    public AudioClip outtro;
    public AudioClip revive;
    public AudioClip run;
    public AudioClip saw;
    public AudioClip stageclear;
    public AudioClip trap;
    public AudioClip walltrap;

    private void Awake()
    {
        SoundFXMNG.ins = this;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
