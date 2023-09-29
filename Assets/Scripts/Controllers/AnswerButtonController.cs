using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Click handling for answer buttons
/// </summary>
public class AnswerButtonController : MonoBehaviour
{
    public Sprite CorrectAnswerSprite;

    public UnityEvent<Component, System.Object> OnCorrectAnswer;

    public UnityEvent<Component, System.Object> OnIncorrectAnswer;

    private Image image;

    private Button button;

    private bool isCorrect;

    private void Awake()
    {
        this.image = this.GetComponent<Image>();
        this.button = this.GetComponent<Button>();
        this.isCorrect = false;
    }

    public void SetIsCorrect(bool value)
    {
        this.isCorrect = value;
    }

    public void OnClick()
    {
        if(this.isCorrect)
        {
            OnCorrectAnswer.Invoke(this, null);
        } else
        {
            OnIncorrectAnswer.Invoke(this, null);
        }
    }

    /// <summary>
    /// Highlight this button if this instance corresponds to the correct answer
    /// </summary>
    public void Highlight()
    {
        if (this.isCorrect)
        {
            this.image.sprite = this.CorrectAnswerSprite;
        }
    }

    /// <summary>
    /// Disable button so that it no longers responds to clicks
    /// </summary>
    public void Disable()
    {
        this.button.interactable = false;
    }
}
