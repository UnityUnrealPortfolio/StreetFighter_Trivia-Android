using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ThemeManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject themeDataGO;
    ThemeDataHolder themeDataHolder;
    int themeCount;
    List<Theme> themes = new List<Theme>();

    AsyncOperationHandle<AudioClip> _currentTrackHandle;
    AsyncOperationHandle<Sprite> _imageHandle;
    public List<Theme> Themes
    {
        get { return themes; }
    }

    #region Singleton Setup
    private static ThemeManager instance;
    public static ThemeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ThemeManager>();
                if (instance == null)
                {
                    var tm = new GameObject();
                    instance = tm.AddComponent<ThemeManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        themeDataHolder = themeDataGO.GetComponent<ThemeDataHolder>();
        themeCount = themeDataHolder.ThemesData.GetThemes().Count;
        themes = themeDataHolder.ThemesData.GetThemes();
    }
    private void Start()
    {
        var btnNames = new List<string>();
        for (int i = 0; i < themes.Count; i++)
        {
            btnNames.Add(themes[i].name);
        }
        SetUpButtonPanel(themeCount, btnNames);
    }
    public void SetUpButtonPanel(int count, List<string> names)
    {
        uiManager.SetUpButtonPanel(count, names);
    }

    public void LoadTrackImageData(string tag)
    {
        uiManager.DebugInfo("In Theme Manager.");

        ReleaseAssets();

        foreach (var t in themes)
        {
            if (tag == t.name)
            {
                _currentTrackHandle = Addressables.LoadAssetAsync<AudioClip>(t.themeMusic);
                _imageHandle = Addressables.LoadAssetAsync<Sprite>(t.BackgroundImage);
            }
            else
            {
                uiManager.DebugInfo("Tag doesn't match.");
            }
        }
        if(_imageHandle.IsValid())
        {
          StartCoroutine(ThemeMusic_Completed(_currentTrackHandle, _imageHandle));
        }
        else
        {
            uiManager.DebugInfo("_ImageHandler is not valid.");
        }
    }


    private IEnumerator ThemeMusic_Completed(AsyncOperationHandle<AudioClip> obj,AsyncOperationHandle<Sprite> img)
    {
        uiManager.ToggleLoadingText(true);
        yield return new WaitForSeconds(1f);
 
        var track = obj.Result;
        var pic = img.Result;
        while(pic == null)
        {
            yield return new WaitForSeconds(.1f);
            pic = img.Result;
        }
        while(track == null)
        {
            yield return new WaitForSeconds(.2f);
            track = obj.Result;
        }
        
        AudioManager.Instance.PlayThemeTrack(track);
        uiManager.SetUpBackgroundImage(img.Result);
    }
    private void ReleaseAssets()
    {
        if (_imageHandle.IsValid())
        {
            Addressables.Release(_imageHandle);
        }
        if (_currentTrackHandle.IsValid())
        {

            Addressables.Release(_currentTrackHandle);
        }
    }
    
}
