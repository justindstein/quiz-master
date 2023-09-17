using UnityEngine;
using UnityEngine.Events;
using System;

public class QuizCanvasController : MonoBehaviour
{
    public CanvasState CurrentCanvasState;

    public QuestionSetManager QuestionSetManager;

    public UnityEvent LoadQuestion;

    public UnityEvent CorrectAnswer;

    public UnityEvent IncorrectAnswer;

    private void Start()
    {
        this.LoadQuestion.Invoke();
    }

    public void AnswerSelected(int index)
    {
        if (index == CurrentCanvasState.CorrectAnswerIndex)
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

    public void InvokeMethod(InvokeParam invokeParam)
    {
        Invoke(invokeParam.MethodName, invokeParam.Time.Value);
    }

    private void InvokeOnloadQuestion()
    {
        this.LoadQuestion.Invoke();
    }

    public void GetNextQuestion()
    {
        Question question = this.QuestionSetManager.GetNextQuestion();

        // Load next question into CurrentCanvasState
        this.CurrentCanvasState.LoadQuestion(question);
    }
}