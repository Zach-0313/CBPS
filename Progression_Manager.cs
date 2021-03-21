using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression_Manager : MonoBehaviour
{
    //This script checks if a new Progression Sequence is being assigned, feel free to add other triggers, a collider is just an example
    private void OnTriggerEnter(Collider other)
    {
        Try_Start_Progress(other);
    }
    public void Try_Start_Progress(Collider other)
    {
            if (other.gameObject.CompareTag("Start_Sequence"))
            {
                Progress_Sequence sequence = this.gameObject.AddComponent<Progress_Sequence>();
                sequence.SetQuestSteps(other.GetComponent<Progress_Start>().Step_Sequence);
                sequence.Progression_Title = other.gameObject.GetComponent<Progress_Start>().Progression_Title;
                sequence.CurrentStep = 0;
                Destroy(other.gameObject, .1f);
            }
    }
}
