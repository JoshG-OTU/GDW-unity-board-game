using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullSquare : MonoBehaviour
{





    void OnTriggerStay2D(Collider2D collision) {
        
        GameObject other = collision.gameObject;
        
        if (other.GetComponent<ColorMemory>()._state==1)
        {
            
            if(other.GetComponent<ColorMemory>().dragging == false){
                other.transform.position = transform.position;
                Vector3 otherPos = other.GetComponent<ColorMemory>().pos;
                other.GetComponent<ColorMemory>()._state = 3;

                if(otherPos == transform.position){
                    GameObject.Find("GameManager").GetComponent<ColorRandom>().totalPoints +=1;  
                }
            }

        }
        
    }
    


}
