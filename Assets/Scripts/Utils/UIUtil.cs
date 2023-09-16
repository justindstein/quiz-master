using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public static class UIUtil
{
    public static void SetInteractable(IList<Button> buttons, bool interactable)
    {
        foreach (Button button in buttons)
        {
            button.interactable = interactable;
        }
    }

    public static void SetSprite(IList<Button> buttons, Sprite sprite)
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().sprite = sprite;
        }
    }

    public static void SetText(IList<Button> buttons, IList<string> texts)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            TextMeshProUGUI buttonTMP = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTMP.text = texts[i];
        }
    }
}
