using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{


    void OnTriggerStay2D(Collider2D collision) {

        GameObject other = collision.gameObject;


        if (other.GetComponent<ColorMemory>()!=null){

            other.GetComponent<ColorMemory>().dragging = false;

        }

    }

}
