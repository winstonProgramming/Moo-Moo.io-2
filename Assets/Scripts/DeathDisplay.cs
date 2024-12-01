using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDisplay : MonoBehaviour
{
    public Rigidbody2D deathDisplay;
    public GameObject Player;

    Vector2 deathMovement;

    void Update()
    {
        if(Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            deathMovement.x = 0;
            deathMovement.y = 70;
        }
        else
        {
            deathMovement.x = 0;
            deathMovement.y = -500;
        }
        deathDisplay.MovePosition(deathMovement);
    }
}