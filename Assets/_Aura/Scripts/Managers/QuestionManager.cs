using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject _questionDataObject;
    [SerializeField] QuestionUIManager _questionUIManager;
    List<QuestionSO> _questions = new List<QuestionSO>();
    int _questionCount = 0;
    public int QuestionCount
    {
        get { return _questionCount; }
    }

    #region Singleton Setup
    private static QuestionManager instance;
    public static QuestionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestionManager>();
                if (instance == null)
                {
                    var go = new GameObject();
                    instance = go.AddComponent<QuestionManager>();
                }
            }
            return instance;
        }
    } 
    #endregion

    private void Awake()
    {
         _questions = _questionDataObject.GetComponent<QuestionDataHolder>().GetQuestionObjects();
        _questionCount = _questions.Count;     
    }
    private void Start()
    {
        _questionUIManager.InitQuestionPage();
    }
    public QuestionSO GetQuestionObject(int index)
    {
        return _questions[index];
    }

}
