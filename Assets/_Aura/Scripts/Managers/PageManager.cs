using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    [SerializeField] GameObject _quizPage;
    [SerializeField] GameObject _themePage;
    [SerializeField] GameObject _gameOverPage;
    [SerializeField] QuestionUIManager _uiManager;

    private static PageManager instance;
    public static PageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PageManager>();
                if(instance == null)
                {
                    var go = new GameObject();
                    instance = go.AddComponent<PageManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        ToggleThemePage(false);
        _gameOverPage.SetActive(false);
    }
    public void ToggleThemePage(bool toggle)
    {
        if (toggle)
        {
            _themePage.SetActive(true);
            _quizPage.SetActive(false);
        }
        else
        {
            _themePage.SetActive(false);
            _quizPage.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        _gameOverPage.SetActive(false);
        ToggleThemePage(false);
        _uiManager.InitQuestionPage();
        
    }
    public void GameOver()
    {
        _gameOverPage.SetActive(true);
        _quizPage.SetActive(false);
        _themePage.SetActive(false);
    }
}
