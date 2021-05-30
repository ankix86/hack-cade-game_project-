using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public List<GameObject> successMsg = new List<GameObject>();
    public bool processStatus;
    public Phone phone;
    public GameObject task;
    public int counter;
    public AudioClip impact;
    public AudioSource aScorce;

    private void Start() {
        aScorce.clip = impact;
        counter = 0;
        task = GameObject.FindGameObjectWithTag("t1");
            processStatus = false;
          for (int i = 0; i < successMsg.Count; i++)
          {
              successMsg[i].gameObject.SetActive(false);
                
          }

    }
    public void Done(int id){
        if(id == 3){
        if(!processStatus){
            successMsg[3].gameObject.SetActive(false);
            processStatus = true;
             aScorce.Play();
            
        }
        else{
            processStatus = false;
        }
        }
        else if(counter == id){
            successMsg[id].gameObject.SetActive(false);
            phone.changeServerStatus(id);
            counter++;
             aScorce.Play();
            task.GetComponent<TaskSpot>().incressTask();
        }
    }
}
