using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDisplay : MonoBehaviour
{
    public Text foodText;
    public GameObject Player;

    void Update()
    {
        foodText.text = "Food: " + Player.gameObject.GetComponent<PlayerActions>().food;
    }
}