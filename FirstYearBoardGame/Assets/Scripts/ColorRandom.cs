using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ColorRandom : MonoBehaviour
{


    public List<GameObject> colors;
    public List<GameObject> positionMemor;
    private List<Vector3> positionArray  = new List<Vector3>();
    public List<int> players = new List<int>();
    private int playerTurn = 0;

    public TextMeshProUGUI number;
    public GameObject LockinButton;
    public GameObject ReadyButton;
    public TextMeshProUGUI AreYouReadyText;
    private int textTimer = 500;
    private int index = 0;
    public GameObject WinScreen;
    public TextMeshProUGUI WinnerText;

    private float xPos;
    private float yPos = 1.0f;
    public int colorTimer = 60;
    public int colortime;
    public int timer = 60;
    public int time;

    [SerializeField] private Vector3 orderedPosition;
    private Vector3 defaultPosition; 


    private int states = -1; 
    public int totalPoints = 0; 
    





    // Start is called before the first frame update
    void Start()
    {


        visibilityOFF();
        defaultPosition = orderedPosition;
        LockinButton.GetComponent<Canvas>().enabled = false;
        ReadyButton.GetComponent<Canvas>().enabled = false;
        WinScreen.GetComponent<Canvas>().enabled = false;
        GameObject.Find("Background").GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        GameObject.Find("memorybackground").GetComponent<Renderer>().enabled = false;
        



    }

    // Update is called once per frame
    void Update()
    {
        
        if(states ==-1){
            
            
            number.text = (players.Count).ToString();
            if (GameObject.Find("StartRound").GetComponent<Canvas>().enabled == false){
                string oneChance  = "You have ONE Chance to Guess";
                string readyText = "Are you Ready? Player 1";

                


                if(textTimer>0){
                    ScrollingText(AreYouReadyText,oneChance);
                    ReadyButton.GetComponent<Canvas>().enabled = true;

                }else{
                    AreYouReadyText.text = readyText;
                    ReadyButton.GetComponent<Canvas>().enabled = true;
                }

            }



        }else if(states==0){
            colortime-=1;

            if(colortime<=0){
                time-=1;

                if(time>=0)
                    visibilityON();
                else{
                    visibilityOFF();
                    states = 1;
                }
            
            }

        }else if( states == 1){
            visibilityON();
            for( int i=0; i<colors.Count; ++i){

            colors[i].transform.position = defaultPosition;
            colors[i].GetComponent<ColorMemory>()._state = 1;
            defaultPosition += new Vector3(1.0f,0.0f,0.0f);

            }

            LockinButton.GetComponent<Canvas>().enabled = true;


            states = 2;
        }

    }


    public void randomizer(){
        
        for(int i=0;i<colors.Count;i++){
            
            int rand = Random.Range(0,positionArray.Count);
            colors[i].GetComponent<ColorMemory>().pos = positionArray[rand];
            colors[i].transform.position = positionArray[rand];
            positionArray.RemoveAt(rand);

        }

    }


    private void visibilityON(){

        for(int i=0;i<colors.Count;i++){

            if(colors[i].GetComponent<Renderer>().enabled == false)
                colors[i].GetComponent<Renderer>().enabled = true;

           
            


        }
    }

    private void visibilityOFF(){

        for(int i=0;i<colors.Count;i++){

            if(colors[i].GetComponent<Renderer>().enabled == true)
                colors[i].GetComponent<Renderer>().enabled = false;

        }
    }


    private void ScrollingText(TextMeshProUGUI string1, string string2){
        textTimer-=1;

        if(index==0){
            string1.text = "";
        }
        if(textTimer%10==0 && index<string2.Length){
            string1.text += string2[index];
            index+=1;
        }

        if(textTimer==-1){
            textTimer = -1;
        }

    }




    public void confirmChoice(){
        players[playerTurn] = totalPoints;
        if(playerTurn+1<players.Count){
            
            playerTurn+=1;
            ReadyButton.GetComponent<Canvas>().enabled = true;
            GameObject.Find("Background").GetComponent<Renderer>().material.color = Color.black;
            AreYouReadyText.text =  "Are you Ready? Player "+(playerTurn+1);
            GameObject.Find("memorybackground").GetComponent<Renderer>().enabled = false;
            visibilityOFF();
            
            LockinButton.GetComponent<Canvas>().enabled = false;
            
        }else{
            int winNum = 0; 

            for(int i=0; i<players.Count; i++){

                Debug.Log(players[i]);

                if(players[winNum]<players[i]){
                    winNum = i;
                }
            }
            GameObject.Find("memorybackground").GetComponent<Renderer>().enabled = false;
            visibilityOFF();
            LockinButton.GetComponent<Canvas>().enabled = false;
            WinScreen.GetComponent<Canvas>().enabled = true;
            WinnerText.text = "The Winner is Player " + (winNum+1) +" with "+ players[winNum] +" correct!";





        }



    }


    public void playerStart(){
        ReadyButton.GetComponent<Canvas>().enabled = false;
        GameObject.Find("memorybackground").GetComponent<Renderer>().enabled = true;
        states = 0;
        time = timer;
        colortime = colorTimer;
        defaultPosition = orderedPosition;
        totalPoints = 0;


        xPos = -5;
        for(int i=0; i<colors.Count;i++){
            positionArray.Add(new Vector3(xPos,yPos,0));
            xPos+=1.5f;
            positionMemor[i].transform.position = positionArray[i];
            colors[i].GetComponent<ColorMemory>()._state = 0;

        }
        randomizer();
        
        
    }



}
