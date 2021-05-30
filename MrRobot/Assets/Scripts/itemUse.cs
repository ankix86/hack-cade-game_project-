using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{   
    Devices device;
    public GameObject deviceBG;
    private void Start() {
         deviceBG.gameObject.SetActive(false);
        device = GameObject.FindGameObjectWithTag("Devices").GetComponent<Devices>();
        for(int i=0;i < device.devicesList.Count;i++){
            device.setUnactive(i);
        }
    }
    public void showDeviceOnScreen(int id){
            device.setActive(id);
            deviceBG.gameObject.SetActive(true);
    }
    public void showDeviceOffScreen(int id){
            device.setUnactive(id);
            deviceBG.gameObject.SetActive(false);
    }
}
