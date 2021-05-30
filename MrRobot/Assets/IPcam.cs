using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPcam : MonoBehaviour
{
    public ProgressBar bar;
    public GameObject rader;
    public GameObject task;


    
    private void Start() {
        task = GameObject.FindGameObjectWithTag("t1");
    }
    private void FixedUpdate(){
        if(bar.processStatus){
            rader.SetActive(false);
            bar.processStatus = false;
            task.GetComponent<TaskSpot>().incressTask();
        }
    }
}
