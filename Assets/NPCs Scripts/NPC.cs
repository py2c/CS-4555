﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public Queue<string> sentences;

    private GoblinDialogue goblindialogue;

    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        goblindialogue = new GoblinDialogue();
        goblindialogue.LoadSentences();
        sentences = goblindialogue.GetSentences();
    }

    void Update()
    {
        Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        Pos.y +=500;
        ChatBackGround.position = Pos;
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        goblindialogue = new GoblinDialogue();
        goblindialogue.LoadSentences();
        sentences = goblindialogue.GetSentences();
    }
}
