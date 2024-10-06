using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;
using UnityEngine.UIElements;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;

[Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextManager textManager;
    [SerializeField] private Player[] players = new Player[4];
    [SerializeField] private HidingSpot[] hidingSpots = new HidingSpot[4];
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject stars;

    private readonly Transform[] spotLocations = new Transform[4];
    private ushort currentPlayer = 0;
    private bool isMonsterTurn = false;

    // credit https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
    public static void Shuffle<T> (System.Random rand, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rand.Next(n--);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }

    public void Start()
    {
        Shuffle(new System.Random(), hidingSpots);
        
        for (int i = 0; i < hidingSpots.Length; i++)
        {
            spotLocations[i] = hidingSpots[i].transform;
        }
    }

    public void Hide(HidingSpot spot)
    {
        if (!isMonsterTurn)
        {
            spot.SetHiddenPlayer(players[currentPlayer]);
            textManager.SetText($"Player {currentPlayer + 1} has hid in spot {spot.GetSpotID() + 1}.");
            EndTurn();
        }
    }

    public void InvalidChoice(HidingSpot spot)
    {
        if (!isMonsterTurn)
        {
            textManager.SetText($"Player {spot.GetHiddenPlayer().playerID} has already hid in that spot!");
        }
    }

    public void EndTurn()
    {
        players[currentPlayer].isTurn = false;
        StartCoroutine(players[currentPlayer].FadeOut(1f));

        // update current player, then check if that was the last valid player
        currentPlayer++;
        if (currentPlayer >= players.Length) MonsterTurn();
        else players[currentPlayer].isTurn = true;
    }

    
    public void MonsterTurn()
    {
        isMonsterTurn = true;
        monster.SetActive(true);
        textManager.Flash();
        StartCoroutine(FadeCameraColor(new Color(120f, 200f, 255f), new Color(7f, 11f, 52f), 4f));
        StartCoroutine(MoveObject(stars, Vector2.zero, 4f));
        StartCoroutine(MoveToPositions(spotLocations));
    }

    private IEnumerator FadeCameraColor(Color initial, Color target, float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float colorR = Mathf.Lerp(initial.r / 255f, target.r / 255f, counter / duration);
            float colorG = Mathf.Lerp(initial.g / 255f, target.g / 255f, counter / duration);
            float colorB = Mathf.Lerp(initial.b / 255f, target.b / 255f, counter / duration);
            float colorA = Mathf.Lerp(0f, 1f, counter / duration);

            Camera.main.backgroundColor = new Color(colorR, colorG, colorB, 0f);
            monster.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorA);
            yield return null;
        }
    }

    private IEnumerator MoveToPositions(Transform[] transform)
    {
        int counter = 0;

        foreach (var t in transform)
        {
            var pos = t.position;

            yield return MoveObject(monster, Vector2.zero, 4.0f);
            yield return new WaitForSeconds(2.0f);

            if (counter < 3)
            {
                yield return MoveObject(monster, pos, 0.5f);

                // score outputter and caught animation
                textManager.SetMonsterText($"Player {hidingSpots[counter].GetHiddenPlayer().playerID} was caught!");

                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                // win animation
                textManager.MonsterFlash();
                StartCoroutine(RevertCameraColor(new Color(7f, 11f, 52f), new Color(120f, 200f, 255f), 4.0f));
                StartCoroutine(MoveObject(stars, new Vector2(0, 6.0f), 4.0f));
                yield return MoveObject(monster, new Vector2(0, 8.0f), 4.0f);

                monster.SetActive(false);
                textManager.Revert();
                textManager.SetText($"Player {hidingSpots[counter].GetHiddenPlayer().playerID} has survived!");
            }

            counter++;
        }
    }
    IEnumerator RevertCameraColor(Color initial, Color target, float duration)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float colorR = Mathf.Lerp(initial.r / 255f, target.r / 255f, counter / duration);
            float colorG = Mathf.Lerp(initial.g / 255f, target.g / 255f, counter / duration);
            float colorB = Mathf.Lerp(initial.b / 255f, target.b / 255f, counter / duration);
            float colorA = Mathf.Lerp(1f, 0f, counter / duration);

            Camera.main.backgroundColor = new Color(colorR, colorG, colorB, 0f);
            monster.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, colorA);
            yield return null;
        }
    }

    private IEnumerator MoveObject(GameObject obj, Vector2 pos, float duration)
    {
        float counter = 0f;
        Vector2 initPos = obj.transform.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            obj.transform.position = Vector2.Lerp(initPos, pos, counter / duration);

            yield return null;
        }
    }

}
