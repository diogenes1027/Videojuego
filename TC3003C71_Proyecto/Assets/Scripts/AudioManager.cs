using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundsPlayer;
    [SerializeField] private AudioClip[] soundsItems;
    private AudioSource audio_;


    private void Awake()
    {
        audio_ = GetComponent<AudioSource>();
    }

    public void AudioSelectPlayer(int clip)
    {

        audio_.Stop();
        audio_.PlayOneShot(soundsPlayer[clip]);
       
    }
}
