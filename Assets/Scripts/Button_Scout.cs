using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Scout : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* アイコンを選択時 */
    public void OnMouseDown()
    {
        Debug.Log("Home pushed");

        Application.LoadLevel("main_scene"); // シーンの名前かインデックスを指定
    }
}
