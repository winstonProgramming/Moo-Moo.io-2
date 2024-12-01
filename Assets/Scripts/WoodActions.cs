using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WoodActions : MonoBehaviour
{
    public Rigidbody2D woodObj;
    public GameObject Tool;
    public Tool toolScript;
    public PlayerActions playerActions;

    static float woodHitAffectTime = 0.1f;
    float nextWoodHitAffectTime = 0;
    float halfNextWoodHitAffectTime = 0;
    Vector2 woodObjMovement;
    Vector2 woodHitPosition;
    double woodHitRotation;
    public const double PI = 3.1415926535897931;

    void Update()
    {
        if(Tool.gameObject.GetComponent<Tool>().woodHit&&Time.time >= nextWoodHitAffectTime)
        {
            nextWoodHitAffectTime = Time.time + woodHitAffectTime;
            halfNextWoodHitAffectTime = woodHitAffectTime/2 + Time.time;
            Tool.gameObject.GetComponent<Tool>().woodHit = false;
        }
        if(Time.time < halfNextWoodHitAffectTime)
        {
            if(woodHitRotation >= 0)
            {
                woodObjMovement.x = (float)Math.Cos((woodHitRotation)*PI/180)/5;
                woodObjMovement.y = (float)Math.Sin((woodHitRotation)*PI/180)/5;
            }
            else
            {
                woodObjMovement.x =  (float)Math.Cos((360 + woodHitRotation)*PI/180)/5;
                woodObjMovement.y =  (float)Math.Sin((360 + woodHitRotation)*PI/180)/5;
            }
        }
        if(Time.time >= halfNextWoodHitAffectTime&&Time.time <= halfNextWoodHitAffectTime + woodHitAffectTime/2&&Tool.gameObject.GetComponent<Tool>().woodHitEver)
        {
            if(woodHitRotation >= 0)
            {
                woodObjMovement.x = (float)Math.Cos((woodHitRotation)*PI/180)/-5;
                woodObjMovement.y = (float)Math.Sin((woodHitRotation)*PI/180)/-5;
            }
            else
            {
                woodObjMovement.x =  (float)Math.Cos((360 + woodHitRotation)*PI/180)/-5;
                woodObjMovement.y =  (float)Math.Sin((360 + woodHitRotation)*PI/180)/-5;
            }
        }
        if(Time.time > halfNextWoodHitAffectTime + woodHitAffectTime/2)
        {
            woodObjMovement.x = 40 - woodObj.position.x;
            woodObjMovement.y = -40 - woodObj.position.y;
        }
    }
    void FixedUpdate()
    {
        woodObj.MovePosition(woodObj.position + woodObjMovement);
    }
}