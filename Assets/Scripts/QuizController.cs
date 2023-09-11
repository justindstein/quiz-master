using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class QuizController : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public Question Question;

    public Button[] AnswerButtons;

    void Start()
    {
        // Load the question into UI
        this.loadQuestion(this.QuestionText, this.Question);

        // Load the answers into UI
        this.loadAnswers(this.AnswerButtons, this.Question);
    }

    private void loadQuestion(TextMeshProUGUI questionText, Question question)
    {
        questionText.text = question.Text;
    }

    private void loadAnswers(Button[] answerButtons, Question question)
    {
        //Debug.Log(string.Format("QuizController.loadAnswers {0} {1}", answerButtons, question));
        int answerButtonsCount = answerButtons.Length;
        int answersCount = question.IncorrectAnswers.Length + 1;

        List<string> answers = createRandomizedAnswersList(question);

        // Sanity check
        // TODO: Auto-generate buttons to match the number of questions up to 4
        // TODO: Or possibly choose a sub-set if there are too many incorrect answers
        // TODO: Or possibly have multiple correct answers as an array
        if (answerButtonsCount != answersCount)
        {
            Debug.LogWarning(string.Format("QuizController.loadAnswers buttons and answers counts do not match: [answerButtonsCount: {0}] [answersCount: {1}] [question: {2}]", answerButtonsCount, answersCount, question.Text));
            return;
        }

        for (int i=0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI textMeshPro = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = answers[i];
        }

        //Debug.Log(string.Format("QuizController.loadAnswers [answerButtonsCount: {0}] [answersCount: {1}]", answerButtonsCount, answersCount));

        // if number of answers not equal to number of answer buttosn
        // too many -> ignore some
        // too few -> dynamically create number of boxes
    }

    private List<string> createRandomizedAnswersList(Question question)
    {
        List<string> answers = new List<string>(question.IncorrectAnswers)
        {
            question.CorrectAnswer
        };
        answers.Shuffle();
        return answers;
    }
}