using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quiz : ScriptableObject
{
    public string Name;

    public Question[] Questions;

    public static Quiz CreateInstance(string quizName, List<Question> questions)
    {
        Quiz quiz = ScriptableObject.CreateInstance<Quiz>();
        quiz.Name = quizName;
        quiz.Questions = new List<Question>(questions).ToArray();
        return quiz;
    }
}
