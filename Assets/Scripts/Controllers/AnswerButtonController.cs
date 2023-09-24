using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonController : MonoBehaviour
{
    public Sprite CorrectAnswerSprite;

    public GameEvent OnCorrectAnswer;

    public GameEvent OnIncorrectAnswer;

    public bool IsCorrect = false;

    public void OnClick()
    {
        if(this.IsCorrect)
        {
            OnCorrectAnswer.Raise();
        } else
        {
            OnIncorrectAnswer.Raise();
        }
    }

    public void Highlight()
    {
        if (this.IsCorrect)
        {
            this.GetComponent<Image>().sprite = this.CorrectAnswerSprite;
        }
    }

    public void Disable()
    {
        this.GetComponent<Button>().interactable = false;
    }
}
