using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizStateManager : MonoBehaviour
{
    public UnityEvent<Component, System.Object> OnQuizLoaded;

    public UnityEvent<Component, QuestionEntity> OnQuestionLoaded;

    public UnityEvent<Component, System.Object> OnQuizFinished;

    private readonly IList<Question> askedQuestions = new List<Question>();

    private readonly Queue<Question> unaskedQuestions = new Queue<Question>();

    private void OnDisable()
    {
        this.askedQuestions.Clear();
        this.unaskedQuestions.Clear();
    }

    /// <summary>
    /// Loads the quiz.
    /// </summary>
    /// <param name="component"></param>
    /// <param name="obj"></param>
    public void SetQuiz(Component component, System.Object obj)
    {
        if (obj is Quiz quiz)
        {
            this.askedQuestions.Clear();

            this.unaskedQuestions.Clear();
            this.unaskedQuestions.AddRange(((IList<Question>)new List<Question>())
                .AddRange(quiz.Questions)
                .Shuffle()
            );

            OnQuizLoaded.Invoke(this, quiz);
        }
    }

    public void LoadQuestion()
    {
        if (this.unaskedQuestions.Count > 0)
        {
            Question nextQuestion = this.unaskedQuestions.Dequeue();
            this.askedQuestions.Add(nextQuestion);
            this.OnQuestionLoaded.Invoke(this, new QuestionEntity(nextQuestion));
        }
        else
        {
            this.OnQuizFinished.Invoke(this, null);
        }
    }
}