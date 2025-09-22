using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    private DialogueController dialogueUI;
    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    public void Start()
    {
        dialogueUI = DialogueController.Instance;
    }


    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        Debug.Log("Interact called. Active? " + isDialogueActive);
        if (dialogueData == null)
            return;

        if (isDialogueActive)
        {
            NextLine();
        }

        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        PauseController.SetPause(true);

        //TypeLine
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            //will auto complete the line instead of typing character by character
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        //if we progress to the next line (+1 to index), is there another line to go through
        else if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            //if there is another line continue typing
            StartCoroutine(TypeLine());
        }
        //no more lines
        else
        {
            //End Dialogue
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            //go through every letter/char
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typeSpeed); //delay typing speed
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length - 1 > dialogueIndex &&
            dialogueData.autoProgressLines.Length > dialogueIndex &&
            dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            //Display next line
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        isTyping = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseController.SetPause(false);
    }
}
