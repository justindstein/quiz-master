using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using UnityEngine;
using UnityEditor;

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

        Debug.Log("Parsing Questions...");
        foreach (QuestionParser questionParser in this.GetQuestions(ImportFilePath))
        {
            Question question = Question.CreateInstance(questionParser);

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

        Debug.Log("Creating Quizzes...");
        foreach (KeyValuePair<string, List<Question>> entry in quizzes)
        {
            Quiz quiz = Quiz.CreateInstance(entry.Key, entry.Value);
            string filePath = string.Format(QuizExportPath + "/{0}.asset", entry.Key).TrimAllWithInplaceCharArray();
            this.CreateAsset(quiz, filePath);
            Debug.Log(entry.Key);
        }
    }

    private IEnumerable<QuestionParser> GetQuestions(string csvFilePath)
    {
        StreamReader reader = new StreamReader(csvFilePath);
        CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<QuestionParser>();
    }

    private void CreateAsset(ScriptableObject asset, string filePath)
    {
        AssetDatabase.CreateAsset(asset, filePath);
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