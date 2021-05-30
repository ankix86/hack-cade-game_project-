using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject scanner,ip_found_message,ip_stored_message,brutforcePasswordList,passwordFoundMsg;
    public List<GameObject> options = new List<GameObject>();
    public List<string> scanList = new List<string>();
    public Text progressBar;
    public bool stopBrutforce;
    public string finalDoorPass;
    private Animator scanAnimator;
    public Animator executeAnimator;
    public Transform drones;
    private Vector2 dronemovement;
    public List<GameObject> servers = new List<GameObject>();

    void Start()
    {
       
        passwordFoundMsg.SetActive(false);
        stopBrutforce = true; 
        ip_found_message.gameObject.SetActive(false);
        ip_stored_message.gameObject.SetActive(false);
        scanAnimator = scanner.GetComponent<Animator>();
    }
    void Update()
    {
        drones.transform.position = drones.transform.position +(new Vector3(dronemovement.x,dronemovement.y,0) * Time.deltaTime);
        if(!stopBrutforce){ 
            brutforcePasswordList.GetComponent<Text>().text = genrateRandomPass();
        }
    }
    public void popUpIPfoundMessage(){

    }
    public void popUpIPNotFoundMessage(){
        
    }
    public void startScan(){
                if(!scanAnimator.GetBool("scanning"))
                {
                    scanAnimator.SetBool("scanning",true);
                }
                else{
                     scanAnimator.SetBool("scanning",false);
                }
                StartCoroutine(ExecuteAfterTime(4));
            }
    public void stopScan(){
        ip_found_message.gameObject.SetActive(true);
        ip_stored_message.gameObject.SetActive(true);
        scanner.gameObject.SetActive(false);
        scanAnimator.SetBool("scanning",false);
    }

    void resetData(){
        dronemovement = new Vector2(0,0);
        passwordFoundMsg.SetActive(false);
        
        passwordFoundMsg.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        brutforcePasswordList.GetComponent<Text>().text = "";
        executeAnimator.SetBool("executing",false);
        ip_found_message.gameObject.SetActive(false);
        scanner.gameObject.SetActive(false);
        ip_stored_message.gameObject.SetActive(false);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
    yield return new WaitForSeconds(time);
    stopScan();
    }
    public void chooseOption(int id){
        resetData();
        for (var i = 0; i < options.Count; i++)
        {
            if(i == id){
                options[i].gameObject.SetActive(true);
                if(i == 1){
                    scanner.gameObject.SetActive(true);
                }
            }
            else{
                options[i].gameObject.SetActive(false);
            }
        }
    }

    public void executeStart(int id){
            if(!executeAnimator.GetBool("executing"))
            {
                executeAnimator.SetInteger("id",id);
                executeAnimator.SetBool("executing",true);
            }
        }

    public void startBrutforce(){
        stopBrutforce = false;
        StartCoroutine(waitMe(6f));
    }

    public string genrateRandomPass(){
        int number = Random.Range(1000,9999);
        return number.ToString();
    }
    IEnumerator waitMe(float time)
    {
    yield return new WaitForSeconds(time);
        stopBrutforce = true;
        passwordFoundMsg.SetActive(true);
        finalDoorPass = brutforcePasswordList.GetComponent<Text>().text;
        passwordFoundMsg.transform.GetChild(0).gameObject.GetComponent<Text>().text = finalDoorPass;
    }
    
    public void ControllerOption(int i){
        if(i == 0){
           dronemovement.y = 0.5f;
        }
        else if(i == 1){
            dronemovement.y = -0.5f;
        }
        else if(i == 2){
            dronemovement.x = 0.5f;
        }
        else if(i == 3){
            dronemovement.x = -0.5f;
        }
    }

    public void changeServerStatus(int id){
        servers[id].transform.GetChild(0).gameObject.SetActive(false);
        servers[id].transform.GetChild(1).gameObject.SetActive(true);
    }
}
