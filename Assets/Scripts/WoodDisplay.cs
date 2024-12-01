using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodDisplay : MonoBehaviour
{
    public Text woodText;
    public GameObject Player;

    void Update()
    {
        woodText.text = "Wood: " + Player.gameObject.GetComponent<PlayerActions>().wood;
    }
}