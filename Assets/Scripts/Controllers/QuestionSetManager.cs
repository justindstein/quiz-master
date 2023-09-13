using System.Collections.Generic;
using UnityEngine;

public class QuestionSetManager : MonoBehaviour
{
    public QuestionSet CurrentQuestionSet;

    private IList<Question> askedQuestions;
    private IList<Question> unaskedQuestions;

    private void Start()
    {
        this.askedQuestions = new List<Question>();
        this.unaskedQuestions = new List<Question>();

        // TODO: this goes away soon
        this.LoadQuestionSet(this.CurrentQuestionSet);
    }

    public void LoadQuestionSet(QuestionSet questionSet)
    {
        this.CurrentQuestionSet = questionSet;

        this.askedQuestions.Clear();

        this.unaskedQuestions = new List<Question>(CurrentQuestionSet.Questions).Shuffle();
    }

    public Question GetNextQuestion()
    {
        Question nextQuestion = this.unaskedQuestions[0];
        this.unaskedQuestions.RemoveAt(0);

        this.askedQuestions.Add(nextQuestion);

        return nextQuestion;
    }
}
