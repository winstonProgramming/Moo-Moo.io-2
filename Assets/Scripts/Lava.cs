using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Rigidbody2D lavaOriginal;
    public GameObject Player;
    public GameObject Liam_The_Leprechaun;
    float lavaDamage = 0.8f;
    //public bool lavaCreated;

    void Update()
    {
        //if(!lavaCreated)
        {
            //GameObject lavaClone = Instantiate(lavaOriginal, new Vector2(-35, 15), lavaOriginal.transform.rotation);
            //lavaCreated = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health - lavaDamage * Player.gameObject.GetComponent<PlayerActions>().damageResistance;
            Player.gameObject.GetComponent<PlayerActions>().lavaDrag = 0.5f;
        }
        if(col.gameObject.CompareTag("Liam_Tag"))
        {
            Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = (float)Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth - lavaDamage;
            Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag = 0.5f;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Player.gameObject.GetComponent<PlayerActions>().lavaDrag = 1;
        }
        if(col.gameObject.CompareTag("Liam_Tag"))
        {
            Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag = 1;
        }
    }
}