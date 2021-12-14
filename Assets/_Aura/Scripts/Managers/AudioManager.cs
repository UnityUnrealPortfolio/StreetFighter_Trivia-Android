using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField]UIManager m_UIManager;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    #region Singleton Setup
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    var am = new GameObject();
                    instance = am.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    } 
    #endregion

    public void PlayThemeTrack(AudioClip track)
    {
        m_UIManager.DebugInfo("Inside Audio Manager PlayThemeTrack()");
        if(track != null)
        {
            m_UIManager.ToggleLoadingText(false);
            m_AudioSource.clip = track;
            m_AudioSource.Play();
            m_AudioSource.loop = true;
            m_AudioSource.volume = 0.25f;
            m_UIManager.SetSliderValue(m_AudioSource.volume);
        }
        else
        {
            m_UIManager.DebugInfo("Inside Audio Manager Track is null");
        }
    }

    public void SetAudioVolume(float level)
    {
        m_AudioSource.volume = level;
    }
}
