using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: Change name to 'AnswerGroup' or similar
// TODO: OnTimerExpired event handling should be merged with 'IncorrectAnswer', something can invoke 'IncorrectAnswer' OnTimerExperired
public class AnswerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

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
    }

    private GameObject instantiateAnswerButton(GameObject prefab, QuizStateManager.AnswerEntity answer)
    {
        GameObject answerButton = Instantiate(prefab);

        answerButton.GetComponent<AnswerButtonController>().SetIsCorrect(answer.IsCorrect);

        //answerButton.GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    answerButton.GetComponent<AnswerButtonController>().OnClick();
        //});

        answerButton.GetComponentInChildren<TextMeshProUGUI>().SetText(answer.Answer);

        return answerButton;
    }

    public void ClearAnswers()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}