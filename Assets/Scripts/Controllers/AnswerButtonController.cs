using UnityEngine;

public class AnswerButtonController : MonoBehaviour
{
    public GameEvent OnCorrectAnswer;

    public GameEvent OnIncorrectAnswer;

    public bool IsCorrect = false;

    public void OnClick()
    {
        if(this.IsCorrect)
        {
            Debug.Log("correct");
            OnCorrectAnswer.Raise();
        } else
        {
            Debug.Log("incorrect");
            OnIncorrectAnswer.Raise();
        }
    }
}
