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

        //Debug.Log("Current coin: " + KnightStats.getCoin());
        if(KnightStats.getCoin() < 10){
            sentences.Enqueue("You don't even have a single coin with you and you expect me to join your Army?");
            sentences.Enqueue("How about this? Some unlucky chaps left some gold coins in some treasure chests in this dungeons.");
            sentences.Enqueue("Find them and I'll consider your proposal.");
            return;
        }

        int pers = random.Next(70) + 1;
        pers += KnightStats.GetPersuasion() / 4;
        pers += KnightStats.getBargaining() / 4;
        pers += KnightStats.getLuck() / 5;

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
