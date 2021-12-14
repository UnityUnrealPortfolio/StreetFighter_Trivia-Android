using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDataHolder : MonoBehaviour
{
  
    [SerializeField] List<QuestionSO> _questionObjects;

    public List<QuestionSO> GetQuestionObjects()
    {
        return _questionObjects;
    }


}
