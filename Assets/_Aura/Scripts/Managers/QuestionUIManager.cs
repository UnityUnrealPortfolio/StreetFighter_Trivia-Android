using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] _answerButtons;
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] Sprite _defaultAnswerSprite;
    [SerializeField] Sprite _correctAnswerSprite;
    QuestionSO currentQuestionData;

    [SerializeField] int _currentQuestion = 0;
    int CurrentQuestion
    {
        get
        {
            return _currentQuestion;
        }
        set
        {
            _currentQuestion = value;
            if (value >= QuestionManager.Instance.QuestionCount)
            {
                _currentQuestion = 0;
                PageManager.Instance.GameOver();
            }
            ResetQuestions(_currentQuestion);
        }
    }

    public void InitQuestionPage()
    {
        ResetQuestions(0);
    }

    public void ResetQuestions(int index)
    {
        currentQuestionData = QuestionManager.Instance.GetQuestionObject(index);
        _questionText.text = currentQuestionData.GetQuestion();

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestionData.GetAnswer(i);
        }

    }
    public void NextQuestion()
    {
        CurrentQuestion++;
        ResetButtonSprites();
    }

    public void HandleAnswerButtonClicked(int index)
    {
        DisableButtons(false);
        if (index == currentQuestionData.GetCorrectAnswer())
        {
            //handle answer correct
            Handheld.Vibrate();
            AudioManager.Instance.PlayAnswerFX(true);
            _questionText.text = "Correct!";
            _answerButtons[index].GetComponent<Image>().sprite = _correctAnswerSprite;
        }
        else
        {
            AudioManager.Instance.PlayAnswerFX(false);
            _questionText.text = "Wrong. The corect answer is\n " + currentQuestionData.GetAnswer(currentQuestionData.GetCorrectAnswer());
            _answerButtons[currentQuestionData.GetCorrectAnswer()].GetComponent<Image>().sprite = _correctAnswerSprite;
        }
    }

    private void ResetButtonSprites()
    {
        DisableButtons(true);
        foreach (var btn in _answerButtons)
        {
            btn.GetComponent<Image>().sprite = _defaultAnswerSprite;
        }
    }

    private void DisableButtons(bool onOff)
    {
        foreach (var btn in _answerButtons)
        {
            btn.GetComponent<Button>().enabled = onOff;
        }
    }
}
