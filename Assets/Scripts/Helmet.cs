using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    public PlayerActions playerActions;
    public GameObject Liam_The_Leprechaun;
    public Shop shop;
    public GameObject Player;
    public Sprite BoosterHelmet;
    public Sprite SoldierHelmet;
    public Sprite BullHelmet;
    public Sprite HealingHelmet;
    public Sprite SamuraiHelmet;
    public Sprite BerserkerHelmet;
    public Sprite AssassinHelmet;
    public Sprite LiamHelmet;
    public Sprite GodHelmet;
    public Sprite None;
    [SerializeField]Rigidbody2D helmet;
    public int helmetNum = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            helmetNum = 0;
        }
        if (shop.boosterHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad1))
        {
            helmetNum = 1;
        }
        if (shop.soldierHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad2))
        {
            helmetNum = 2;
        }
        if (shop.bullHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad3))
        {
            helmetNum = 3;
        }
        if (shop.healingHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad4))
        {
            helmetNum = 4;
        }
        if (shop.samuraiHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad5))
        {
            helmetNum = 5;
        }
        if (shop.berserkerHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad6))
        {
            helmetNum = 6;
        }
        if (shop.assassinHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad7))
        {
            helmetNum = 7;
        }
        if (Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetPurchased&&Input.GetKeyDown(KeyCode.Keypad8))
        {
            helmetNum = 8;
        }
        if (shop.godHelmetPurchased&&Input.GetKey(KeyCode.R)&&Input.GetKey(KeyCode.L)&&Input.GetKey(KeyCode.LeftShift))
        {
            helmetNum = 100;
        }

        switch(helmetNum)
        {
            case 0://None
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = None;
                break;
            case 1://Booster Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.19f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = BoosterHelmet;
                break;
            case 2://Solider Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.13f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 0.8f;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = SoldierHelmet;
                break;
            case 3://Bull Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1.5f;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = true;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = BullHelmet;
                break;
            case 4://Healing Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 20;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = true;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = HealingHelmet;
                break;
            case 5://Samurai Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.45f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = SamuraiHelmet;
                break;
            case 6://Berserker Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1.2f;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = true;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = BerserkerHelmet;
                break;
            case 7://Assassin Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 1;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = true;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1;
                playerActions.body.bodyType = RigidbodyType2D.Kinematic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = AssassinHelmet;
                break;
            case 8://Liam Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.15f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 1;
                    Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamDamageResistance = 0.8f;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 1;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamHelmetDamageMultiplier = 1.5f;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.6f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 0;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = false;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = false;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1.2f;
                playerActions.body.bodyType = RigidbodyType2D.Dynamic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = LiamHelmet;
                break;
            case 100://God Helmet
                Player.gameObject.GetComponent<PlayerActions>().moveSpeed = 0.25f;
                if(!Player.gameObject.GetComponent<PlayerActions>().dead)
                {
                    Player.gameObject.GetComponent<PlayerActions>().damageResistance = 0.5f;
                }
                Player.gameObject.GetComponent<PlayerActions>().helmetDamageMultiplier = 3;
                Player.gameObject.GetComponent<PlayerActions>().cooldownTime = 0.3f;
                Player.gameObject.GetComponent<PlayerActions>().maxHealthHatBonus = 500;
                Player.gameObject.GetComponent<PlayerActions>().healingHelmetHealthRegen = true;
                Player.gameObject.GetComponent<PlayerActions>().bullHelmetHealthDecay = false;
                Player.gameObject.GetComponent<PlayerActions>().berserkerHelmetHealthSyphon = true;
                Player.gameObject.GetComponent<PlayerActions>().assassinHelmetNoHeal = false;
                Liam_The_Leprechaun.gameObject.GetComponent<Liam_The_Leprechaun>().liamKBNum = 1.5f;
                playerActions.body.bodyType = RigidbodyType2D.Kinematic;
                helmet.gameObject.GetComponent<SpriteRenderer>().sprite = GodHelmet;
                Player.gameObject.GetComponent<PlayerActions>().food = 10000;
                Player.gameObject.GetComponent<PlayerActions>().age = 4;
                break;
        }
    }

    void FixedUpdate()
    {
        helmet.rotation = playerActions.body.rotation;
        if(!Player.gameObject.GetComponent<PlayerActions>().stopMovement)
        {
            helmet.position = playerActions.body.position + playerActions.movement * (float)Player.gameObject.GetComponent<PlayerActions>().moveSpeed;
        }
        else
        {
            helmet.position = playerActions.body.position;
        }
    }
}