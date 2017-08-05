using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Action : MonoBehaviour
{

    public void ButtonPush()
    {
        Debug.Log("Action pushed");

        SceneManager.LoadScene("Action");
    }
}