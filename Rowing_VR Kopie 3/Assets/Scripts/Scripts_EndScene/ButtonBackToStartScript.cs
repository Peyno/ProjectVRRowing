using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonBackToStartScript : MonoBehaviour
{
    public void ButtonBackToStart()
    {
        SceneManager.LoadScene("StartScene_Lake"); 
    }

}
