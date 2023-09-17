using UnityEngine;
using UnityEngine.Events;
using System;

public class QuizCanvasController : MonoBehaviour
{
    public CanvasState CurrentCanvasState;

    public QuestionSetManager QuestionSetManager;

    public UnityEvent OnLoadQuestion;

    public UnityEvent OnCorrectAnswer;

    public UnityEvent OnIncorrectAnswer;

    private void Start()
    {
        this.OnLoadQuestion.Invoke();
    }

    public void AnswerSelected(int index)
    {
        if (index == CurrentCanvasState.CorrectAnswerIndex)
        {
            Debug.Log(String.Format("QuizCanvasController.AnswerSelected CorrectAnswer [index {0}]", index));
            this.OnCorrectAnswer.Invoke();
        }
        else
        {
            Debug.Log(String.Format("QuizCanvasController.AnswerSelected IncorrectAnswer [index {0}]", index));
            this.OnIncorrectAnswer.Invoke();
        }
    }

    public void InvokeMethod(InvokeParam invokeParam)
    {
        Invoke(invokeParam.MethodName, invokeParam.Time.Value);
    }

    private void InvokeOnloadQuestion()
    {
        this.OnLoadQuestion.Invoke(); // TODO: rename and remove 'On'
    }

    public void GetNextQuestion()
    {
        Question question = this.QuestionSetManager.GetNextQuestion();

        // Load next question into CurrentCanvasState
        this.CurrentCanvasState.LoadQuestion(question);
    }
}