using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayerManager : MonoBehaviour
{
    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> existingPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput newPlayer)
    {

        //ASSIGN VISUALS TO THIS NEW PLAYER
        SpriteRenderer newPLayerRenderer = newPlayer.GetComponent<SpriteRenderer>();
        newPLayerRenderer.sprite = possiblePlayerVisuals[existingPlayers.Count];

        existingPlayers.Add(newPlayer);

        LocalMultiPlayer playerScript = newPlayer.GetComponent<LocalMultiPlayer>();
        playerScript.managerScript = this;
        //THIS IS THE SAME THING
        //playerScript.manager = gameObject.GetComponenet<LocalMultiplayerManager>();


    }

    public PlayerInput TryAttack(PlayerInput attackingPlayer)
    {
        for(int i = 0; i < existingPlayers.Count; i++)
        {

            if(attackingPlayer == existingPlayers[i])
            {
                continue;
            }

            float distanceToPlayer = Vector3.Distance(attackingPlayer.transform.position, existingPlayers[i].transform.position);


            if(distanceToPlayer < 1.5f)
            {
                
                Debug.Log("Attack!!");
                return existingPlayers[i];
            }

        }
        return null;
    }
}
