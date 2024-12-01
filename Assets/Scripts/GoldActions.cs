using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GoldActions : MonoBehaviour
{
    public Rigidbody2D goldObj;
    public GameObject Tool;
    public Tool toolScript;
    public PlayerActions playerActions;

    static float goldHitAffectTime = 0.1f;
    float nextGoldHitAffectTime = 0;
    float halfNextGoldHitAffectTime = 0;
    Vector2 goldObjMovement;
    Vector2 goldHitPosition;
    double goldHitRotation;
    public const double PI = 3.1415926535897931;

    void Update()
    {
        if(Tool.gameObject.GetComponent<Tool>().goldHit&&Time.time >= nextGoldHitAffectTime)
        {
            nextGoldHitAffectTime = Time.time + goldHitAffectTime;
            halfNextGoldHitAffectTime = goldHitAffectTime/2 + Time.time;
            Tool.gameObject.GetComponent<Tool>().goldHit = false;
        }

        goldHitPosition = goldObj.position - playerActions.body.position;
        goldHitRotation = Mathf.Atan2(goldHitPosition.y, goldHitPosition.x) * Mathf.Rad2Deg;

        if(Time.time < halfNextGoldHitAffectTime)
        {
            if(goldHitRotation >= 0)
            {
                goldObjMovement.x = (float)Math.Cos((goldHitRotation)*PI/180)/5;
                goldObjMovement.y = (float)Math.Sin((goldHitRotation)*PI/180)/5;
            }
            else
            {
                goldObjMovement.x =  (float)Math.Cos((360 + goldHitRotation)*PI/180)/5;
                goldObjMovement.y =  (float)Math.Sin((360 + goldHitRotation)*PI/180)/5;
            }
        }
        if(Time.time >= halfNextGoldHitAffectTime&&Time.time <= halfNextGoldHitAffectTime + goldHitAffectTime/2&&Tool.gameObject.GetComponent<Tool>().goldHitEver)
        {
            if(goldHitRotation >= 0)
            {
                goldObjMovement.x = (float)Math.Cos((goldHitRotation)*PI/180)/-5;
                goldObjMovement.y = (float)Math.Sin((goldHitRotation)*PI/180)/-5;
            }
            else
            {
                goldObjMovement.x =  (float)Math.Cos((360 + goldHitRotation)*PI/180)/-5;
                goldObjMovement.y =  (float)Math.Sin((360 + goldHitRotation)*PI/180)/-5;
            }
        }
        if(Time.time > halfNextGoldHitAffectTime + goldHitAffectTime/2)
        {
            goldObjMovement.x = -40 - goldObj.position.x;
            goldObjMovement.y = 40 - goldObj.position.y;
        }
    }
    void FixedUpdate()
    {
        goldObj.MovePosition(goldObj.position + goldObjMovement);
    }
}