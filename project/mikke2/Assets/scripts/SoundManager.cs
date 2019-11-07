using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public AudioSource True;
    static public AudioSource False;
    static public AudioSource GrubTiming;

    [SerializeField]private AudioSource _grubTiming;
    [SerializeField]private AudioSource _true;
    [SerializeField]private AudioSource _false;

    private void Awake()
    {
        True = _true;
        False  = _false;
        GrubTiming = _grubTiming;
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
}
