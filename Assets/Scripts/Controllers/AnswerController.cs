using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public Button[] AnswerButtons;

    public CanvasState CanvasState;

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
        foreach (Button button in this.AnswerButtons)
        {
            Debug.Log(string.Format("LoadAnswers.button {0}", button));
        }
        foreach (string answer in this.CanvasState.GetAnswers())
        {
            Debug.Log(string.Format("LoadAnswers.answer {0}", answer));
        }

        UIUtil.SetText(this.AnswerButtons, this.CanvasState.GetAnswers());
    }

    // OnCorrectAnswer
    // TODO: rename this
    public void SetCorrectAnswerState()
    {
        this.AnswerButtons[CanvasState.CorrectAnswerIndex].GetComponent<Image>().sprite = this.CorrectAnswerSprite;

        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);
    }

    // OnIncorrectAnswer
    // TODO: remove this
    public void SetIncorrectAnswerState()
    {
        this.AnswerButtons[CanvasState.CorrectAnswerIndex].GetComponent<Image>().sprite = this.CorrectAnswerSprite;

        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);
    }

    public void SetExpiredAnswerState()
    {
        this.AnswerButtons[CanvasState.CorrectAnswerIndex].GetComponent<Image>().sprite = this.CorrectAnswerSprite;

        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);
    }
}


