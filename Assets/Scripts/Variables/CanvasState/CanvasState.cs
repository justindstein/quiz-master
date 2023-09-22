using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CanvasState : ScriptableObject
{
    private string Question;

    private List<string> Answers;

    public int CorrectAnswerIndex;

    // Reset values as ScripableObject.Awake does not run as expected:
    // https://forum.unity.com/threads/solved-but-unhappy-scriptableobject-awake-never-execute.488468/
    private void OnEnable()
    {
        //Debug.Log("CanvasState.OnEnable");
        this.Question = null;
        this.Answers = null;
        this.CorrectAnswerIndex = 0;
    }

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

    // TODO: is this really needed?
    public string GetQuestion()
    {
        return this.Question;
    }

    public IList<string> GetAnswers()
    {
        return this.Answers;
    }

}
