using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuizState : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public QuizStateType Value;

    private Dictionary<QuizStateType, HashSet<QuizStateType>> stateTransitions = new Dictionary<QuizStateType, HashSet<QuizStateType>>();

    private void OnEnable()
    {
        Debug.Log("QuizState.OnEnable");
        this.Value = QuizStateType.NONE;

        this.stateTransitions = new Dictionary<QuizStateType, HashSet<QuizStateType>>()
        {
            { QuizStateType.NONE, new HashSet<QuizStateType> { QuizStateType.QUESTION, QuizStateType.ANSWER } },
            { QuizStateType.ANSWER, new HashSet<QuizStateType> { QuizStateType.QUESTION } },
            { QuizStateType.QUESTION, new HashSet<QuizStateType> { QuizStateType.ANSWER } }
        };
    }

    public void SetValue(string value)
    {
        Debug.Log(string.Format("QuizState.SetValue [quizStateType: {0}]", value));
        this.SetValue((QuizStateType)System.Enum.Parse(typeof(QuizStateType), value));
    }

    public void SetValue(QuizStateType value)
    {
        if (this.stateTransitions[this.Value].Contains(value))
        {
            this.Value = value;
        }
        else
        {
            throw new InvalidStateChangeException(String.Format("State change from {0} to {1} not supported.", this.Value, value));
        }
    }

    public bool IsQuestionState()
    {
        return (this.Value == QuizStateType.QUESTION);
    }

    public bool IsAnswerState()
    {
        return (this.Value == QuizStateType.ANSWER);
    }
}

public enum QuizStateType
{
    NONE
    , QUESTION
    , ANSWER
}