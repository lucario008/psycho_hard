using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioMixer sfxMixer;

    [SerializeField] public Slider sliderVolumenSFX;

    public void SetSFXVolume()
    {
        // Debug.Log("Nuevo volumen: " + volume);

        
         
        //AgarreCarrito.cs float decibels = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20;  // Convertir a decibelios
        // Convierte el valor a dB (-80 a 0)
        sfxMixer.SetFloat( "VolumeSFX", (sliderVolumenSFX.value * 10));

        //Debug.Log ("Volumen en decibelios:" + decibels);
    }
}