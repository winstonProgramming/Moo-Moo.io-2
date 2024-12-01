using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneDisplay : MonoBehaviour
{
    public Text stoneText;
    public GameObject Player;

    void Update()
    {
        stoneText.text = "Stone: " + Player.gameObject.GetComponent<PlayerActions>().stone;
    }
}