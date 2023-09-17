using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    public QuestionSetManager QuestionSetManager;

    public ScoreState ScoreState;

    private void Start()
    {
        this.QuestionSetManager.GetNextQuestion();
        this.ScoreState.QuestionCount = this.QuestionSetManager.CurrentQuestionSet.Questions.Length;
        this.UpdateScore();
    }

    public void IncrementCorrectAnswers()
    {
        this.ScoreState.CorrectAnswers++;
    }

    public void IncrementIncorrectAnswers()
    {
        this.ScoreState.IncorrectAnswers++;
    }

    public void UpdateScore()
    {
        this.ScoreText.text = this.ScoreState.GetScore();
    }
}