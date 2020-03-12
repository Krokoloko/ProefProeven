using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject _dialogueBox;
    [SerializeField]
    private Image _npcImage;
    [SerializeField]
    private Text _dialogueText;

    private DialogueNPC.DialogueData[] _currentData;
    private int _currentDataIndex;
    private int _currentLineIndex;

    [SerializeField]
    private float _textWriterSpeed = 0.1f;
    private bool _doneWriting;

    private bool _inDialogue;

    private void Update()
    {
        // Go to the next line or skip writing the line when the mouse button is clicked
        if (Input.GetMouseButtonDown(0) && _inDialogue)
        {
            if (_doneWriting)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();

                _dialogueText.text =
                    Language.GetString(_currentData[_currentDataIndex].dialogueLines[_currentLineIndex]);

                _doneWriting = true;
            }
        }
    }

    /// <summary>
    /// Start dialogue
    /// </summary>
    /// <param name="dialogueLines">Line names as defined in lang.xml</param>
    public void StartDialogue(DialogueNPC.DialogueData[] dialogueData)
    {
        if (!_inDialogue)
        {
            _inDialogue = true;

            // Reset the index of the line and the data
            _currentLineIndex = 0;
            _currentDataIndex = 0;

            _currentData = dialogueData;

            _npcImage.sprite = _currentData[_currentDataIndex].sprite;

            _dialogueBox.SetActive(true);

            StartCoroutine(WriteText());
        }
        else
        {
            Debug.LogWarning("Can't start a new dialogue when already in one");
        }
    }

    private void NextLine()
    {
        // Check if there is more lines or more data, if not end the dialogue
        if (_currentLineIndex >= _currentData[_currentDataIndex].dialogueLines.Length - 1)
        {
            if (_currentDataIndex >= _currentData.Length - 1)
            {
                EndDialogue();
                return;
            }

            _currentDataIndex++;
            _npcImage.sprite = _currentData[_currentDataIndex].sprite;
            _currentLineIndex = 0;
        }
        else
        {
            _currentLineIndex++;
        }

        StartCoroutine(WriteText());
    }

    private void EndDialogue()
    {
        _inDialogue = false;

        _dialogueBox.SetActive(false);
    }

    // Slowly write out the text
    private IEnumerator WriteText()
    {
        _doneWriting = false;

        string textToWrite = Language.GetString(_currentData[_currentDataIndex].dialogueLines[_currentLineIndex]);

        for (int i = 0; i < textToWrite.Length + 1; i++)
        {
            _dialogueText.text = textToWrite.Substring(0, i);
            yield return new WaitForSeconds(_textWriterSpeed);
        }

        _doneWriting = true;
    }
}