using System;
using UnityEngine;
using UnityEngine.UI;

public class Tool : MonoBehaviour
{
    public PlayerActions script;
    public GameObject Player;
    public GameObject Liam_The_Leprechaun;
    public Rigidbody2D tool;
    public Sprite Hammer;
    public Sprite Sword;
    public Sprite Katana;
    
    public const double PI = 3.1415926535897931;
    double offsetx = 0;
    double offsety = 0;
    Vector2 toolMovement;
    public bool stoneHit;
    public bool stoneHitEver;
    public bool woodHit;
    public bool woodHitEver;
    public bool foodHit;
    public bool foodHitEver;
    public bool goldHit;
    public bool goldHitEver;
    public BoxCollider2D toolCollider;
    float toolColliderScaleX;
    float toolColliderScaleY;
    float toolColliderOffsetX;
    float toolColliderOffsetY;
    public int damage;
    public double finalDamage;
    int progression = 1;

    void Update()
    {
        if(Player.gameObject.GetComponent<PlayerActions>().age >= 0&&Player.gameObject.GetComponent<PlayerActions>().age <= 1|Player.gameObject.GetComponent<PlayerActions>().dead)
        {
            tool.gameObject.GetComponent<Tool>().damage = 20;
            tool.gameObject.GetComponent<SpriteRenderer>().sprite = Hammer;
            toolColliderScaleX = 0.97f;
            toolColliderScaleY = 0.63f;
            toolColliderOffsetX = 0;
            toolColliderOffsetY = -1.06f;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().age >= 2&&Player.gameObject.GetComponent<PlayerActions>().age <= 3)
        {
            tool.gameObject.GetComponent<Tool>().damage = 30;
            tool.gameObject.GetComponent<SpriteRenderer>().sprite = Sword;
            toolColliderScaleX = 0.35f;
            toolColliderScaleY = 1.48f;
            toolColliderOffsetX = -0.082f;
            toolColliderOffsetY = -1.825f;
        }
        if(Player.gameObject.GetComponent<PlayerActions>().age >= 4)
        {
            tool.gameObject.GetComponent<Tool>().damage = 40;
            tool.gameObject.GetComponent<SpriteRenderer>().sprite = Katana;
            toolColliderScaleX = 0.69f;
            toolColliderScaleY = 1.85f;
            toolColliderOffsetX = -0.112f;
            toolColliderOffsetY = -2.257f;
        }
        toolCollider.size = new Vector2(toolColliderScaleX, toolColliderScaleY);
        toolCollider.offset = new Vector2(toolColliderOffsetX, toolColliderOffsetY);

        if(Player.gameObject.GetComponent<PlayerActions>().eatingFood)
        {
            tool.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
        }
        else
        {
            tool.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    void FixedUpdate()
    {
        tool.rotation = script.body.rotation + 90;
        if(tool.rotation >= 0)
        {
            offsetx = Math.Cos((tool.rotation)*PI/180) * 0.9f;
            offsety = Math.Sin((tool.rotation)*PI/180) * 0.9f;
        }
        else
        {
            offsetx =  Math.Cos((360 + tool.rotation)*PI/180) * 0.9f;
            offsety =  Math.Sin((360 + tool.rotation)*PI/180) * 0.9f;
        }

        if(!Player.gameObject.GetComponent<PlayerActions>().stopMovement)
        {
            toolMovement.x = script.movement.x * (float)Player.gameObject.GetComponent<PlayerActions>().moveSpeed + (float)offsetx;
            toolMovement.y = script.movement.y * (float)Player.gameObject.GetComponent<PlayerActions>().moveSpeed + (float)offsety;
        }
        else
        {
            toolMovement.x = (float)offsetx;
            toolMovement.y = (float)offsety;
        }

        tool.MovePosition(script.body.position + toolMovement);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Stone_Tag")&&script.firstHalfSwing&&!script.stoneCollected)
        {
            Player.gameObject.GetComponent<PlayerActions>().stone = Player.gameObject.GetComponent<PlayerActions>().stone + progression;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints + progression;
            script.stoneCollected = true;
            stoneHit = true;
            stoneHitEver = true;
        }
        if(col.gameObject.CompareTag("Wood_Tag")&&script.firstHalfSwing&&!script.woodCollected)
        {
            Player.gameObject.GetComponent<PlayerActions>().wood = Player.gameObject.GetComponent<PlayerActions>().wood + progression;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints + progression;
            script.woodCollected = true;
            woodHit = true;
            woodHitEver = true;
        }
        if(col.gameObject.CompareTag("Food_Tag")&&script.firstHalfSwing&&!script.foodCollected)
        {
            Player.gameObject.GetComponent<PlayerActions>().food = Player.gameObject.GetComponent<PlayerActions>().food + progression;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints + progression;
            script.foodCollected = true;
            foodHit = true;
            foodHitEver = true;
        }
        if(col.gameObject.CompareTag("Gold_Tag")&&script.firstHalfSwing&&!script.goldCollected)
        {
            Player.gameObject.GetComponent<PlayerActions>().gold = Player.gameObject.GetComponent<PlayerActions>().gold + progression;
            Player.gameObject.GetComponent<PlayerActions>().agePoints = Player.gameObject.GetComponent<PlayerActions>().agePoints + progression;
            script.goldCollected = true;
            goldHit = true;
            goldHitEver = true;
        }

        finalDamage = damage * Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier * (1 + Player.gameObject.GetComponent<PlayerActions>().age / 100);
        if(col.gameObject.CompareTag("Liam_Tag")&&script.firstHalfSwing&&!script.liamHit)
        {
            Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth = Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealth - finalDamage * Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier;
            if(Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon)
            {
                Player.gameObject.GetComponent<PlayerActions>().health = Player.gameObject.GetComponent<PlayerActions>().health + finalDamage / 4;
            }
            script.liamHit = true;
        }
    }
}