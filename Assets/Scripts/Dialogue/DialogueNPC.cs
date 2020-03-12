using System;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [Serializable]
    public class DialogueData
    {
        public string name;
        public Sprite sprite;
        public string[] dialogueLines;
    }

    [SerializeField]
    private DialogueData[] _dialogueData;
    
    // Placeholder way of activating dialogue
    [SerializeField]
    private KeyCode _keyCode;
    
    private void Update()
    {
        // More placeholder to activate the dialogue
        if (Input.GetKeyDown(_keyCode))
        {
            FindObjectOfType<DialogueBox>().StartDialogue(_dialogueData);
        }
    }
}
