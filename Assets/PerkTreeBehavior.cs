
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkTreeBehavior : MonoBehaviour
{
    private bool perkTreeBool = false;
    public int perkPoints = 0;
    public GameObject perkTreeOBJ;
    public PerkBehavior PlusBarg, PlusPer, Plusluck;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PerkTree();
        }

        if (perkTreeBool)
        {
            perkTreeOBJ.SetActive(true);
        }
        else { perkTreeOBJ.SetActive(false); }
    }

    public void PerkTree()
    {
        perkTreeBool = !perkTreeBool;
    }
}
