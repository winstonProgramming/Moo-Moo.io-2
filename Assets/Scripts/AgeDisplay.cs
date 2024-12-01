using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeDisplay : MonoBehaviour
{
    public Text ageText;
    public GameObject Player;

    void Update()
    {
        ageText.text = "Age: " + Player.gameObject.GetComponent<PlayerActions>().age;
    }
}