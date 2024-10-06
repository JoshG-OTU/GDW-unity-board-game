using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HidingSpot : MonoBehaviour
{
    public bool isAvailable = true;
    [SerializeField] private ushort spotID;
    [SerializeField] private GameManager gameManager;

    private Player hiddenPlayer;

    private void OnMouseDown()
    {
        if (isAvailable)
        {
            isAvailable = false;
            gameManager.Hide(this);
        }
        else
        {
            gameManager.InvalidChoice(this);
        }
    }

    public void SetHiddenPlayer(Player player) => hiddenPlayer = player; 
    public Player GetHiddenPlayer() => hiddenPlayer;
    public ushort GetSpotID() => spotID;
}
