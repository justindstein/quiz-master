using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Click handling for quiz buttons
/// </summary>
public class QuizButtonController : MonoBehaviour
{
    public UnityEvent<Component, QuestionSet> OnQuizStarted;

    private QuestionSet quiz;

    public void OnClick()
    {
        Debug.Log("OnClick");
        this.OnQuizStarted.Invoke(this, this.quiz);
    }

    public void SetQuiz(QuestionSet value)
    {
        this.quiz = value;
    }
}
