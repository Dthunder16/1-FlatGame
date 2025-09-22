using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance { get; private set; } //Singleton Instincts
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    void Start()
    {
        if (Instance == null) Instance = this;

        else Destroy(gameObject); //Make sure only one instance exists
    }

    public void ShowDialogueUI(bool show)
    {
        dialoguePanel.SetActive(show); //Toggle UI Visibility
    }

    public void SetNPCInfo(string npcName, Sprite portrait)
    {
        nameText.text = npcName;
        portraitImage.sprite = portrait;
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }



}
