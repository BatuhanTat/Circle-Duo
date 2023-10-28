using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStateHandler : MonoBehaviour
{
    [SerializeField] List<Button> buttonList;

    void Start()
    {
        buttonList.AddRange(GetComponentsInChildren<Button>());
    }

    public void SetLevelButtons(int levelProgress)
    {
        CheckProgress(levelProgress);
    }

    private void CheckProgress(int levelProgress)
    {
        // levelProgress variable starts from 0.
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (i < levelProgress)
            {
                buttonList[i].interactable = true;
            }
            else
            {
                buttonList[i].interactable = false;
            }
        }
    }
}
