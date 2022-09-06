using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource audio_;
    [SerializeField] private AudioClip[] sonidos;
    private void Awake()
    {
        audio_ = GetComponent<AudioSource>();

    }

    public void AudioSelect(int clip, float volume)
    {
        audio_.Stop();
        audio_.PlayOneShot(sonidos[clip], volume);
    }
}
