using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    public Text goldText;
    public GameObject Player;

    void Update()
    {
        goldText.text = "Gold: " + Player.gameObject.GetComponent<PlayerActions>().gold;
    }
}