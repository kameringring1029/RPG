using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Scout : MonoBehaviour {

    public GameObject Canvas_Scout;

    public void ButtonPush() { 
        Debug.Log("Scout pushed");

        Canvas_Scout.SetActive(true);
        //GameObject.Find("Canvas_Action").GetComponent<Canvas>().enabled = false;

        //SceneManager.LoadScene("Scout");
    }
}
