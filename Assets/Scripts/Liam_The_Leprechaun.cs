using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System;
using UnityEngine;

public class Liam_The_Leprechaun : MonoBehaviour
{
    public PlayerActions script;
    public GameObject Player;
    public Rigidbody2D Liam;

    public const double PI = 3.1415926535897931;
    int agroLvl = 0;
    Vector2 LiamLookDir;
    public float LiamSpeed;
    double LiamxDiff;
    double LiamyDiff;
    bool xGood1;
    bool yGood1;
    bool xGood2;
    bool yGood2;
    float lvl1AgroRange = 14;
    float lvl2AgroRange = 5.7f;
    public Vector2 LiamMovement;
    public static int liamMaxHealth = 100;
    public double liamHealth;
    public double liamHealthRatio = 1;
    public double LiamPositionX;
    public double LiamPositionY;
    public bool liamDead;
    int liamDamage = 20;
    static float kbTime = 0.5f;
    double kbEndTime = 0;
    bool liamResourcesCollected = true;
    public bool liamHelmetPurchased;
    public float liamDamageResistance;
    public float liamHelmetDamageMultiplier;
    public float liamKBNum;
    double riverDragX;
    double riverDragY = 1;
    public double liamLavaDrag = 1;

    void Update()
    {
        LiamPositionX = Liam.position.x;
        LiamPositionY = Liam.position.y;
        LiamxDiff = Liam.position.x - script.body.position.x;
        LiamyDiff = Liam.position.y - script.body.position.y;
        if(LiamxDiff < -lvl1AgroRange|LiamxDiff > lvl1AgroRange|LiamyDiff < -lvl1AgroRange|LiamyDiff > lvl1AgroRange)
        {
            agroLvl = 0;
            xGood1 = false;
            yGood1 = false;
            xGood2 = false;
            yGood2 = false;
        }
        if(!xGood1|!yGood1|!xGood2|!yGood2)
        {
            agroLvl = 0;
            xGood1 = false;
            yGood1 = false;
            xGood2 = false;
            yGood2 = false;
        }
        if(LiamxDiff > -lvl1AgroRange&&LiamxDiff < lvl1AgroRange)
        {
            xGood1 = true;
        }
        else
        {
            agroLvl = 0;
        }
        if(LiamyDiff > -lvl1AgroRange&&LiamyDiff < lvl1AgroRange)
        {
            yGood1 = true;
        }
        else
        {
            agroLvl = 0;
        }
        if(xGood1&&yGood1)
        {
            agroLvl = 1;
        }
        if(LiamxDiff > -lvl2AgroRange&&LiamxDiff < lvl2AgroRange)
        {
            xGood2 = true;
            xGood1 = false;
        }
        else
        {
            xGood2 = false;
        }
        if(LiamyDiff > -lvl2AgroRange&&LiamyDiff < lvl2AgroRange)
        {
            yGood2 = true;
            yGood1 = false;
        }
        else
        {
            yGood2 = false;
        }
        if(xGood2&&yGood2)
        {
            agroLvl = 2;
        }

        LiamLookDir = script.body.position - Liam.position;

        if(agroLvl == 0)
        {
            Liam.rotation = Liam.rotation - 7.5f;
            LiamMovement.x = 0;
            LiamMovement.y = 0;
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth + 0.05f;
        }
        if(agroLvl == 1)
        {
            Liam.rotation = Mathf.Atan2(LiamLookDir.y, LiamLookDir.x) * Mathf.Rad2Deg + 90;

            if(Liam.rotation - 90 >= 0)
            {
                LiamMovement.x = (float)Math.Cos((Liam.rotation - 90)*PI/180) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag + (float)riverDragX;
                LiamMovement.y = (float)Math.Sin((Liam.rotation - 90)*PI/180) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag * (float)riverDragY;
            }
            else
            {
                LiamMovement.x =  (float)Math.Cos((360 + Liam.rotation - 90)*PI/180) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag + (float)riverDragX;
                LiamMovement.y =  (float)Math.Sin((360 + Liam.rotation - 90)*PI/180) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag * (float)riverDragY;
            }
        }
        if(agroLvl == 2)
        {
            Liam.rotation = Liam.rotation - 100;

            LiamMovement.x = (float)((script.body.position.x - Liam.position.x) * 0.5) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag + (float)riverDragX;
            LiamMovement.y = (float)((script.body.position.y - Liam.position.y) * 0.5) * (float)Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamLavaDrag * (float)riverDragY;
        }
        //Movement ideas:
            //LiamMovement.x = (float)LiamxDiff*x;
            //LiamMovement.y = (float)LiamyDiff*x;

            //if(Liam.rotation>= 0)
            //{
            //    LiamMovement.x = (float)Math.Cos((Liam.rotation)*PI/180);
            //    LiamMovement.y = (float)Math.Sin((Liam.rotation)*PI/180);
            //}
            //else
            //{
            //  LiamMovement.x =  (float)Math.Cos((360 + Liam.rotation)*PI/180);
            //  LiamMovement.y =  (float)Math.Sin((360 + Liam.rotation)*PI/180);
            //}
        
        if(Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            LiamMovement.x = 0 - Liam.position.x;
            LiamMovement.y = 25 - Liam.position.y;
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = liamMaxHealth;
        }
        if(Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamDead)
        {
            LiamMovement.x = 0 - Liam.position.x;
            LiamMovement.y = 25 - Liam.position.y;
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = liamMaxHealth;
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetPurchased = true;
            if(Liam.position.x > -0.1&&Liam.position.x < 0.1&&Liam.position.y > 24.9&&Liam.position.y < 25.1)
            {
                Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamDead = false;
            }
        }

        Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealthRatio = Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth/liamMaxHealth;
        if(Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth > liamMaxHealth)
        {
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = liamMaxHealth;
        }
        if(Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth <= 0)
        {
            Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamDead = true;
            liamResourcesCollected = false;
        }

        if(Time.time <= kbEndTime)
        {
            Player.gameObject.GetComponent<PlayerActions>().hitByLiam = true;
        }
        else
        {
            Player.gameObject.GetComponent<PlayerActions>().hitByLiam = false;
        }
        if(Liam.rotation - 90 >= 0)
        {
            Player.gameObject.GetComponent<PlayerActions>().liamBounce.x = (float)(Math.Cos((Liam.rotation - 90)*PI/180) * (kbEndTime - Time.time) * 12 / Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum);
            Player.gameObject.GetComponent<PlayerActions>().liamBounce.y = (float)(Math.Sin((Liam.rotation - 90)*PI/180) * (kbEndTime - Time.time) * 12 / Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum);
        }
        else
        {
            Player.gameObject.GetComponent<PlayerActions>().liamBounce.x =  (float)(Math.Cos((270 + Liam.rotation)*PI/180) * (kbEndTime - Time.time) * 12 / Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum);
            Player.gameObject.GetComponent<PlayerActions>().liamBounce.y =  (float)(Math.Sin((270 + Liam.rotation)*PI/180) * (kbEndTime - Time.time) * 12 / Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum);
        }

        if(Liam.position.y <= -12&&Liam.position.y >= -22)
        {
            riverDragX = 1.25f;
            riverDragY = 0.5f;
        }
        else
        {
            riverDragX = 0;
            riverDragY = 1;
        }
    }

    void FixedUpdate()
    {
        Liam.MovePosition(Liam.position + LiamMovement * LiamSpeed);

        if(!liamResourcesCollected)
        {
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood + 50;
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold + 50;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints + 100;
            liamResourcesCollected = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!Player.gameObject.GetComponent<PlayerActions>().hitByLiam&&col.gameObject.CompareTag("Player"))
        {
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health - liamDamage * Player.gameObject.GetComponent<PlayerActions>().damageResistance * Liam.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance;
            kbEndTime = Time.time + kbTime;
        }
    }
}