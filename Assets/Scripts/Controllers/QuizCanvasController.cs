using UnityEngine;
using UnityEngine.Events;
using System;

public class QuizCanvasController : MonoBehaviour
{
    // TODO: revisit ordering of all of these
    public CanvasState CanvasState;

    public QuestionSetManager QuestionSetManager;

    public UnityEvent CorrectAnswer;

    public UnityEvent IncorrectAnswer;

    private void Start()
    {
        this.GetNextQuestion();
    }

    public void AnswerSelected(int index)
    {
        if (index == CanvasState.CorrectAnswerIndex)
        {
            Debug.Log(String.Format("QuizCanvasController.AnswerSelected CorrectAnswer [index {0}]", index));
            this.CorrectAnswer.Invoke();
        }
        else
        {
            Debug.Log(String.Format("QuizCanvasController.AnswerSelected IncorrectAnswer [index {0}]", index));
            this.IncorrectAnswer.Invoke();
        }
    }

    // TODO: this maybe useful, add this to extensions util
    public void InvokeMethod(InvokeParam invokeParam)
    {
        Invoke(invokeParam.MethodName, invokeParam.Time.Value);
    }

    public void GetNextQuestion()
    {
        this.CanvasState.LoadQuestion(this.QuestionSetManager.GetNextQuestion());
    }
}