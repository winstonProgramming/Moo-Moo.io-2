using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FoodToEat : MonoBehaviour
{
    public GameObject Player;
    public PlayerActions playerActions;
    public Rigidbody2D foodToEat;
    public Sprite Apple;
    public Sprite Cookie;
    public Sprite Cheese;

    public const double PI = 3.1415926535897931;
    double offsetx = 0;
    double offsety = 0;
    Vector2 foodToEatMovement;

    void Update()
    {
        if(Player.gameObject.GetComponent<PlayerActions>().eatingFood)
        {
            foodToEat.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            foodToEat.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        }

        if(Player.gameObject.GetComponent<PlayerActions>().age == 0)
        {
            foodToEat.gameObject.GetComponent<SpriteRenderer>().sprite = Apple;
            Player.gameObject.GetComponent<PlayerActions>().foodCost = 5;
            Player.gameObject.GetComponent<PlayerActions>().foodHealing = 20;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().age >= 1&&Player.gameObject.GetComponent<PlayerActions>().age <= 2)
        {
            foodToEat.gameObject.GetComponent<SpriteRenderer>().sprite = Cookie;
            Player.gameObject.GetComponent<PlayerActions>().foodCost = 4;
            Player.gameObject.GetComponent<PlayerActions>().foodHealing = 30;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().age >= 3)
        {
            foodToEat.gameObject.GetComponent<SpriteRenderer>().sprite = Cheese;
            Player.gameObject.GetComponent<PlayerActions>().foodCost = 3;
            Player.gameObject.GetComponent<PlayerActions>().foodHealing = 40;
        }
    }

    void FixedUpdate()
    {
        foodToEat.rotation = playerActions.body.rotation;
        if(foodToEat.rotation + 90 >= 0)
        {
            offsetx = Math.Cos((foodToEat.rotation + 90)*PI/180) * 0.9/Player.gameObject.GetComponent<PlayerActions>().moveSpeed;
            offsety = Math.Sin((foodToEat.rotation + 90)*PI/180) * 0.9/Player.gameObject.GetComponent<PlayerActions>().moveSpeed;
        }
        else
        {
            offsetx =  Math.Cos((360 + foodToEat.rotation + 90)*PI/180) * 0.9/Player.gameObject.GetComponent<PlayerActions>().moveSpeed;
            offsety =  Math.Sin((360 + foodToEat.rotation + 90)*PI/180) * 0.9/Player.gameObject.GetComponent<PlayerActions>().moveSpeed;
        }

        if(!Player.gameObject.GetComponent<PlayerActions>().stopMovement)
        {
            foodToEatMovement.x = playerActions.movement.x * (float)Player.gameObject.GetComponent<PlayerActions>().moveSpeed/0.15f + (float)offsetx;
            foodToEatMovement.y = playerActions.movement.y * (float)Player.gameObject.GetComponent<PlayerActions>().moveSpeed/0.15f + (float)offsety;
        }
        else
        {
            foodToEatMovement.x = (float)offsetx;
            foodToEatMovement.y = (float)offsety;
        }

        foodToEat.MovePosition(playerActions.body.position + foodToEatMovement * Player.gameObject.GetComponent<PlayerActions>().moveSpeed);
    }
}