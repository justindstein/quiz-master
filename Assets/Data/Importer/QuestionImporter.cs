using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using UnityEditor;
using UnityEngine;

public class DataImporter : MonoBehaviour
{
    public String ImportFilePath = "Assets/Data/Importer/quiz_master_questions.csv";
    public String QuestionExportPath = "Assets/Data/Questions/";
    public String QuizExportPath = "Assets/Data/Quizzes/";

    private void Start()
    {
        Directory.CreateDirectory(QuestionExportPath);
        Directory.CreateDirectory(QuizExportPath);

        ClearDirectory(QuestionExportPath);
        ClearDirectory(QuizExportPath);

        Dictionary<string, List<Question>> quizzes = new Dictionary<string, List<Question>>();

        int count = 0;
        foreach (QuestionParser rawQuestion in this.GetQuestions(ImportFilePath))
        {
            // Create so
            Question question = this.CreateQuestionSO(rawQuestion);

            // Associate question with quiz
            if (quizzes.ContainsKey(question.Subject))
            {
                quizzes.GetValueOrDefault(question.Subject).Add(question);
            }
            else
            {
                quizzes.Add(question.Subject, new List<Question>());
            }

            // Verify proper directory exists, create it if it doesn't
            string subjectExportPath = ForceEndsWithSlash(QuestionExportPath) + ((Question)question).Subject.TrimAllWithInplaceCharArray();
            Directory.CreateDirectory(subjectExportPath);

            string filePath = string.Format(subjectExportPath + "/Question{0}.asset", count++);
            this.CreateAsset(question, filePath);
        }

        Debug.Log("Creating Quizzes");
        foreach (KeyValuePair<string, List<Question>> entry in quizzes)
        {
            var quizName = entry.Key;
            var questions = entry.Value;
            Debug.Log("key: " + quizName + " value: " + questions);

            Quiz quiz = CreateQuizSO(quizName, questions);

            string filePath = string.Format(QuizExportPath + "/{0}.asset", entry.Key).TrimAllWithInplaceCharArray();
            this.CreateAsset(quiz, filePath);
        }
    }

    private IEnumerable<QuestionParser> GetQuestions(string csvFilePath)
    {
        StreamReader reader = new StreamReader(csvFilePath);
        CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<QuestionParser>();
    }

    private Question CreateQuestionSO(QuestionParser questionParser)
    {
        Question so = ScriptableObject.CreateInstance<Question>();

        so.QuestionText = questionParser.question;
        so.Subject = questionParser.subject;
        so.Explanation = questionParser.explanation;
        so.CorrectAnswer = questionParser.answer;

        // Remove correct answer from answer list
        HashSet<string> questions = new HashSet<string>() {
            questionParser.option1
            , questionParser.option2
            , questionParser.option3
            , questionParser.option4
        };
        questions.Remove(questionParser.answer);

        so.IncorrectAnswers = questions.ToArray();

        return so;
    }

    private Quiz CreateQuizSO(string quizName, List<Question> questions)
    {
        Quiz so = ScriptableObject.CreateInstance<Quiz>();

        so.Name = quizName;

        so.Questions = new List<Question>(questions).ToArray();

        return so;
    }

    private void CreateAsset(ScriptableObject so, string filePath)
    {
        AssetDatabase.CreateAsset(so, filePath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private string ForceEndsWithSlash(string path)
    {
        return path + ((path.EndsWith("/")) ? "" : "/");
    }

    private void ClearDirectory(string directoryPath)
    {
        System.IO.DirectoryInfo di = new DirectoryInfo(directoryPath);

        foreach (FileInfo file in di.EnumerateFiles())
        {
            file.Delete();
        }

        foreach (DirectoryInfo dir in di.EnumerateDirectories())
        {
            dir.Delete(true);
        }
    }
}