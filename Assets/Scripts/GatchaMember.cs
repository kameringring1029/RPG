﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaMember : MonoBehaviour
{


    public Sprite[] envelopeIcon;


    /* setter, getter付きプロパティ */
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    /* アイコンを選択時 */
    public void OnMouseDown()
    {
        Debug.Log("pushed");
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("envelope_Player").GetComponent<SpriteRenderer>().sprite = envelopeIcon[Int32.Parse(rarity)];

        /* Playerに反映 */
        Player playerObj = GameObject.Find("Player").GetComponent<Player>();
        playerObj.id = this.id;
        playerObj.rarity = this.rarity;
        playerObj.name = this.name;
        playerObj.series = this.series;
        playerObj.fullimgurl_0 = this.fullimgurl_0;
        playerObj.info = this.info;
        playerObj.status_s = this.status_s;
        playerObj.status_p = this.status_p;
        playerObj.status_c = this.status_c;
        playerObj.type = this.type;

        Debug.Log("[Player]" + playerObj.name + "(" + playerObj.series + "):" + playerObj.type + "," + playerObj.status_s + "," + playerObj.status_p + "," + playerObj.status_c);


    }
}