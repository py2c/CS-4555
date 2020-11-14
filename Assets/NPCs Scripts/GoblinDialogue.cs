using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDialogue
{
    private Queue<string> sentences = new Queue<string>();

    System.Random random = new System.Random();

    public void LoadSentences(){
        sentences.Enqueue("Hello Stranger, my name is Bjorn");
        sentences.Enqueue("What brings you here?");

        int pers = random.Next(70) + 1;
        pers += KnightStats.GetPersuasion() / 4;

        if(pers >= 60){
            sentences.Enqueue("You have passed the persuasion check.");
            sentences.Enqueue("I will now join your side.");
        }
        else{
            sentences.Enqueue("Sorry, your persuasion is too low so I can not join you.");
            sentences.Enqueue("Good bye, Mr. Knight.");
        }
    }

    public Queue<string> GetSentences(){
        return sentences;
    }
    

}
