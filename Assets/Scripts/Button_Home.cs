using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Home : MonoBehaviour {

    public void ButtonPush()
    {
        Debug.Log("Home pushed");

        Application.LoadLevel("Scout"); // シーンの名前かインデックスを指定
    }
}
