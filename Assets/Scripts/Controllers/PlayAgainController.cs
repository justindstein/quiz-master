using UnityEngine;

public class PlayAgainController : MonoBehaviour
{
    public GameObject PlayAgainButton;

    public void LoadPlayAgainButton(Component component, System.Object obj)
    {
        // Clear out previous finalscores
        this.DeletePlayAgainButtons(null, null);

        // Instantiate a finalAnswer
        GameObject playAgainButton = InstantiatePlayAgainButton(this.PlayAgainButton);

        // Set its parent to 'Answers' GameObject
        playAgainButton.transform.SetParent(this.transform);
    }

    private GameObject InstantiatePlayAgainButton(GameObject prefab)
    {
        GameObject playAgainButton = Instantiate(prefab);
        return playAgainButton;
    }

    public void DeletePlayAgainButtons(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}