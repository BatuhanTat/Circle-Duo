using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_UIManager : MonoBehaviour
{
    [SerializeField] GameObject ingameButtons;

    public void Toggle_Pause()
    {
        ingameButtons.SetActive(!ingameButtons.activeSelf);
        Time.timeScale = ingameButtons.activeSelf ? 0.0f : 1.0f;    
    }

    public void MenuButton()
    {
        Time.timeScale = 1.0f;
        GameManager.instance.LoadMenu();
    }
}
