using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    // TODO should this be provided as a param or should we just grab it programmatically?
    public TextMeshProUGUI QuestionText;

    public CanvasState CanvasState;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    // OnLoadQuestion
    public void LoadQuestion()
    {
        this.QuestionText.text = this.CanvasState.GetQuestion();
    }

    // OnCorrectAnswer
    public void SetCorrectAnswerState()
    {
        QuestionText.text = this.CorrectAnswerText.Value;
    }

    // OnIncorrectAnswer
    public void SetIncorrectAnswerState()
    {
        QuestionText.text = string.Format(this.IncorrectAnswerText.Value, CanvasState.GetCorrectAnswer());
    }

    // OnIncorrectAnswer
    public void SetExpiredTimerState()
    {
        QuestionText.text = string.Format(this.ExpiredTimerText.Value, CanvasState.GetCorrectAnswer());
    }
}
