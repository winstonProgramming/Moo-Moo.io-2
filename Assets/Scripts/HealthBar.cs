using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D healthBar;
    public PlayerActions playerActions;
    Vector2 barCoords;
    Vector2 healthBarCoords;

    void Update()
    {
        barCoords.x = (float)Player.gameObject.GetComponent<PlayerActions>().healthRatio;
        barCoords.y = 1;
        Transform bar = transform.Find("Bar");
        bar.localScale = barCoords;
        healthBarCoords.x = playerActions.body.position.x;
        healthBarCoords.y = playerActions.body.position.y - 1.6f;
        if(!Player.gameObject.GetComponent<PlayerActions>().stopMovement)
        {
            healthBar.MovePosition(healthBarCoords + Player.gameObject.GetComponent<PlayerActions>().movement * Player.gameObject.GetComponent<PlayerActions>().moveSpeed);
        }
        else
        {
            healthBar.MovePosition(healthBarCoords);
        }
    }
}