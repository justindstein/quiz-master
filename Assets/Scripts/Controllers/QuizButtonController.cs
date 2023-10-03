using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Click handling for quiz buttons
/// </summary>
public class QuizButtonController : MonoBehaviour
{
    public UnityEvent<Component, Quiz> OnQuizStarted;

    private Quiz quiz;

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

    public void OnClick()
    {
        Debug.Log(string.Format("Button clicked: [quizName {0}]", this.quiz.Name));
        this.OnQuizStarted.Invoke(this, this.quiz);
    }

    public void SetQuiz(Quiz value)
    {
        this.quiz = value;
    }
}
