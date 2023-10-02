public class AnswerEntity
{
    public string Answer;
    public bool IsCorrect;

    public AnswerEntity(string answer, bool isCorrect)
    {
        this.Answer = answer;
        this.IsCorrect = isCorrect;
    }
}