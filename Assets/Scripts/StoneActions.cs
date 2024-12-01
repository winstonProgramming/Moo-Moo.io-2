using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StoneActions : MonoBehaviour
{
    public Rigidbody2D stoneObj;
    public GameObject Tool;
    public Tool toolScript;
    public PlayerActions playerActions;

    static float stoneHitAffectTime = 0.1f;
    float nextStoneHitAffectTime = 0;
    float halfNextStoneHitAffectTime = 0;
    Vector2 stoneObjMovement;
    Vector2 stoneHitPosition;
    double stoneHitRotation;
    public const double PI = 3.1415926535897931;

    void Update()
    {
        if(Tool.gameObject.GetComponent<Tool>().stoneHit&&Time.time >= nextStoneHitAffectTime)
        {
            nextStoneHitAffectTime = Time.time + stoneHitAffectTime;
            halfNextStoneHitAffectTime = stoneHitAffectTime/2 + Time.time;
            Tool.gameObject.GetComponent<Tool>().stoneHit = false;
        }
        
        stoneHitPosition = stoneObj.position - playerActions.body.position;
        stoneHitRotation = Mathf.Atan2(stoneHitPosition.y, stoneHitPosition.x) * Mathf.Rad2Deg;

        if(Time.time < halfNextStoneHitAffectTime)
        {
            if(stoneHitRotation >= 0)
            {
                stoneObjMovement.x = (float)Math.Cos((stoneHitRotation)*PI/180)/5;
                stoneObjMovement.y = (float)Math.Sin((stoneHitRotation)*PI/180)/5;
            }
            else
            {
                stoneObjMovement.x =  (float)Math.Cos((360 + stoneHitRotation)*PI/180)/5;
                stoneObjMovement.y =  (float)Math.Sin((360 + stoneHitRotation)*PI/180)/5;
            }
        }

        if(Time.time >= halfNextStoneHitAffectTime&&Time.time <= halfNextStoneHitAffectTime + stoneHitAffectTime/2&&Tool.gameObject.GetComponent<Tool>().stoneHitEver)
        {
            if(stoneHitRotation >= 0)
            {
                stoneObjMovement.x = (float)Math.Cos((stoneHitRotation)*PI/180)/-5;
                stoneObjMovement.y = (float)Math.Sin((stoneHitRotation)*PI/180)/-5;
            }
            else
            {
                stoneObjMovement.x =  (float)Math.Cos((360 + stoneHitRotation)*PI/180)/-5;
                stoneObjMovement.y =  (float)Math.Sin((360 + stoneHitRotation)*PI/180)/-5;
            }
        }
        if(Time.time > halfNextStoneHitAffectTime + stoneHitAffectTime/2)
        {
            stoneObjMovement.x = 40 - stoneObj.position.x;
            stoneObjMovement.y = 40 - stoneObj.position.y;
        }

    }
    void FixedUpdate()
    {
        stoneObj.MovePosition(stoneObj.position + stoneObjMovement);
    }
}