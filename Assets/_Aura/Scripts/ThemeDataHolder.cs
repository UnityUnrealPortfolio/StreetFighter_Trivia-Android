using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeDataHolder : MonoBehaviour
{
    [SerializeField] ThemesSO themesData;
    public ThemesSO ThemesData
    {
        get { return themesData; }
    }
}
