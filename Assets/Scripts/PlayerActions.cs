using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System;
using UnityEngine;

//vince
//bull
//duck
//age bar
//teleport
//boster pad
//healing pad
//green apple
//red assassin
//infernal bow
//jetpack

public class PlayerActions : MonoBehaviour
{
    public Rigidbody2D body;
    public Camera cam;
    public GameObject Player;
    public GameObject Helmet;
    public GameObject Liam_The_Leprechaun;
    
    public const double PI = 3.1415926535897931;
    public int stone = 0;
    public int wood = 0;
    public int food = 0;
    public int gold = 0;
    public int maxHealth = 100;
    public int maxHealthHatBonus = 0;
    public double health = 100;
    public int age = 0;
    public int agePoints = 0;
    public float moveSpeed;
    public double cooldownTime;
    double nextFireTime = 0;
    double halfSwingTime = 0;
    public bool stoneCollected;
    public bool woodCollected;
    public bool foodCollected;
    public bool goldCollected;
    public Vector2 movement;
    Vector2 mousePos;
    Vector2 lookDir;
    public bool swinging;
    bool autoSwing;
    public bool stopMovement;
    public bool firstHalfSwing;
    public bool bullHelmetHealthDecay;
    public bool healingHelmetHealthRegen;
    public bool berserkerHelmetHealthSyphon;
    public bool assassinHelmetNoHeal;
    double riverDragX;
    double riverDragY = 1;
    public double lavaDrag = 1;
    public double healthRatio = 1;
    bool age1HealthBump;
    bool age2HealthBump;
    bool age3HealthBump;
    bool age4HealthBump;
    bool age5HealthBump;
    bool age6HealthBump;
    bool age7HealthBump;
    bool age8HealthBump;
    bool age9HealthBump;
    bool age10HealthBump;
    public bool dead;
    public float helmetDamageMultiplier = 1;
    public float damageResistance = 1;
    public bool eatingFood;
    public int foodCost = 5;
    public int foodHealing = 20;
    public bool liamHit;
    public bool hitByLiam;
    public Vector2 liamBounce;
    float eatingFoodSpeed;
    
