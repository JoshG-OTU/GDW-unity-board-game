using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMemory : MonoBehaviour
{

    public Vector3 pos;
    public bool dragging = false;
    private Vector3 offset;
    public int _state = 0;



    void Update(){
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition)+offset;
        
        if(_state==1 && dragging){
            transform.position = target;
        }



    }


    private void OnMouseDown(){
        
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        dragging = true;
    }

    private void OnMouseUp(){
        dragging  = false;
    }

}
