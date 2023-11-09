using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject InstructionsTextPrefab;

    public void Awake()
    {
        this.LoadInstructions(null, null);
    }

    /// <summary>
    /// Load a collection of quizzes into 'Quizzes' layout group
    /// </summary>
    public void LoadInstructions(Component component, System.Object obj)
    {
        Debug.Log("LoadInstructions");

        // Instantiate instructions
        GameObject instructionsText = Instantiate(InstructionsTextPrefab);

        Debug.Log("InstructionsController.LoadInstructions");

        // Set its parent to 'Instructions' GameObject
        instructionsText.transform.SetParent(this.transform);
    }

    public void DestroyInstructions(Component component, System.Object obj)
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            Debug.Log("Destroying " + this.transform.GetChild(i).gameObject.name);
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
}
