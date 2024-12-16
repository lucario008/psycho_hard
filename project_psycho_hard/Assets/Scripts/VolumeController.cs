using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioMixer AudioMixer;

    [SerializeField] public Slider sliderVolumenSFX;
    [SerializeField] public Slider sliderVolumenMusic;
    [SerializeField] public Slider sliderGeneral;

    [SerializeField] public Toggle toggleMuteAll;
    [SerializeField] public Toggle toggleMuteSFX;
    [SerializeField] public Toggle toggleMuteMusic;

    private bool isMuted = false;

        void Start()
    {
        if (toggleMuteAll != null)
        {
            // Configurar el evento de cambio del toggle
            toggleMuteAll.onValueChanged.AddListener(ToggleMuteAll);
            toggleMuteSFX.onValueChanged.AddListener(ToggleMuteSFX);
            toggleMuteMusic.onValueChanged.AddListener(ToggleMuteMusic);
        }
    }

    public void SetSFXVolume()
    {       
       AudioMixer.SetFloat( "VolumeSFX", (sliderVolumenSFX.value * 10));
    }

    public void SetMusicVolume()
    {       
       AudioMixer.SetFloat( "VolumeMusic", (sliderVolumenMusic.value * 10));
    }

    public void SetGeneralVolume()
    {       
       AudioMixer.SetFloat( "VolumeGeneral", (sliderGeneral.value * 10));
    }

    public void ToggleMuteAll (bool mute)
    {
        isMuted = mute;

        if (isMuted)
        {
            AudioMixer.SetFloat("VolumeGeneral", -80f);  // Silencia
        }
        else
        {
            // Restaura el volumen general
            AudioMixer.SetFloat("VolumeGeneral", sliderGeneral.value * 10);
        }
    }

     public void ToggleMuteSFX (bool mute)
    {
        isMuted = mute;

        if (isMuted)
        {
            AudioMixer.SetFloat("VolumeSFX", -80f);  // Silencia
        }
        else
        {
            // Restaura el volumen general
            AudioMixer.SetFloat("VolumeSFX", sliderGeneral.value * 10);
        }
    }

     public void ToggleMuteMusic (bool mute)
    {
        isMuted = mute;

        if (isMuted)
        {
            AudioMixer.SetFloat("VolumeMusic", -80f);  // Silencia
        }
        else
        {
            // Restaura el volumen general
            AudioMixer.SetFloat("VolumeMusic", sliderGeneral.value * 10);
        }
    }
}