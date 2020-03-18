using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class Language : MonoBehaviour
{
    private static XmlDocument langDoc;

    public enum Lang
    {
        English,
        Dutch,
        Chinese
    }

    private static Lang lang = Lang.English;

    public static UnityEvent LanguageChanged; 

    private void Awake()
    {
        // Load file from resources
        TextAsset lang = Resources.Load<TextAsset>("Language/lang");

        // Setup xml document
        langDoc = new XmlDocument();
        langDoc.PreserveWhitespace = true;
        //langDoc.Load(Path.Combine(Application.streamingAssetsPath, "lang.xml"));
        langDoc.LoadXml(lang.text);

        // Initiate the event
        if (LanguageChanged == null)
            LanguageChanged = new UnityEvent();
    }
    
    /// <summary>
    /// Set the language
    /// </summary>
    /// <param name="newLang">Desired language</param>
    public static void SetLanguage(Lang newLang)
    {
        lang = newLang;

        LanguageChanged.Invoke();
    }

    /// <summary>
    /// Set the language
    /// </summary>
    /// <param name="newLang">Desired language</param>
    public static void SetLanguage(int newLang)
    {
        lang = (Lang)newLang;
        
        LanguageChanged.Invoke();
    }

    /// <summary>
    /// Find a string in the desired language from the lang file
    /// </summary>
    /// <param name="stringName">The name of the string in the lang file</param>
    public static string GetString(string stringName)
    {
        return langDoc.SelectSingleNode("/languages/" + lang.ToString() + "/string[@name='" + stringName + "']").InnerText;
    }
}