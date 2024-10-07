using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

    //this is the roll dice from the tutorial

    public int RollDice() 
    {

        float diceRoll = Random.Range(1, 6);

        return (int) diceRoll;
    
    
    }






    /**
    //this is me trying to get placement to work but i cant figure it out :(
    public int RollDice()
    {

        




        float diceRoll = Random.Range(1, 6);

        if (PlayerMovement._currentPlayer == 1) 
        {
            if (PlayerMovement.play1place == 1)
            {

                float diceRoll = Random.Range(1, 8);

                Debug.Log("first");
            }




            else if (PlayerMovement.play1place == 2)
            {

                float diceRoll = Random.Range(1, 6);

                Debug.Log("second");

            }


            else if (PlayerMovement.play1place == 3)
            {

                float diceRoll = Random.Range(1, 4);

                Debug.Log("third");

            }



            else if (PlayerMovement.play1place == 4)
            {

                float diceRoll = Random.Range(1, 2);
                Debug.Log("fourth");


            }
        }





        if (PlayerMovement._currentPlayer == 2)
        {
            if (PlayerMovement.play2place == 1)
            {

                float diceRoll = Random.Range(1, 8);

                Debug.Log("first");
            }




            else if (PlayerMovement.play2place == 2)
            {

                float diceRoll = Random.Range(1, 6);

                Debug.Log("second");

            }


            else if (PlayerMovement.play2place == 3)
            {

                float diceRoll = Random.Range(1, 4);

                Debug.Log("third");

            }



            else if (PlayerMovement.play2place == 4)
            {

                float diceRoll = Random.Range(1, 2);
                Debug.Log("fourth");


            }
        }







        if (PlayerMovement._currentPlayer == 3)
        {
            if (PlayerMovement.play3place == 1)
            {

                float diceRoll = Random.Range(1, 8);

                Debug.Log("first");
            }




            else if (PlayerMovement.play3place == 2)
            {

                float diceRoll = Random.Range(1, 6);

                Debug.Log("second");

            }


            else if (PlayerMovement.play3place == 3)
            {

                float diceRoll = Random.Range(1, 4);

                Debug.Log("third");

            }



            else if (PlayerMovement.play3place == 4)
            {

                float diceRoll = Random.Range(1, 2);
                Debug.Log("fourth");


            }
        }




        if (PlayerMovement._currentPlayer == 4)
        {
            if (PlayerMovement.play4place == 1)
            {

                float diceRoll = Random.Range(1, 8);

                Debug.Log("first");
            }




            else if (PlayerMovement.play4place == 2)
            {

                float diceRoll = Random.Range(1, 6);

                Debug.Log("second");

            }


            else if (PlayerMovement.play4place == 3)
            {

                float diceRoll = Random.Range(1, 4);

                Debug.Log("third");

            }



            else if (PlayerMovement.play4place == 4)
            {

                float diceRoll = Random.Range(1, 2);
                Debug.Log("fourth");


            }
        }












        return (int)diceRoll;


    }


    */



}