    void Update()
    {
        if(!Player.gameObject.GetComponent<PlayerActions>().dead&&!hitByLiam)
        {
            movement.x = (float)Input.GetAxis("Horizontal") * (float)Player.gameObject.GetComponent<PlayerActions>().lavaDrag * eatingFoodSpeed + (float)riverDragX;
            movement.y = (float)Input.GetAxis("Vertical") * (float)riverDragY * (float)Player.gameObject.GetComponent<PlayerActions>().lavaDrag * eatingFoodSpeed;
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Player.gameObject.GetComponent<PlayerActions>().dead&&hitByLiam|Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            movement.x = 0;
            movement.y = 0;
        }
        if(hitByLiam)
        {
            movement.x = liamBounce.x;
            movement.y = liamBounce.y;
        }

        lookDir = mousePos - body.position;
        
        if(Time.time > nextFireTime)
        {
            if(Input.GetMouseButtonDown(0)&&!Player.gameObject.GetComponent<PlayerActions>().dead&&!Player.gameObject.GetComponent<PlayerActions>().eatingFood)
            {
                swinging = true;
                firstHalfSwing = true;
                nextFireTime = Time.time + Player.gameObject.GetComponent<PlayerActions>().cooldownTime;
                halfSwingTime = Player.gameObject.GetComponent<PlayerActions>().cooldownTime/5 + Time.time;
            }
            else
            {
                swinging = false;
                body.rotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            }
        }

        if(Input.GetKeyDown(KeyCode.E)&&!Player.gameObject.GetComponent<PlayerActions>().eatingFood&&!Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            if(!autoSwing)
            {
                autoSwing = true;
            }
            else
            {
                autoSwing = false;
            }
        }

        if (autoSwing&&!swinging)
        {
            if(Time.time > nextFireTime + 0.04)
            {
                swinging = true;
                firstHalfSwing = true;
                nextFireTime = Time.time + Player.gameObject.GetComponent<PlayerActions>().cooldownTime;
                halfSwingTime = Player.gameObject.GetComponent<PlayerActions>().cooldownTime/5 + Time.time;
            }
        }

        if(body.position.y <= -12&&body.position.y >= -22)
        {
            riverDragX = 1.25f;
            riverDragY = 0.5f;
        }
        else
        {
            riverDragX = 0;
            riverDragY = 1;
        }

        maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;

        healthRatio = Player.gameObject.GetComponent<PlayerActions>().health/Player.gameObject.GetComponent<PlayerActions>().maxHealth;

        if(Player.gameObject.GetComponent<PlayerActions>().health <= 0)
        {
            Player.gameObject.GetComponent<PlayerActions>().dead = true;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = 0;
            Player.gameObject.GetComponent<PlayerActions>().wood = 0;
            Player.gameObject.GetComponent<PlayerActions>().food = 0;
            Player.gameObject.GetComponent<PlayerActions>().gold = 0;
            Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
            Player.gameObject.GetComponent<PlayerActions>().health = 100;
            Player.gameObject.GetComponent<PlayerActions>().age = 0;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = 0;
            Player.gameObject.GetComponent<PlayerActions>().damageResistance = 0;
            movement.x = 0 - body.position.x;
            movement.y = 0 - body.position.y;
            body.rotation = 0;
            age1HealthBump = false;
            age2HealthBump = false;
            age4HealthBump = false;
            age5HealthBump = false;
            age6HealthBump = false;
            age7HealthBump = false;
            age8HealthBump = false;
            age9HealthBump = false;
            age10HealthBump = false;
            Helmet.gameObject.GetComponent<Helmet>().helmetNum = 0;
            Helmet.gameObject.GetComponent<Shop>().boosterHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().soldierHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().bullHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().healingHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().samuraiHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().berserkerHelmetPurchased = false;
            Helmet.gameObject.GetComponent<Shop>().assassinHelmetPurchased = false;
            Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetPurchased = false;
            Player.gameObject.GetComponent<PlayerActions>().eatingFood = false;
            autoSwing = false;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            Player.gameObject.GetComponent<PlayerActions>().dead = false;
        }

        if(Player.gameObject.GetComponent<PlayerActions>().health > Player.gameObject.GetComponent<PlayerActions>().maxHealth)
        {
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().maxHealth;
        }

        if(Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay)
        {
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health - 0.003f;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen)
        {
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 0.001f;
        }

        if(age == 0&&agePoints >= 5)
        {
            age = 1;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 5;
            if(!age1HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age1HealthBump = true;
            }
        }
        if(age == 1&&agePoints >= 10)
        {
            age = 2;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 10;
            if(!age2HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age2HealthBump = true;
            }
        }
        if(age == 2&&agePoints >= 20)
        {
            age = 3;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 20;
            if(!age3HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age3HealthBump = true;
            }
        }
        if(age == 3&&agePoints >= 80)
        {
            age = 4;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 80;
            if(!age4HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age4HealthBump = true;
            }
        }
        if(age == 4&&agePoints >= 160)
        {
            age = 5;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 160;
            if(!age5HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age5HealthBump = true;
            }
        }
        if(age == 5&&agePoints >= 320)
        {
            age = 6;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 320;
            if(!age6HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age6HealthBump = true;
            }
        }
        if(age == 6&&agePoints >= 640)
        {
            age = 7;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 640;
            if(!age7HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age7HealthBump = true;
            }
        }
        if(age == 7&&agePoints >= 1280)
        {
            age = 8;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 1280;
            if(!age8HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age8HealthBump = true;
            }
        }
        if(age == 8&&agePoints >= 2520)
        {
            age = 9;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 2520;
            if(!age9HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age9HealthBump = true;
            }
        }
        if(age == 9&&agePoints >= 5120)
        {
            age = 10;
            maxHealth = 100 + age + Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints - 5120;
            if(!age10HealthBump)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + 1;
                age10HealthBump = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)&&Player.gameObject.GetComponent<PlayerActions>().food >= Player.gameObject.GetComponent<PlayerActions>().foodCost&&!Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal)
        {
            Player.gameObject.GetComponent<PlayerActions>().eatingFood = !Player.gameObject.GetComponent<PlayerActions>().eatingFood;
            autoSwing = false;
        }
        if (Player.gameObject.GetComponent<PlayerActions>().eatingFood)
        {
           eatingFoodSpeed = 0.5f;
        }
        else
        {
            eatingFoodSpeed = 1;
        }
        if(Input.GetMouseButtonDown(1)&&!Player.gameObject.GetComponent<PlayerActions>().dead&&Player.gameObject.GetComponent<PlayerActions>().eatingFood&&Player.gameObject.GetComponent<PlayerActions>().health != Player.gameObject.GetComponent<PlayerActions>().maxHealth)
        {
            Player.gameObject.GetComponent<PlayerActions>().eatingFood = false;
            Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + Player.gameObject.GetComponent<PlayerActions>().foodHealing;
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food - Player.gameObject.GetComponent<PlayerActions>().foodCost;
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed);
        
        if(swinging)
        {
            if(Time.time < halfSwingTime)
            {
                body.rotation = body.rotation + 1.5f / (float)Player.gameObject.GetComponent<PlayerActions>().cooldownTime;
            }
            else
            {
                stoneCollected = false;
                woodCollected = false;
                foodCollected = false;
                goldCollected = false;
                liamHit = false;
                firstHalfSwing = false;
                body.rotation = body.rotation - 0.375f / (float)Player.gameObject.GetComponent<PlayerActions>().cooldownTime;
            }
        }

        if(body.position.x > 79.5f)
        {
            movement.x = (49.5f - body.position.x) * 8;
        }
        if(body.position.y > 69.5f)
        {
            movement.y = (49.5f - body.position.y) * 8;
        }
        if(body.position.x < -79.5f)
        {
            movement.x = (49.5f - body.position.x) * 8;
        }
        if(body.position.y < -59.5f)
        {
            movement.y = (-49.5f - body.position.y) * 8;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Stone_Tag")|col.gameObject.CompareTag("Wood_Tag")|col.gameObject.CompareTag("Food_Tag")|col.gameObject.CompareTag("Gold_Tag")|col.gameObject.CompareTag("Border_Tag"))
        {
            stopMovement = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Stone_Tag")|col.gameObject.CompareTag("Wood_Tag")|col.gameObject.CompareTag("Food_Tag")|col.gameObject.CompareTag("Gold_Tag")|col.gameObject.CompareTag("Border_Tag"))
        {
            stopMovement = false;
        }
    }
}