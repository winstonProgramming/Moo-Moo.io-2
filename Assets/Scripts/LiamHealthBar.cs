using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamHealthBar : MonoBehaviour
{
    public GameObject Liam_The_LeprechaunObj;
    public Rigidbody2D LiamHealthBarRB;
    Vector2 liamBarCoords;
    public Vector2 healthBarCoords;

    void Update()
    {
        liamBarCoords.x = (float)Liam_The_LeprechaunObj.gameObject.GetComponent<Liam_The_Leprechaun>().liamHealthRatio;
        liamBarCoords.y = 1;
        Transform liamBar = transform.Find("LiamBar");
        liamBar.localScale = liamBarCoords;
        healthBarCoords.x = (float)Liam_The_LeprechaunObj.gameObject.GetComponent<Liam_The_Leprechaun>().LiamPositionX;
        healthBarCoords.y = (float)Liam_The_LeprechaunObj.gameObject.GetComponent<Liam_The_Leprechaun>().LiamPositionY - 1.6f;
        LiamHealthBarRB.MovePosition(healthBarCoords + Liam_The_LeprechaunObj.gameObject.GetComponent<Liam_The_Leprechaun>().LiamMovement * Liam_The_LeprechaunObj.gameObject.GetComponent<Liam_The_Leprechaun>().LiamSpeed);
    }
}