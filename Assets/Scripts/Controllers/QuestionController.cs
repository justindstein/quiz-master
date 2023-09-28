using TMPro;
using UnityEngine;

using static QuizStateManager;

public class QuestionController : MonoBehaviour
{
    public StringVariable CorrectAnswerText;

    public StringVariable IncorrectAnswerText;

    public StringVariable ExpiredTimerText;

    private TextMeshProUGUI questionText;

    private void Awake()
    {
        this.questionText = this.GetComponent<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        this.questionText.text = "";
    }

    public void ShowQuestion(Component component, System.Object obj)
    {
        if (typeof(QuestionPresentation).IsInstanceOfType(obj))
        {
            QuestionPresentation questionPresentation = (QuestionPresentation)obj;

            this.questionText.text = questionPresentation.Question;
        }
    }

    public void ShowCorrectAnswerText(Component component, System.Object obj)
    {
        this.questionText.text = this.CorrectAnswerText.Value;
    }

    public void ShowIncorrectAnswerText(Component component, System.Object obj)
    {
        if (typeof(QuestionPresentation).IsInstanceOfType(obj))
        {
            QuestionPresentation questionPresentation = (QuestionPresentation)obj;

            this.questionText.text = string.Format(this.IncorrectAnswerText.Value, questionPresentation.Answers[questionPresentation.CorrectAnswerIndex]);
        }
    }

    public void ShowTimerExpiredText(Component component, System.Object obj)
    {
        if (typeof(QuestionPresentation).IsInstanceOfType(obj))
        {
            QuestionPresentation questionPresentation = (QuestionPresentation)obj;

            this.questionText.text = string.Format(this.ExpiredTimerText.Value, questionPresentation.Answers[questionPresentation.CorrectAnswerIndex]);
        }
    }
}
