using TMPro;
using UnityEngine;
using static QuizStateManager;

// TODO: Change name to 'AnswerGroup' or similar
// TODO: OnTimerExpired event handling should be merged with 'IncorrectAnswer', something can invoke 'IncorrectAnswer' OnTimerExperired
public class AnswerController : MonoBehaviour
{
    public QuizStateManager QuizStateManager;

    public GameObject AnswerButtonPrefab;

    // TODO: shift typeof logic into a util
    public void LoadAnswers(Component component, System.Object obj)
    {
        if (typeof(QuestionPresentation).IsInstanceOfType(obj))
        {
            QuestionPresentation questionPresentation = (QuestionPresentation)obj;

            // Clear out previous answers
            this.DeleteAnswers();

            foreach (QuizStateManager.AnswerEntity answer in questionPresentation.AnswerEntities)
            {
                // Instantiate a button
                GameObject answerButton = instantiateAnswerButton(this.AnswerButtonPrefab, answer);

                // Set its parent to 'Answers' GameObject
                answerButton.transform.SetParent(this.transform);
            }
        }
    }

    /// <summary>
    /// Instantiates a new answer button
    /// </summary>
    /// <param name="prefab">The prefab to instantiate</param>
    /// <param name="answer">The associated answer</param>
    /// <returns>Instantiated button gameobject</returns>
    private GameObject instantiateAnswerButton(GameObject prefab, QuizStateManager.AnswerEntity answer)
    {
        GameObject answerButton = Instantiate(prefab);

        answerButton.GetComponent<AnswerButtonController>().SetIsCorrect(answer.IsCorrect);

        answerButton.GetComponentInChildren<TextMeshProUGUI>().SetText(answer.Answer);

        return answerButton;
    }

    public void DeleteAnswers()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}