using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public AudioSource True;
    static public AudioSource False;
    static public AudioSource GrubTiming;
    static public AudioSource Footsteps;

    [SerializeField]private AudioSource _grubTiming;
    [SerializeField]private AudioSource _true;
    [SerializeField]private AudioSource _false;
    [SerializeField]private AudioSource _footsteps;

    private void Awake()
    {
        True = _true;
        False  = _false;
        GrubTiming = _grubTiming;
        Footsteps = _footsteps;
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
}
