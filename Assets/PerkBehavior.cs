using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Perk
{
    PlusPer,
    PlusBarg,
    Plusluck
   
   
}
public class PerkBehavior : MonoBehaviour
{
   
   
        public Perk thisPerk = Perk.PlusPer;
        public PerkTreeBehavior tree;
        public bool isEnabled;
        private PerkBehavior requiredPerk;
        private Text text;
        public bool isPurchased = false;

        // Start is called before the first frame update
        void Start()
        {
            text = GetComponentInChildren<Text>();
            if (thisPerk.Equals(Perk.PlusBarg)) { requiredPerk = tree.PlusPer; }
            if (thisPerk.Equals(Perk.Plusluck)) { requiredPerk = tree.PlusPer; }
        }

        public void RankUp()
        {
            if (tree.perkPoints > 0 && isPurchased)
            {
                if (thisPerk.Equals(Perk.PlusPer))
                {
                    tree.perkPoints -= 1;
                    isEnabled = true;
                    text.text = "Purchased!";
                    
                }
                else if (requiredPerk.isEnabled == true)
                {
                    tree.perkPoints -= 1;
                    isEnabled = true;
                    text.text = "Purchased!";

                    //Enabling perk functions
                    if (thisPerk.Equals(Perk.PlusBarg)) { PlusBargFunction(); }
                    if (thisPerk.Equals(Perk.Plusluck)) { PlusluckFunction(); }
                }
            }
        }

        private void PlusluckFunction()
    {
            int luk = KnightStats.GetLuck();
            KnightStats.setLuck(luk + 5);
            Debug.Log("Adding Luck points!");
        }

        private void PlusBargFunction()
        {
            int bargs = KnightStats.GetBargaining();
            KnightStats.setBargaining(bargs + 5);
            Debug.Log("Adding Bargaining points!");
        }

        private void PlusPerFunction()
        {
            Debug.Log("Adding Persuassion points!");
            int pers = KnightStats.GetPersuasion();
            KnightStats.setPersuasion(pers + 1);
        }
    }
