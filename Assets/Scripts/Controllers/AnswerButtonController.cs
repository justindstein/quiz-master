using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Click handling for answer buttons
/// </summary>
public class AnswerButtonController : MonoBehaviour
{
    public Sprite CorrectAnswerSprite;

    public GameEvent OnCorrectAnswer;

    public GameEvent OnIncorrectAnswer;

    private bool isCorrect;

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

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

    /// <summary>
    /// Highlight this button if this instance corresponds to the correct answer
    /// </summary>
    public void Highlight()
    {
        if (this.isCorrect)
        {
            this.GetComponent<Image>().sprite = this.CorrectAnswerSprite;
        }
    }

    /// <summary>
    /// Disable button so that it no longers responds to clicks
    /// </summary>
    public void Disable()
    {
        this.GetComponent<Button>().interactable = false;
    }

    public void SetIsCorrect(bool value)
    {
        this.isCorrect = value;
    }
}
