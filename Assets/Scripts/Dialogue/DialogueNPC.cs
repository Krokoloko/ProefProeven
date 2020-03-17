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

    public void StartDialogue()
    {
        DialogueBox.Instance.StartDialogue(_dialogueData);
    }
}
