using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskSpot : MonoBehaviour
{
    public List<Vector3> taskPositions = new List<Vector3>();
    public GameObject taskPanel;
    public GameObject MainPanel;
    public GameObject keyMessage;
    public int spotTaskNumber = 0;
    public GameObject player;
    public GameObject WiningScreen;
    

    private bool playerPressedKey;
    private bool playerCollide;

  
 
    private void Start() {
        WiningScreen.SetActive(false);
        MainPanel.SetActive(false);
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.playerPressedKey = false;
        this.playerCollide = false;
        setupTaskPanel(spotTaskNumber);
    }
    public void incressTask(){
        if(spotTaskNumber < taskPanel.GetComponent<Transform>().childCount){
            spotTaskNumber++;
            changePosition();
        }
      
    }
    public void changePosition(){
        transform.position = taskPositions[spotTaskNumber];
    }
    private void setupTaskPanel(int taskId){
        int childCount = taskPanel.GetComponent<Transform>().childCount;
        for(int i =0; i < childCount;i++){
            if(taskId == i && taskId != 7){
                taskPanel.transform.GetChild(i).gameObject.SetActive(true);
            }
            else if(taskId == 7){
                WiningScreen.SetActive(true);
                MainPanel.gameObject.SetActive(false);
            }
            else{
                taskPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void setPanelUnactive(){
        MainPanel.gameObject.SetActive(false);
        taskPanel.gameObject.SetActive(false);
        //keyMessage.gameObject.SetActive(false);
    }
    private void setPanelActive(){
        MainPanel.gameObject.SetActive(true);
        taskPanel.gameObject.SetActive(true);
        setupTaskPanel(spotTaskNumber);
        //keyMessage.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            playerCollide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            playerCollide = false;
            playerPressedKey = false;
        }
    }
    private void Update() {

        if(playerCollide && !playerPressedKey){
            setPanelActive();
            playerPressedKey = false;
            if(Input.GetKeyDown(KeyCode.F)){
                playerPressedKey = true;
               
                if(spotTaskNumber == 0){
                     player.GetComponent<itemUse>().showDeviceOnScreen(0);
                }
                else if(spotTaskNumber == 1 || spotTaskNumber == 2){
                     player.GetComponent<itemUse>().showDeviceOnScreen(0);
                     player.GetComponent<itemUse>().showDeviceOnScreen(1);
                }
                else{
                     player.GetComponent<itemUse>().showDeviceOnScreen(0);
                }
            }
            else{
                playerPressedKey = false;
            }
        }
        else{
            setPanelUnactive();
        }
    }
}
