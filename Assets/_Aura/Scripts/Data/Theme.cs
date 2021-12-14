using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.AddressableAssets;



/// <summary>
/// Defines the concept of a street fighter theme
/// which comprises a background image and a audiotrack
/// both stored offline
/// </summary>

[Serializable]
public class Theme
{
    public string name;
    public AssetReference BackgroundImage;
    public AssetReference themeMusic;
   
}
