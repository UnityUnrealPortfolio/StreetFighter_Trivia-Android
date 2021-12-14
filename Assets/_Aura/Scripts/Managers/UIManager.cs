using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject buttonPanel;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Image backgroundImage;
    [SerializeField] GameObject loadingText;
    [SerializeField] TextMeshProUGUI debugInfoText;
    [SerializeField] Slider m_VolSlider;

    List<Button> buttonList;
    private void Awake()
    {
        buttonList = new List<Button>();
        ToggleLoadingText(false);
    }

    public void SetUpButtonPanel(int buttonCount,List<string> btnNames)
    {
        if(btnNames.Count < 1)
        {
            return;
        }
        foreach(string btnName in btnNames)
        {
            var go = Instantiate(buttonPrefab);
            var btn = go.GetComponent<Button>();
            var txt = btn.GetComponentInChildren<TextMeshProUGUI>();
            txt.text = btnName;
            btn.transform.SetParent(buttonPanel.transform, false);
            buttonList.Add(btn);
            btn.tag = btnName;
        }
            SetUpButtonListeners();
    }

    private void SetUpButtonListeners()
    {
        foreach(var btn in buttonList)
        {
            btn.onClick.AddListener(() =>
            {
                LoadTrackAndImage(btn.tag);
            });
        }
    }

    private void LoadTrackAndImage(string tag)
    {
        ThemeManager.Instance.LoadTrackImageData(tag);
    }

   public void ExitGame()
    {
        Application.Quit();
    }

    public void SetUpBackgroundImage(Sprite img)
    {
        backgroundImage.sprite = img;
    }

    public void DebugInfo(string info)
    {
        debugInfoText.text = info;
    }

    public void ToggleLoadingText(bool onOff)
    {
        loadingText.SetActive(onOff);
    }

    public void SetSliderValue(float val)
    {
        m_VolSlider.value = val;
        AudioManager.Instance.SetAudioVolume(m_VolSlider.value);
    }
}
