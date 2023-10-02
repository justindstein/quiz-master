using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using UnityEditor;
using UnityEngine;

public class DataImporter : MonoBehaviour
{
    private String QuestionImportFilePath = "Assets/Data/Importer/quiz_master_questions.csv";
    private String QuestionExportPath = "Assets/Data/Questions/";

    private void Start()
    {
        int count = 0;
        foreach (QuestionParser question in this.GetQuestions(QuestionImportFilePath))
        {
            // Create so
            ScriptableObject so = this.CreateScriptableObject(question);

            // Verify proper directory exists, create it if it doesn't
            string subjectExportPath = ForceEndsWithSlash(QuestionExportPath) + ((Question)so).Subject.TrimAllWithInplaceCharArray();
            Directory.CreateDirectory(subjectExportPath);

            string filePath = string.Format(subjectExportPath + "/Question{0}.asset", count++);
            this.CreateAsset(so, filePath);
        }
    }

    private IEnumerable<QuestionParser> GetQuestions(string csvFilePath)
    {
        StreamReader reader = new StreamReader(csvFilePath);
        CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<QuestionParser>();
    }

    private ScriptableObject CreateScriptableObject(QuestionParser questionParser)
    {
        Question so = ScriptableObject.CreateInstance<Question>();

        so.QuestionText = questionParser.question;
        so.Subject = questionParser.subject;
        so.Difficulty = questionParser.difficulty;
        so.Explanation = questionParser.explanation;
        so.CorrectAnswer = questionParser.correctAnswer;

        // Remove correct answer from answer list
        HashSet<string> questions = new HashSet<string>() {
            questionParser.firstAnswer
            , questionParser.secondAnswer
            , questionParser.thirdAnswer
            , questionParser.fourthAnswer
        };
        questions.Remove(questionParser.correctAnswer);

        so.IncorrectAnswers = questions.ToArray();

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
}