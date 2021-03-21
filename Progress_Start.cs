using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_Start : MonoBehaviour
{
    public string[] Step_Sequence;    //This is the list of steps(in order) needed to progress, this list is compared to Progress_Step
    public string Progression_Title;  //All Steps need to have the same Progression_Title in order to be accounted for

    public GameObject WhileBeforeStep_Completion_Barrier; //Set this to a GameObject that holds Colliders to block progress untill this step is complete

    private void OnEnable()
    {
        WhileBeforeStep_Completion_Barrier.SetActive(true);
    }
}
