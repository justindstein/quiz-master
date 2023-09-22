using System.Collections.Generic;
using UnityEngine;

public class QuestionSetManager : MonoBehaviour
{
    //private QuestionSet questionSet;

    private IList<Question> askedQuestions;

    // TODO: Convert to queue
    private IList<Question> unaskedQuestions;

    private void Awake()
    {
        this.askedQuestions = new List<Question>();
        this.unaskedQuestions = new List<Question>();
    }

    public void LoadQuestionSet(QuestionSet questionSet)
    {
        Debug.Log("QuestionSetManager.LoadQuestionSet");
        // TODO: is questionSet necessary? Possibly
        //this.questionSet = questionSet;

        // TODO: do we need to load the questionSet? just load into the asked and unasked questions
        this.askedQuestions.Clear();

        this.unaskedQuestions.Clear();
        this.unaskedQuestions.AddRange(questionSet.Questions).Shuffle();

        //foreach (Question q in this.unaskedQuestions)
        //{
        //    Debug.Log("LoadQuestionSet -> " + q.name);
        //}
    }

    // TODO: this should be converted to Queue.dequeue()
    public Question GetNextQuestion()
    {
        //foreach (Question q in this.unaskedQuestions)
        //{
        //    Debug.Log("GetNextQuestion -> " + q.name);
        //}

        Question nextQuestion = this.unaskedQuestions[0];
        this.unaskedQuestions.RemoveAt(0);

        this.askedQuestions.Add(nextQuestion);

        return nextQuestion;
    }

    public int GetQuestionCount()
    {
        return this.askedQuestions.Count + this.unaskedQuestions.Count;
    }

    public bool IsQuestionRemaining()
    {
        //foreach (Question q in this.unaskedQuestions)
        //{
        //    Debug.Log("IsQuestionRemaining -> " + q.name);
        //}

        return (this.unaskedQuestions.Count > 0);
    }
}
