using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager instance { get; private set; }

    public AudioSource audioSource;
    public float volume { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        //UpdateVolume();
    }

    //public void UpdateVolume()
    //{
    //    volume = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
    //    audioSource.volume = volume;
    //}
}
