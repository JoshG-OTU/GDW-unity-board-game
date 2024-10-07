using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class QTE : MonoBehaviour
{
    public Dictionary<int, string> Shift;
    public Dictionary<int, string> Space;
    public Dictionary<int, string> Control;
    public Dictionary<int, string> Enter;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning buttons to the players
        Dictionary<string, string> players = new()
        {
            ["Red"] = "Shift",
            ["Purple"] = "Space",
            ["Blue"] = "Control",
            ["Green"] = "Enter"
        };

        Debug.Log("Player 1's button is " + players["Red"]);
        Debug.Log("Player 2's button is " + players["Purple"]);
        Debug.Log("Player 3's button is " + players["Blue"]);
        Debug.Log("Player 4's button is " + players["Green"]);

        Debug.Log("Game Start");
    }
    // Update is called once per frame
    void Update()
    {
        // Detecting button inputs
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift was pressed");
            Debug.Log("Player 1 wins");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space was pressed");
            Debug.Log("Player 2 wins");
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Control was pressed");
            Debug.Log("Player 3 wins");
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter was pressed");
            Debug.Log("Player 4 wins");
        }

        
    }
}