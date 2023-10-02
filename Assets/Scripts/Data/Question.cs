using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [TextArea(2, 6)]
    public string QuestionText;

    public string Subject;

    public string Difficulty;

    public string CorrectAnswer;

    public string[] IncorrectAnswers;

    [TextArea(2, 6)]
    public string Explanation;
}
