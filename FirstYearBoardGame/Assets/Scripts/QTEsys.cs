using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QTEsys : MonoBehaviour
{
    public TMP_Text DisplayBox;
    public TMP_Text Passbox;
    private int QTEGen;
    private int WaitingForKey;
    private int CorrectKey;
    private int CountingDown;

    public void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 2);
            CountingDown = 1;
            StartCoroutine(CountDown());

            if (QTEGen == 1)
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<TMP_Text>().text = "<sprite index=0>";
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("QTE Button Input"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        IEnumerator KeyPressing()
        {
            QTEGen = 4;
            if (CorrectKey == 1)
            {
                CountingDown = 2;
                Passbox.GetComponent<TMP_Text>().text = "PASS!!";
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                Passbox.GetComponent<TMP_Text>().text = "";
                DisplayBox.GetComponent<TMP_Text>().text = "";
                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
            }
            if (CorrectKey == 2)
            {
                CountingDown = 2;
                Passbox.GetComponent<TMP_Text>().text = "Fail!!";
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                Passbox.GetComponent<TMP_Text>().text = "";
                DisplayBox.GetComponent<TMP_Text>().text = "";
                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
            }
        }
        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(3.5f);
            if (CountingDown == 1)
            {
                QTEGen = 4;
                CountingDown = 2;
                Passbox.GetComponent<TMP_Text>().text = "Fail!!";
                yield return new WaitForSeconds(1.5f);
                CorrectKey = 0;
                Passbox.GetComponent<TMP_Text>().text = "";
                DisplayBox.GetComponent<TMP_Text>().text = "";
                yield return new WaitForSeconds(1.5f);
                WaitingForKey = 0;
                CountingDown = 1;
            }
        }
    }    
}
