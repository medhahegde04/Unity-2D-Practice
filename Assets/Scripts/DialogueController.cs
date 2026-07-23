using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject dialoguePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Turns the dialogue panel off automatically at the start of the game
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void ShowDialogueBox()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(true);
    }

    public void HideDialogueBox()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
    }
}
