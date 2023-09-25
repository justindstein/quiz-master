using UnityEngine;

/// <summary>
/// Click handling for quiz buttons
/// </summary>
public class QuizButtonController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    private QuestionSet quiz;

    public void OnClick()
    {
        this.QuizStateManager.StartQuiz(this.quiz);
    }

    public void SetQuizStateManager(QuizStateManager value)
    {
        this.QuizStateManager = value;
    }

    public void SetQuiz(QuestionSet value)
    {
        this.quiz = value;
    }
}
