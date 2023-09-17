using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public CanvasState CurrentCanvasState;

    public string CorrectAnswerText = "Correct!";

    public string IncorrectAnswerText = "Wrong! Correct answer:\n\"{0}\"";

    // OnLoadQuestion
    public void LoadQuestion()
    {
        this.QuestionText.text = this.CurrentCanvasState.Question;
    }

    // OnCorrectAnswer
    public void SetCorrectAnswerState()
    {
        QuestionText.text = this.CorrectAnswerText;
    }

    // OnIncorrectAnswer
    public void SetIncorrectAnswerState()
    {
        QuestionText.text = string.Format(this.IncorrectAnswerText, CurrentCanvasState.GetCorrectAnswer());
    }
}
