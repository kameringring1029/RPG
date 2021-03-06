﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour {

    private bool isWalking;
    private int animeindex;
    private int memberindex;
    public Sprite[] walk;
    private float speed = 5.0f;
    private float angle;
    private int angle_p;


    public string id { get; set; }
    public string rarity { get; set; }
    public string name { get; set; }
    public string series { get; set; }
    public string fullimgurl_0 { get; set; }
    public string fullimgurl_1 { get; set; }
    public string info { get; set; }
    public string status_s { get; set; }
    public string status_p { get; set; }
    public string status_c { get; set; }
    public string type { get; set; }



    // Use this for initialization
    void Start () {
        isWalking = false;
        animeindex = 0;
        memberindex = 0;
        angle = 0;
        angle_p = 1;
        

    }

    // Update is called once per frame
    void Update () {

        if (isWalking)
        {
            animeindex++;
            if(animeindex >= walk.Length)
            {
                animeindex = 0;
            }
        //    GetComponent<SpriteRenderer>().sprite = walk[animeindex];

            angle = angle + (0.2f * angle_p);
            if(angle > 3)
            {
                angle = angle * (-1);
                angle_p = angle_p * (-1);
            }
            transform.Rotate(new Vector3(0,0,angle));

        }

        /*
        if (Input.GetButton("Fire1"))
        {
            isWalking = true;
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetButtonUp("Fire1") && isWalking)
        {
            isWalking = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
        */
    }


    // テキスト表示
    void OnGUI()
    {
        /*
        // リセットボタン
        if (GUI.Button(new Rect(5, 5, 150, 75), "リセット"))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }

        if (GUI.Button(new Rect(5,85,150,75), "こうたい"))
        {
            memberindex++;
            if(memberindex >= members.Length)
            {
                memberindex = 0;
            }
            GetComponent<SpriteRenderer>().sprite = members[memberindex];
        }



        if (GUI.Button(new Rect(5, 165, 150, 75), "すすむ"))
        {
            isWalking = true;
            GetComponent<Rigidbody2D>().velocity =
                new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (GUI.Button(new Rect(5, 245, 150, 75), "もどる") && isWalking)
        {
            isWalking = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }

    */
    }
    

}
