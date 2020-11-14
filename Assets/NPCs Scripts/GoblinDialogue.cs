using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDialogue
{
    private List<string> sentences = new List<string>();

    public void LoadSentences(){
        sentences.Add("Hello Stranger, my name is Bjorn");
        sentences.Add("What brings you here?");
        sentences.Add("Goodbye, Mr. Knight");
    }

    public string[] GetSentences(){
        return sentences.ToArray();
    }
    

}
