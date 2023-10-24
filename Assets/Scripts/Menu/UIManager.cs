using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform mainPanel, levelPanel, settingsPanel;
    [SerializeField] ButtonStateHandler buttonStateHandler;

    private Vector2 levelPanel_AnchoredPosition;
    private void Start()
    {
        mainPanel.DOAnchorPos(Vector2.zero, 0.25f);
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
}
