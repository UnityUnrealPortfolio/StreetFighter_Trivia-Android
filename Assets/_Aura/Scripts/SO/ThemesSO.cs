using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName ="themesList",menuName ="Themes")]
public class ThemesSO : ScriptableObject
{
   [SerializeField]List<Theme> themes = new List<Theme>();

    public string GetThemeName(int index)
    {
        return themes[index].name;
    }
    public AssetReference GetBackgroundImageRef(int index)
    {
        return themes[index].BackgroundImage;
    }

    public AssetReference GetThemeMusicRef(int index)
    {
        return themes[index].themeMusic;
    }

    public List<Theme> GetThemes()
    {
        return themes;
    }
}
