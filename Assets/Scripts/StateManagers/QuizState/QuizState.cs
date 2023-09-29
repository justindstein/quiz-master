using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: possibly move to quizstatemanager
public class QuizState
{
    public QuizStateType Value = QuizStateType.NONE;

    private Dictionary<QuizStateType, HashSet<QuizStateType>> stateTransitions = new Dictionary<QuizStateType, HashSet<QuizStateType>>()
        {
            { QuizStateType.NONE, new HashSet<QuizStateType> { QuizStateType.QUESTION, QuizStateType.ANSWER } },
            { QuizStateType.ANSWER, new HashSet<QuizStateType> { QuizStateType.QUESTION } },
            { QuizStateType.QUESTION, new HashSet<QuizStateType> { QuizStateType.ANSWER } }
        };

    public void SetValue(QuizStateType value)
    {
        Debug.Log("SetValue: " + value + " From: " + this.Value);
        if (this.stateTransitions[this.Value].Contains(value))
        {
            this.Value = value;
        }
        else
        {
            throw new InvalidStateChangeException(String.Format("State change from {0} to {1} not supported.", this.Value, value));
        }
    }

    //public bool IsQuestionState()
    //{
    //    return (this.Value == QuizStateType.QUESTION);
    //}

    //public bool IsAnswerState()
    //{
    //    return (this.Value == QuizStateType.ANSWER);
    //}
}

public enum QuizStateType
{
    NONE
    , QUESTION
    , ANSWER
}