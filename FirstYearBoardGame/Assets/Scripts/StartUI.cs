using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartUI : MonoBehaviour
{
   
   

   public void add(){

        GameObject.Find("GameManager").GetComponent<ColorRandom>().players.Add(0);
    
   }
   

   public void minus(){

        GameObject.Find("GameManager").GetComponent<ColorRandom>().players.Remove(0);
        
    }


    public void clearStartMenu(){

        if (GameObject.Find("GameManager").GetComponent<ColorRandom>().players.Count >=2){
            this.GetComponent<Canvas>().enabled = false;
        }
    }






}
