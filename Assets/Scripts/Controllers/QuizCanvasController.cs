using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizCanvasController : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public Question Question;

    public Button[] AnswerButtons;

    public CanvasState CurrentCanvasState;

    public Sprite DefaultAnswerSprite;

    public Sprite CorrectAnswerSprite;

    public QuestionSetManager QuestionSetManager;

    private void Start()
    {
        this.loadNewQuestion(this.Question);
    }

    public void LoadCanvasState(CanvasState canvasState)
    {
        // Load the question into UI
        this.loadQuestion(this.QuestionText, canvasState);

        // Load the answers into UI
        this.loadAnswers(this.AnswerButtons, canvasState);
    }

    private void loadQuestion(TextMeshProUGUI questionText, CanvasState canvasState)
    {
        questionText.text = canvasState.Question;
    }

    private void loadAnswers(Button[] answerButtons, CanvasState canvasState)
    {
        //Debug.Log(string.Format("QuizController.loadAnswers {0} {1}", answerButtons, question));
        int answerButtonsCount = answerButtons.Length;
        int answersCount = canvasState.Answers.Count;

        // Sanity check
        // TODO: Auto-generate buttons to match the number of questions up to 4
        // TODO: Or possibly choose a sub-set if there are too many incorrect answers
        // TODO: Or possibly have multiple correct answers as an array
        if (answerButtonsCount != answersCount)
        {
            Debug.LogWarning(string.Format("QuizController.loadAnswers buttons and answers counts do not match: [answerButtonsCount: {0}] [answersCount: {1}] [canvasState.Question: {2}]", answerButtonsCount, answersCount, canvasState.Question));
            return;
        }

        // TODO rewrite to generate number of buttons to match number of answers up to a certain amount
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = this.DefaultAnswerSprite;

            answerButtons[i].interactable = true;

            TextMeshProUGUI buttonTMP = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonTMP.text = canvasState.Answers[i];
        }

        //Debug.Log(string.Format("QuizController.loadAnswers [answerButtonsCount: {0}] [answersCount: {1}]", answerButtonsCount, answersCount));

        // if number of answers not equal to number of answer buttosn
        // too many -> ignore some
        // too few -> dynamically create number of boxes
    }

    public void OnAnswerSelected(int index)
    {
        // Correct answer
        if (index == CurrentCanvasState.CorrectAnswerIndex)
        {
            QuestionText.text = "Correct!";
            Image answerButtonImage = this.AnswerButtons[index].GetComponent<Image>();
            answerButtonImage.sprite = CorrectAnswerSprite;
        }

        // Incorrect answer
        else
        {
            //Debug.Log(string.Format("{0} vs {1}", textBox.text, CurrentCanvasState.CorrectAnswerIndex));
            QuestionText.text = string.Format("Wrong! Correct answer:\n\"{0}\"", CurrentCanvasState.GetCorrectAnswer());
            Image answerButtonImage = this.AnswerButtons[CurrentCanvasState.CorrectAnswerIndex].GetComponent<Image>();
            answerButtonImage.sprite = CorrectAnswerSprite;
        }

        // Disable buttons
        this.setInteractable(this.AnswerButtons, false);

        // Load new question
        this.loadNewQuestion(this.QuestionSetManager.GetNextQuestion());
    }

    private void setInteractable(Button[] buttons, bool interactable)
    {
        foreach (Button button in buttons)
        {
            button.interactable = interactable;
        }
    }

    private void loadNewQuestion(Question question)
    {
        // Load next question into CurrentCanvasState
        this.CurrentCanvasState.LoadQuestion(question);

        // Load CurrentCanvasState into Canvas
        this.LoadCanvasState(this.CurrentCanvasState);
    }
}