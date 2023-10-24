using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform mainPanel, levelPanel, settingsPanel;
    [SerializeField] ButtonStateHandler buttonStateHandler;
    [SerializeField] Slider BGM_Slider;

    private Vector2 levelPanel_AnchoredPosition;
    private void Start()
    {
        mainPanel.DOAnchorPos(Vector2.zero, 0.25f);
        //Debug.Log("BGM_Manager.instance.volume: " + BGM_Manager.instance.volume);
        BGM_Slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
        BGM_Manager.instance.audioSource.volume = PlayerPrefs.GetFloat("BGM Volume", 0.7f);
    }

    public void LevelPanel_Open()
    {
        mainPanel.DOAnchorPos(new Vector2(-mainPanel.rect.size.x, 0.0f), 0.25f);
        levelPanel.DOAnchorPos(new Vector2(-levelPanel.rect.size.x, 0.0f), 0.25f);
        buttonStateHandler.SetLevelButtons(PlayerPrefs.GetInt("UnlockedLevels", 1));
    }
    public void SettingsPanel_Open()
    {
        mainPanel.DOAnchorPos(new Vector2(mainPanel.rect.size.x, 0.0f), 0.25f);
        settingsPanel.DOAnchorPos(new Vector2(settingsPanel.rect.size.x, 0.0f), 0.25f);
    }
    public void ResetAllPanels()
    {
        mainPanel.DOAnchorPos(Vector2.zero, 0.25f);
        levelPanel.DOAnchorPos(Vector2.zero, 0.25f);
        settingsPanel.DOAnchorPos(Vector2.zero, 0.25f);  
    }
    public void Quit()
    { Application.Quit(); }

    public void SelectLevel(Button button)
    {
        GameManager.instance.LoadLevel(button.name);
        Debug.Log("Clicked button name: " + button.name);
    }

    public void On_SliderChange()
    {
        BGM_Manager.instance.audioSource.volume = BGM_Slider.GetComponent<Slider>().value;
        SaveBGMusic_Setting();
    }

    public void SaveBGMusic_Setting()
    {
        //Debug.Log("SaveBGMusic_Setting");
        PlayerPrefs.SetFloat("BGM Volume", BGM_Slider.GetComponent<Slider>().value);
    }
}
