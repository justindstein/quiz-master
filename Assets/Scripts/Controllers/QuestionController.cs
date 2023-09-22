using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    // TODO should this be provided as a param or should we just grab it programmatically?
    public TextMeshProUGUI QuestionText;

    public QuizStateManager QuizStateManager;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    public void ShowQuestion()
    {
        Debug.Log("ShowQuestion");
        this.QuestionText.text = this.QuizStateManager.GetQuestion();
    }

    public void ShowCorrectAnswerText()
    {
        QuestionText.text = this.CorrectAnswerText.Value;
    }

    // OnIncorrectAnswer
    public void ShowIncorrectAnswerText()
    {
        QuestionText.text = string.Format(this.IncorrectAnswerText.Value, QuizStateManager.GetCorrectAnswer());
    }

    // OnIncorrectAnswer
    public void ShowTimerExpiredText()
    {
        QuestionText.text = string.Format(this.ExpiredTimerText.Value, QuizStateManager.GetCorrectAnswer());
    }
}
