using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    private TextMeshProUGUI questionText;

    private void Awake()
    {
        this.questionText = this.GetComponent<TextMeshProUGUI>();
    }

    public void ShowQuestion()
    {
        this.questionText.text = this.QuizStateManager.GetQuestion();
    }

    public void ShowCorrectAnswerText()
    {
        this.questionText.text = this.CorrectAnswerText.Value;
    }

    public void ShowIncorrectAnswerText()
    {
        this.questionText.text = string.Format(this.IncorrectAnswerText.Value, QuizStateManager.GetCorrectAnswer());
    }

    public void ShowTimerExpiredText()
    {
        this.questionText.text = string.Format(this.ExpiredTimerText.Value, QuizStateManager.GetCorrectAnswer());
    }
}
