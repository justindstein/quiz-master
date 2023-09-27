using UnityEngine;
using UnityEngine.Events;

public class QuizCanvasController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public UnityEvent OnLoadQuestion;

    public UnityEvent OnQuizEnded;

    public void LoadNextQuestion()
    {
        this.QuizStateManager.LoadNextQuestion();
    }

    public void StartQuiz(QuestionSet foo)
    {

    }

    public void LoadQuestion()
    {

    }

}
