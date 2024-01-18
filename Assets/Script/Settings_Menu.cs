using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Menu : MonoBehaviour
{
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
