using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [TextArea(2, 6)]
    public string Text;

    public string CorrectAnswer;

    public string[] IncorrectAnswers;

    [TextArea(2, 6)]
    public string AnswerExplanation;
}
