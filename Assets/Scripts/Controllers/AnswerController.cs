using UnityEngine;
using UnityEngine.UI;

// TODO: Change name to 'AnswerGroup' or similar
// TODO: OnTimerExpired event handling should be merged with 'IncorrectAnswer', something can invoke 'IncorrectAnswer' OnTimerExperired
public class AnswerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public Button[] AnswerButtons;

    public Sprite DefaultSprite;

    public Sprite CorrectAnswerSprite;

    public void LoadAnswers()
    {
        // Enable buttons
        UIUtil.SetInteractable(this.AnswerButtons, true);

        // Set sprite to default
        UIUtil.SetSprite(this.AnswerButtons, this.DefaultSprite);

        // Set answer button text
        // TODO: get off CanvasState
        UIUtil.SetText(this.AnswerButtons, this.QuizStateManager.GetAnswers());
    }

    public void HighlightCorrectAnswer()
    {
        // Disable buttons
        UIUtil.SetInteractable(this.AnswerButtons, false);

        // Highlight correct answer
        this.AnswerButtons[QuizStateManager.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = this.CorrectAnswerSprite;
    }
}


