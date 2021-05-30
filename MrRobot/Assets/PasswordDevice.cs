using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordDevice : MonoBehaviour
{
    public Phone phone;
    public List<GameObject> doors = new List<GameObject>();
    public GameObject passwordText;
    public GameObject task;
    private int doorno;
    public AudioClip impact;
    public AudioSource aScorce;
    void Start()
    {   
        aScorce.clip = impact;
        doorno = 0;
        task = GameObject.FindGameObjectWithTag("t1");
        passwordText.gameObject.GetComponent<Text>().text = "";
    }
    public void press(int i){
        if(passwordText.gameObject.GetComponent<Text>().text.Length < 4){
        passwordText.gameObject.GetComponent<Text>().text += i.ToString();
        }
    }
    public void clear(){
        passwordText.gameObject.GetComponent<Text>().text = "";
    }
    public void Close(){
        this.gameObject.SetActive(false);
    }
 
    public void openDoor(){
        if(phone.finalDoorPass == passwordText.gameObject.GetComponent<Text>().text){
            Debug.Log("Door Unlocked!");
            doors[doorno].SetActive(false);
            this.gameObject.SetActive(false);
            passwordText.gameObject.GetComponent<Text>().text = "";
            phone.finalDoorPass = "";
            doorno++;
            task.GetComponent<TaskSpot>().incressTask();
             aScorce.Play();
        }
        else{
            Debug.Log("Wrong Password!");
        }
    }
}
