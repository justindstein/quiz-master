using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public CanvasState CurrentCanvasState;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    // OnLoadQuestion
    public void LoadQuestion()
    {
        this.QuestionText.text = this.CurrentCanvasState.Question;
    }

    // OnCorrectAnswer
    public void SetCorrectAnswerState()
    {
        QuestionText.text = this.CorrectAnswerText.Value;
    }

    // OnIncorrectAnswer
    public void SetIncorrectAnswerState()
    {
        QuestionText.text = string.Format(this.IncorrectAnswerText.Value, CurrentCanvasState.GetCorrectAnswer());
    }

    // OnIncorrectAnswer
    public void SetExpiredTimerState()
    {
        QuestionText.text = string.Format(this.ExpiredTimerText.Value, CurrentCanvasState.GetCorrectAnswer());
    }
}
