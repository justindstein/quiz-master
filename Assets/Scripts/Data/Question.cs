using System.Collections.Generic;
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

    public static Question CreateInstance(QuestionParser questionParser)
    {
        Question question = ScriptableObject.CreateInstance<Question>();

        question.QuestionText = questionParser.question;
        question.Subject = questionParser.subject;
        question.Explanation = questionParser.explanation;
        question.CorrectAnswer = questionParser.answer;

        // Remove correct answer from answer list
        HashSet<string> questions = new HashSet<string>() {
            questionParser.option1
            , questionParser.option2
            , questionParser.option3
        };

        question.IncorrectAnswers = questions.ToArray();
        
        return question;
    }
}