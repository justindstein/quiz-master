using UnityEngine;
using UnityEngine.Events;

public class QuizCanvasController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public UnityEvent<Component, Object> OnLoadQuestion;

    public void LoadQuestion()
    {
        this.OnLoadQuestion.Invoke(this, null);
    }
}
