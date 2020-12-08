using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDialogue
{
    private Queue<string> sentences = new Queue<string>();

    System.Random random = new System.Random();

    public void LoadSentences(){
        sentences.Enqueue("You some kinda knight? What's your deal?");
        sentences.Enqueue("What brings you here?");
        sentences.Enqueue("HU! Join an Army?");

        int pers = random.Next(70) + 1;
        pers += KnightStats.GetPersuasion() / 4;

        if(pers >= 60){
            sentences.Enqueue("Okay, I will join. Let's see how it works out");
            sentences.Enqueue("Fine, I'll join your army");
        }
        else{
            sentences.Enqueue("Heaok... No way I'm joining some stinkin' knight.");
            sentences.Enqueue("Be gone from my sight .");
        }
    }

    public Queue<string> GetSentences(){
        return sentences;
    }
    

}
