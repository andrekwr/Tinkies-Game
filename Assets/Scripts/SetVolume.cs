using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevelSFX(float sliderValue){ 
        mixer.SetFloat("SFXParam", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelMusic(float sliderValue){ 
        mixer.SetFloat("MusicParam", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelMaster(float sliderValue){ 
        mixer.SetFloat("MasterParam", Mathf.Log10(sliderValue) * 20);
    }
}
