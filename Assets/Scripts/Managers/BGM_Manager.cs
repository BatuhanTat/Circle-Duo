using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager instance { get; private set; }

    [SerializeField] public Slider slider;

    private AudioSource audioSource;
    private float volume;

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
        SetVolume();
    }

    public void On_SliderChange()
    {
        audioSource.volume = slider.GetComponent<Slider>().value;
        SaveBGMusic_Setting();
    }

    public void SaveBGMusic_Setting()
    {
        PlayerPrefs.SetFloat("BGM Volume", slider.GetComponent<Slider>().value);
    }
    private void SetVolume()
    {
        volume = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        audioSource.volume = volume;
        slider.GetComponent<Slider>().value = volume;
    }
}
