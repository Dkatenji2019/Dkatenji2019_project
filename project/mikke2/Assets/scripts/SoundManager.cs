using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public AudioSource True;
    static public AudioSource False;
    static public AudioSource GrubTiming;
    static public AudioSource Footsteps;

    [SerializeField]private AudioSource _grubTime;
    [SerializeField]private AudioSource _true;
    [SerializeField]private AudioSource _false;
    [SerializeField]private AudioSource _footsteps;
    [SerializeField]private AudioSource gameSound;

    int volume = 0;
    private void Awake()
    {
        True = _true;
        False  = _false;
        GrubTiming = _grubTime;
        Footsteps = _footsteps;
    }

    private void Update()
    {
        if(gameSound.time < 5f)
        {
            StopAllCoroutines();
            Fadein();

        }
        if (gameSound.time > gameSound.clip.length - 5.0f)
        {
            StopAllCoroutines();
            Fadeout();
        }
    }


    static public void PlayTrueSound()
    {
        True.PlayOneShot(True.clip);
    }

    static public void PlayFalseSound()
    {
        False.PlayOneShot(False.clip);
    }

    static public void PlayGrubTimingSound()
    {
        GrubTiming.PlayOneShot(GrubTiming.clip);
    }

    static public void PlayfootstepsSound()
    {
        if (!Footsteps.isPlaying)
        {
            Footsteps.Play();
        }
    }
    static public void StopfootstepsSound()
    {
        if (Footsteps.isPlaying)
        {
            Footsteps.Pause();
        }
    }

    static public void VolumeChangefootstepsSound(float value)
    {
        Footsteps.volume = value;
    }

    static public void PlayGrubTimeSound()
    {
        if (!GrubTiming.isPlaying)
        {
            GrubTiming.Play();
        }
        
    }

    static public void StopGrubTimeSound()
    {
        if (GrubTiming.isPlaying)
        {
            Footsteps.Pause();
        }

    }

    IEnumerator Fadein()
    {
        gameSound.enabled = true;
        for (; volume < 100; volume++)
        {
            gameSound.volume = (float)volume / 100;
            yield return null;
        }
        gameSound.volume = 1;
    }

    IEnumerator Fadeout()
    {
        for (; volume > 0; volume--)
        {
            gameSound.volume = (float)(volume) / 100;
            yield return null;
        }
        gameSound.volume = 0;
        gameSound.enabled = false;
    }
}
