using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devices : MonoBehaviour
{
    public List<GameObject> devicesList = new List<GameObject>();
    public GameObject Getdevices(int id){
        return devicesList[id];
    }
    public void setUnactive(int id){
        devicesList[id].gameObject.SetActive(false);
    }
    public void setActive(int id){
        devicesList[id].gameObject.SetActive(true);
    }
}