using UnityEngine;

public class CanvasState : ScriptableObject
{
    public string Question;

    public string[] Answers;

    public int CorrectAnswerIndex;

    public void LoadQuestion(Question question)
    {
        this.Question = question.Text;
        string correctAnswer = question.CorrectAnswer;
        this.Answers[0] = "1";
        this.Answers[1] = "1";
        this.Answers[2] = "1";
        this.Answers[3] = "1";
        this.CorrectAnswerIndex = 1;
    }
}
