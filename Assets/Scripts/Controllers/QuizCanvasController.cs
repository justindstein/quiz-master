using UnityEngine;
using UnityEngine.Events;
using System;

public class QuizCanvasController : MonoBehaviour
{
    // TODO: revisit ordering of all of these
    public QuizStateManager QuizStateManager;

    public UnityEvent CorrectAnswer;

    public UnityEvent IncorrectAnswer;

    public void AnswerSelected(int index)
    {
        if (index == QuizStateManager.GetCorrectAnswerIndex())
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
}