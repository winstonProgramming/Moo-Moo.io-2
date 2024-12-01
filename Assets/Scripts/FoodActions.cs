using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FoodActions : MonoBehaviour
{
    public Rigidbody2D foodObj;
    public GameObject Tool;
    public Tool toolScript;
    public PlayerActions playerActions;

    static float foodHitAffectTime = 0.1f;
    float nextFoodHitAffectTime = 0;
    float halfNextFoodHitAffectTime = 0;
    Vector2 foodObjMovement;
    Vector2 foodHitPosition;
    double foodHitRotation;
    public const double PI = 3.1415926535897931;

    void Update()
    {
        if(Tool.gameObject.GetComponent<Tool>().foodHit&&Time.time >= nextFoodHitAffectTime)
        {
            nextFoodHitAffectTime = Time.time + foodHitAffectTime;
            halfNextFoodHitAffectTime = foodHitAffectTime/2 + Time.time;
            Tool.gameObject.GetComponent<Tool>().foodHit = false;
        }

        foodHitPosition = foodObj.position - playerActions.body.position;
        foodHitRotation = Mathf.Atan2(foodHitPosition.y, foodHitPosition.x) * Mathf.Rad2Deg;

        if(Time.time < halfNextFoodHitAffectTime)
        {
            if(foodHitRotation >= 0)
            {
                foodObjMovement.x = (float)Math.Cos((foodHitRotation)*PI/180)/5;
                foodObjMovement.y = (float)Math.Sin((foodHitRotation)*PI/180)/5;
            }
            else
            {
                foodObjMovement.x =  (float)Math.Cos((360 + foodHitRotation)*PI/180)/5;
                foodObjMovement.y =  (float)Math.Sin((360 + foodHitRotation)*PI/180)/5;
            }
        }
        if(Time.time >= halfNextFoodHitAffectTime&&Time.time <= halfNextFoodHitAffectTime + foodHitAffectTime/2&&Tool.gameObject.GetComponent<Tool>().foodHitEver)
        {
            if(foodHitRotation >= 0)
            {
                foodObjMovement.x = (float)Math.Cos((foodHitRotation)*PI/180)/-5;
                foodObjMovement.y = (float)Math.Sin((foodHitRotation)*PI/180)/-5;
            }
            else
            {
                foodObjMovement.x =  (float)Math.Cos((360 + foodHitRotation)*PI/180)/-5;
                foodObjMovement.y =  (float)Math.Sin((360 + foodHitRotation)*PI/180)/-5;
            }
        }
        if(Time.time > halfNextFoodHitAffectTime + foodHitAffectTime/2)
        {
            foodObjMovement.x = -40 - foodObj.position.x;
            foodObjMovement.y = -40 - foodObj.position.y;
        }
    }
    void FixedUpdate()
    {
        foodObj.MovePosition(foodObj.position + foodObjMovement);
    }
}
