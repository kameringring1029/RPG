using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Scout : MonoBehaviour {

    public void ButtonPush() { 
        Debug.Log("Scout pushed");

        SceneManager.LoadScene("Scout");
    }
}
