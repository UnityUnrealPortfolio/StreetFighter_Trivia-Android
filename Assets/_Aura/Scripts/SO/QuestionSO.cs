using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="newQuestion",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)] 
    [SerializeField] string _question;
    [SerializeField] string[] _answers;

    [Range(0,3)]
    [SerializeField] int _correctAnswer;

    public string GetQuestion()
    {
        return _question;
    }

    public string GetAnswer(int index)
    {
        return _answers[index];
    }

    public int GetCorrectAnswer()
    {
        return _correctAnswer;
    }
}
