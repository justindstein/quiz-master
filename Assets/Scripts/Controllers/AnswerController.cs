using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public Button[] AnswerButtons;

    public CanvasState CurrentCanvasState;

    public Sprite DefaultSprite;

    public Sprite CorrectAnswerSprite;

    // OnLoadQuestion
    public void LoadAnswers()
    {
        // Enable buttons
        UIUtil.SetInteractable(this.AnswerButtons, true);

        // Set sprite to default
        UIUtil.SetSprite(this.AnswerButtons, this.DefaultSprite);

        // Set answer button text
        UIUtil.SetText(this.AnswerButtons, this.CurrentCanvasState.Answers);
    }

    // OnCorrectAnswer
    // TODO: rename this
    public void SetCorrectAnswerState()
    {
        this.AnswerButtons[CurrentCanvasState.CorrectAnswerIndex].GetComponent<Image>().sprite = this.CorrectAnswerSprite;

        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);
    }

    // OnIncorrectAnswer
    // TODO: remove this
    public void SetIncorrectAnswerState()
    {
        this.AnswerButtons[CurrentCanvasState.CorrectAnswerIndex].GetComponent<Image>().sprite = this.CorrectAnswerSprite;

        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);
    }
}


