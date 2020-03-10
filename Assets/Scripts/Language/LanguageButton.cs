using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    public void SetLanguage(int lang)
    {
        Language.SetLanguage(lang);
    }
}
