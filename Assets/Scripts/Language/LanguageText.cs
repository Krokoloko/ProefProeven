using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    private Text text;

    [SerializeField]
    private string stringName;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        TranslateText();

        Language.LanguageChanged.AddListener(TranslateText);
    }

    private void TranslateText()
    {
        text.text = Language.GetString(stringName);
    }
}