using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CanvasState : ScriptableObject
{
    public string Question;

    public List<string> Answers;

    public int CorrectAnswerIndex;

    public void LoadQuestion(Question question)
    {
        this.Question = question.Text;

        List<string> answers = new List<string>(question.IncorrectAnswers);
        answers.Shuffle();
        this.Answers = answers;

        int correctAnswerIndex = answers.RandomInsert(question.CorrectAnswer);
        this.CorrectAnswerIndex = correctAnswerIndex;
    }

    public string GetCorrectAnswer()
    {
        return this.Answers[this.CorrectAnswerIndex];
    }
}
