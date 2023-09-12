using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;

    public Sprite UnselectSprite;

    public Sprite SelectSprite;

    public Question CurrentQuestion;

    public void OnAnswerSelected(int index)
    {
        this.GetComponent<Image>().sprite = SelectSprite;
        TextMeshProUGUI textBox = this.GetComponentInChildren<TextMeshProUGUI>();

        if (textBox.text.Equals(CurrentQuestion.CorrectAnswer))
        {
            QuestionText.text = "Correct!";
        }
        else
        {
            Debug.Log(string.Format("{0} vs {1}", textBox.text, CurrentQuestion.CorrectAnswer));
            Debug.Log("Incorrect!");
        }
    }
}
