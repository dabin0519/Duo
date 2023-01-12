using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public AudioSource[] audioClips;
    public AudioSource bgmClip;
    public GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void SetBgmVolume(float volume)
    {
        bgmClip.volume = volume;    
    }

    public void SetAudioVolume(float volume)
    {
        for(int i = 0; i < audioClips.Length; i++)
        {
            audioClips[i].volume = volume;
        }
    }
}
