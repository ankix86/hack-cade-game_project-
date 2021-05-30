using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public GameObject door;
    private Rigidbody2D rb;
    public GameObject task;
    private bool doorOpened;
    public AudioClip impact;
    public AudioSource aScorce;

    private void Start() {
        aScorce.clip = impact;
        doorOpened = false;
        task = GameObject.FindGameObjectWithTag("t1");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "key" && !doorOpened){
            door.SetActive(false); 
            rb.isKinematic = true;
            task.GetComponent<TaskSpot>().incressTask();
            doorOpened = true;
            aScorce.Play();
        }
    }
}
