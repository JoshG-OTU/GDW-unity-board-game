using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class QTEsys : MonoBehaviour
{

    public GameObject qteSignal;
    public TMP_Text passbox;
    private bool gameStarting = true;
    private bool waitingForKey;
    private bool qteIsActive;
    private bool playerFailed;
    private bool playerPassed;

    private void StartGame()
    {
        StopAllCoroutines();
        qteSignal.SetActive(false);
        qteIsActive = false;
        passbox.text = "";
        StartCoroutine(CountDown());
        waitingForKey = true;
        gameStarting = false;
        playerFailed = false;
        playerPassed = false;
    }

    private void Update()
    {
        if (gameStarting)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && waitingForKey)
        {
            if (!qteIsActive)
            {
                StartCoroutine(Fail());
            }
            else
            {
                StartCoroutine(Pass());
            }
        }
    }

    IEnumerator LookingForKey()
    {
        yield return new WaitForSeconds(0.5f);
        if (!playerPassed) StartCoroutine(Fail());
    }


    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(Random.Range(3f, 4f));
        if (!playerFailed)
        {
            qteSignal.SetActive(true);
            qteIsActive = true;
            StartCoroutine(LookingForKey());
        }
    }

    IEnumerator Pass()
    {
        playerPassed = true;
        waitingForKey = false;
        passbox.text = "PASS!!";
        yield return new WaitForSeconds(2.5f);
        gameStarting = true;
    }

    IEnumerator Fail()
    {
        playerFailed = true;
        waitingForKey = false;
        passbox.text = "Fail!!";
        yield return new WaitForSeconds(2.5f);
        gameStarting = true;
    }
}
