using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Sequence : MonoBehaviour
{
    //This script allows you to pre-define the sequence of events that control progression

    public string Progression_Title;      //The name of this sequence
    private string[] Progress_Steps;      //This is the list of steps(in order) needed to progress, this list is compared to each Progress_Step that is triggered
    public int CurrentStep;               //Tracks progress
    public string Step_Readout;           //Holds the current Progress_Step's title
    public Text Progress_Display;         //Assign a textbox in the inspector if you want to display the current objective

    public bool Sequence_Done;            //Returns true when the sequence is finished


    private void Start()
    {
        Step_Readout = Progress_Steps[CurrentStep];
    }
    public void SetQuestSteps(string[] input)
    {
        Progress_Steps = input;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (Sequence_Done) return;
        if (other.gameObject.GetComponent<Progress_Step>())
        {
            if (other.gameObject.GetComponent<Progress_Step>().Progression_Title.Equals(Progression_Title))
            {
                if (other.gameObject.GetComponent<Progress_Step>().ThisStep == CurrentStep + 1)
                {
                    Step_Readout = Progress_Steps[other.gameObject.GetComponent<Progress_Step>().ThisStep];
                    CurrentStep = other.gameObject.GetComponent<Progress_Step>().ThisStep;
                    if (Progress_Display != null) Progress_Display.text = Progress_Steps[CurrentStep];
                    Destroy(other.gameObject, 0.1f);
                }
            }

        }
        if (other.gameObject.GetComponent<Progression_End>())
        {
            if (other.gameObject.CompareTag("End_Sequence"))
            {
                if (other.gameObject.GetComponent<Progression_End>().ThisStep == CurrentStep + 1)
                {
                    Step_Readout = Progress_Steps[Progress_Steps.Length-1];
                    CurrentStep = other.gameObject.GetComponent<Progression_End>().ThisStep;
                    if (Progress_Display != null) Progress_Display.text = Progress_Steps[CurrentStep];
                    Sequence_Done = true;
                    Destroy(other.gameObject, 0.1f);
                }
            }
        }
    }
}
