﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Action : MonoBehaviour
{

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
        Debug.Log("Action pushed");

        SceneManager.LoadScene("Action");
    }
}