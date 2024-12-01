using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    public GameObject Player;

    void Update()
    {
        healthText.text = ((int)Player.gameObject.GetComponent<PlayerActions>().health).ToString();
    }
}