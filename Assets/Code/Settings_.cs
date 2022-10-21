using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_ : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void controlVolume(float volume){
        audioMixer.SetFloat("volume",volume);
    }
}
