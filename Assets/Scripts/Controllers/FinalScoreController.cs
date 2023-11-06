using TMPro;
using UnityEngine;

public class FinalScoreController : MonoBehaviour
{
    public GameObject FinalScorePrefab;

    public StringVariable FinalScoreText;

    public IntVariable QuizCorrectAnswerCount;

    public IntVariable QuizAnswerCount;

    public IntVariable LifetimeCorrectAnswerCount;

    public IntVariable LifetimeAnswerCount;
    public void LoadFinalScore(Component component, System.Object obj)
    {
        // Clear out previous finalscores
        this.DeleteFinalScores(null, null);

        // Instantiate a finalAnswer
        GameObject finalAnswer = InstantiateFinalScore(this.FinalScorePrefab);

        // Set its parent to 'Answers' GameObject
        finalAnswer.transform.SetParent(this.transform);
    }

    private GameObject InstantiateFinalScore(GameObject prefab)
    {
        GameObject finalScore = Instantiate(prefab);

        finalScore.GetComponent<TextMeshProUGUI>()
            .SetText(this.GetFinalScoreMessage(
                this.FinalScoreText.Value
                , this.QuizCorrectAnswerCount.Value
                , this.QuizAnswerCount.Value
                , this.LifetimeCorrectAnswerCount.Value
                , this.LifetimeAnswerCount.Value
        ));

        return finalScore;
    }

    private string GetFinalScoreMessage(string finalScoreText, int quizCorrectAnswerCount, int quizAnswerCount, int lifetimeCorrectAnswerCount, int lifetimeAnswerCount)
    {
        return string.Format(finalScoreText
            , quizCorrectAnswerCount
            , quizAnswerCount
            , "\n"
            , lifetimeCorrectAnswerCount
            , lifetimeAnswerCount
        );
    }

    public void DeleteFinalScores(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
