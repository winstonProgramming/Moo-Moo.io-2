using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D shopDisplay;
    public Helmet helmetScript;

    public bool boosterHelmetPurchased;
    public bool soldierHelmetPurchased;
    public bool bullHelmetPurchased;
    public bool healingHelmetPurchased;
    public bool samuraiHelmetPurchased;
    public bool berserkerHelmetPurchased;
    public bool assassinHelmetPurchased;
    public bool godHelmetPurchased;
    Vector2 shopMovement;

    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            shopMovement.x = 250;
            shopMovement.y = -325;
        }
        else
        {
            shopMovement.x = 250;
            shopMovement.y = -650;
        }
        shopDisplay.MovePosition(shopMovement);

        if(Input.GetKeyDown(KeyCode.Keypad1)&&!boosterHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 20&&Player.gameObject.GetComponent<PlayerActions>().wood >= 0&&Player.gameObject.GetComponent<PlayerActions>().food >= 0&&Player.gameObject.GetComponent<PlayerActions>().gold >= 10)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 20;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 0;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 10;
            boosterHelmetPurchased = true;
            helmetScript.helmetNum = 1;
        }
        if(Input.GetKeyDown(KeyCode.Keypad2)&&!soldierHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 30&&Player.gameObject.GetComponent<PlayerActions>().wood >= 0&&Player.gameObject.GetComponent<PlayerActions>().food >= 0&&Player.gameObject.GetComponent<PlayerActions>().gold >= 0)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 30;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 0;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 0;
            soldierHelmetPurchased = true;
            helmetScript.helmetNum = 2;
        }
        if(Input.GetKeyDown(KeyCode.Keypad3)&&!bullHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 15&&Player.gameObject.GetComponent<PlayerActions>().wood >= 4&&Player.gameObject.GetComponent<PlayerActions>().food >= 4&&Player.gameObject.GetComponent<PlayerActions>().gold >= 4)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 15;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 5;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 10;
            bullHelmetPurchased = true;
            helmetScript.helmetNum = 3;
        }
        if(Input.GetKeyDown(KeyCode.Keypad4)&&!healingHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 0&&Player.gameObject.GetComponent<PlayerActions>().wood >= 0&&Player.gameObject.GetComponent<PlayerActions>().food >= 30&&Player.gameObject.GetComponent<PlayerActions>().gold >= 0)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 0;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 0;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 30;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 0;
            healingHelmetPurchased = true;
            helmetScript.helmetNum = 4;
        }
        if(Input.GetKeyDown(KeyCode.Keypad5)&&!samuraiHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 0&&Player.gameObject.GetComponent<PlayerActions>().wood >=20&&Player.gameObject.GetComponent<PlayerActions>().food >= 0&&Player.gameObject.GetComponent<PlayerActions>().gold >= 20)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 0;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 20;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 20;
            samuraiHelmetPurchased = true;
            helmetScript.helmetNum = 5;
        }
        if(Input.GetKeyDown(KeyCode.Keypad6)&&!berserkerHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 0&&Player.gameObject.GetComponent<PlayerActions>().wood >= 30&&Player.gameObject.GetComponent<PlayerActions>().food >= 10&&Player.gameObject.GetComponent<PlayerActions>().gold >= 20)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 0;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 30;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 10;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 20;
            berserkerHelmetPurchased = true;
            helmetScript.helmetNum = 6;
        }
        if(Input.GetKeyDown(KeyCode.Keypad7)&&!assassinHelmetPurchased&&Player.gameObject.GetComponent<PlayerActions>().stone >= 0&&Player.gameObject.GetComponent<PlayerActions>().wood >= 0&&Player.gameObject.GetComponent<PlayerActions>().food >= 0&&Player.gameObject.GetComponent<PlayerActions>().gold >= 100)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone - 0;
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood - 0;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold - 100;
            assassinHelmetPurchased = true;
            helmetScript.helmetNum = 7;
        }
        if(Input.GetKey(KeyCode.L)&&Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.LeftShift)&&!godHelmetPurchased)
        {
            godHelmetPurchased = true;
            helmetScript.helmetNum = 100;
        }
    }
}