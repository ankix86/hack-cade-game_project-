using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRunner : MonoBehaviour
{
    public List<GameObject> scriptsList = new List<GameObject>();
    public GameObject scriptRunnerHomePage;
 
   public void openScript(int id){
       scriptRunnerHomePage.gameObject.SetActive(false);
       for (int i = 0; i < scriptsList.Count; i++)
       {
           if(i == id){
               scriptsList[i].gameObject.SetActive(true);
           }
           else{
               scriptsList[i].gameObject.SetActive(false);
           }
       }
   }
   public void back(){
         scriptRunnerHomePage.gameObject.SetActive(true);
         for (int i = 0; i < scriptsList.Count; i++)
        {
               scriptsList[i].gameObject.SetActive(false);
        }
       }
}
