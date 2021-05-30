using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rader : MonoBehaviour
{
    public GameObject gameover;
    void Start()
    {
      gameover.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
              gameover.SetActive(true);
        }
    }
}
