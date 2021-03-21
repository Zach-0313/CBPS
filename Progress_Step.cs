using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_Step : MonoBehaviour
{
    public string Progression_Title; //What Progress Sequence does this belong to?
    public int ThisStep;             //This step's place in the sequence outlined in Progress_Start. 

    public GameObject WhileBeforeStep_Completion_Barrier; //Set this to a GameObject that holds Colliders to block progress untill this step is complete

    private void OnEnable()
    {
        WhileBeforeStep_Completion_Barrier.SetActive(true);
    }
}
