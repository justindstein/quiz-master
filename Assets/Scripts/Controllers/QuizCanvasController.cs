using UnityEngine;
using UnityEngine.Events;

public class QuizCanvasController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public UnityEvent<Component, Object> OnLoadQuestion;

    // TODO: will we use this?
    public UnityEvent OnQuizEnded;

    // TODO: is this even necessary?
    public void LoadQuestion()
    {
        this.OnLoadQuestion.Invoke(this, null);
    }
}
