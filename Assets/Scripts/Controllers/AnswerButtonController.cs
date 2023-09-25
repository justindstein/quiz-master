using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Click handling for answer buttons.
/// </summary>
public class AnswerButtonController : MonoBehaviour
{
    public Sprite CorrectAnswerSprite;

    public GameEvent OnCorrectAnswer;

    public GameEvent OnIncorrectAnswer;

    private bool isCorrect;

    public void OnClick()
    {
        if(this.isCorrect)
        {
            OnCorrectAnswer.Raise();
        } else
        {
            OnIncorrectAnswer.Raise();
        }
    }

    public void Highlight()
    {
        if (this.isCorrect)
        {
            this.GetComponent<Image>().sprite = this.CorrectAnswerSprite;
        }
    }

    public void Disable()
    {
        this.GetComponent<Button>().interactable = false;
    }

    public void SetIsCorrect(bool value)
    {
        this.isCorrect = value;
    }
}
