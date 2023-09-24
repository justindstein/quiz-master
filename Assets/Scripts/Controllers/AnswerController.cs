using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: Change name to 'AnswerGroup' or similar
// TODO: OnTimerExpired event handling should be merged with 'IncorrectAnswer', something can invoke 'IncorrectAnswer' OnTimerExperired
public class AnswerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    //public Button[] AnswerButtons;

    public Sprite DefaultSprite;

    public Sprite CorrectAnswerSprite;

    public GameObject AnswerButtonPrefab;

    public void LoadAnswers()
    {
        foreach (QuizStateManager.AnswerEntity answer in this.QuizStateManager.GetAnswerEntities())
        {
            // Instantiate a button
            GameObject answerButton = instantiateAnswerButton(this.AnswerButtonPrefab, answer);

            // Set its parent to 'Answers' GameObject
            answerButton.transform.SetParent(this.transform);
        }

        // Enable buttons
        //UIUtil.SetInteractable(this.AnswerButtons, true);

        // Set sprite to default
        // UIUtil.SetSprite(this.AnswerButtons, this.DefaultSprite);

        // Set answer button text
        //UIUtil.SetText(this.AnswerButtons, this.QuizStateManager.GetAnswers());
    }

    private GameObject instantiateAnswerButton(GameObject prefab, QuizStateManager.AnswerEntity answer)
    {
        GameObject answerButton = Instantiate(prefab);

        answerButton.GetComponent<AnswerButtonController>().IsCorrect = answer.IsCorrect;

        answerButton.GetComponent<Button>().onClick.AddListener(() => { answerButton.GetComponent<AnswerButtonController>().OnClick(); }); // TODO: cleanup
        answerButton.GetComponentInChildren<TextMeshProUGUI>().SetText(answer.Answer);

        return answerButton;
    }

    public void ClearAnswers()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i));
        }
    }

    // This could potentially go inside each button, but it's a bit complex to so maybe not.
    //public void HighlightCorrectAnswer()
    //{
    //    // Disable buttons
    //    UIUtil.SetInteractable(this.AnswerButtons, false);

    //    // Highlight correct answer
    //    this.AnswerButtons[QuizStateManager.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = this.CorrectAnswerSprite;
    //}

    public void HighlightCorrectAnswer()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            this.transform.GetChild(i).GetComponent<Button>().interactable = false;

            if (this.transform.GetChild(i).GetComponent<AnswerButtonController>().IsCorrect)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = this.CorrectAnswerSprite;
            }
        }
    }

    //public UnityEvent CorrectAnswer;

    //public UnityEvent IncorrectAnswer;

    //public void AnswerSelected(int index)
    //{
    //    if (index == QuizStateManager.GetCorrectAnswerIndex())
    //    {
    //        Debug.Log(String.Format("QuizCanvasController.AnswerSelected CorrectAnswer [index {0}]", index));
    //        this.CorrectAnswer.Invoke();
    //    }
    //    else
    //    {
    //        Debug.Log(String.Format("QuizCanvasController.AnswerSelected IncorrectAnswer [index {0}]", index));
    //        this.IncorrectAnswer.Invoke();
    //    }
    //}
}