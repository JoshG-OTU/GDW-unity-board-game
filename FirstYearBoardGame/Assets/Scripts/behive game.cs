using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behivegame : MonoBehaviour
{
    int _tileMovementAmount;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("pick 1 or 2, dont hit the bombs");
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {

                count++;
            
                _tileMovementAmount = 1;
                
            Debug.Log("count = "+count);
                if (count == 6)
                {
                    Debug.Log("you lose");
                }
                else if (count == 12)
                {
                    Debug.Log("you lose");
                }
                else if (count == 18)
                {
                    Debug.Log("you lose");
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                for (int j = 0; j < 2; j++)
                {
                    count++;

                    _tileMovementAmount = 1;
                    
                Debug.Log("count = " + count);
                    if (count == 6)
                    {
                        Debug.Log("you lose");
                        break;
                    }
                    else if (count == 12)
                    {
                        Debug.Log("you lose");
                        break;
                    }
                    else if (count == 18)
                    {
                        Debug.Log("you lose");
                        break;
                    }

                }

            }
    }
}
