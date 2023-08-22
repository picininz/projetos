using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sldMusic;
    public Slider sldFX;




    public void ChanceMusicVolume()
    {
        mixer.SetFloat("MUSIC", (sldMusic.value));
    }

    public void ChanceFXVolume()
    {
        mixer.SetFloat("FX", (sldFX.value));
    }
}
