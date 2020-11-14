using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDialogue
{
    private Queue<string> sentences = new Queue<string>();

    public void LoadSentences(){
        sentences.Enqueue("Hello Stranger, my name is Bjorn");
        sentences.Enqueue("What brings you here?");
        sentences.Enqueue("Goodbye, Mr. Knight");
    }

    public Queue<string> GetSentences(){
        return sentences;
    }
    

}
