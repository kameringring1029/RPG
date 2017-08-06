using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Right : MonoBehaviour {
    
    private Animation_Player Player;

   
    void Start()
    {
        Player = GameObject.Find("UnityChan").GetComponent<Animation_Player>();
    }


    // Update is called once per frame
    void Update () {
        

    }

    public void OnRightDown()
    {
        Player.setX(1);
    }

    public void OnRightUp()
    {
        Player.setX(0);
    }
}
