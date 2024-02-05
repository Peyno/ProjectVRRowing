using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonInteraction : MonoBehaviour
{

    public static float lenkungID; // 0 = Vertikal ; 1 = Horizontal; 2 = relocation
    public static float kursID; // 0 = Training; 1 = Level1; 2 = Level2; 3 = Level3


    //Vertikal Scenes

    public void ButtonLoadSceneVerticalTraining()
    {
        SceneManager.LoadScene("VerticalTrainingScene");
        lenkungID = 0;
        kursID = 0; 
    }

    public void ButtonLoadSceneVerticalLevel1()
    {
        SceneManager.LoadScene("VerticalLevel1Scene"); 
        lenkungID = 0;
        kursID = 1; 
    }

    public void ButtonLoadSceneVerticalLevel2()
    {
        SceneManager.LoadScene("VerticalLevel2Scene"); 
        lenkungID = 0;
        kursID = 2; 
    }

    public void ButtonLoadSceneVerticalLevel3()
    {
        SceneManager.LoadScene("VerticalLevel3Scene"); 
        lenkungID = 0;
        kursID = 3; 
    }


    //Horizontal Scenes

    public void ButtonLoadSceneHorizontalTraining()
    {
        SceneManager.LoadScene("HorizontalTrainingScene");
        lenkungID = 1;
        kursID = 0; 
    }
    public void ButtonLoadSceneHorizontalLevel1()
    {
        SceneManager.LoadScene("HorizontalLevel1Scene"); 
        lenkungID = 1;
        kursID = 1; 
    }
    public void ButtonLoadSceneHorizontalLevel2()
    {
        SceneManager.LoadScene("HorizontalLevel2Scene"); 
        lenkungID = 1;
        kursID = 2; 
    }
    public void ButtonLoadSceneHorizontalLevel3()
    {
        SceneManager.LoadScene("HorizontalLevel3Scene"); 
        lenkungID = 1;
        kursID = 3; 
    }


    //Relocation Scenes

    public void ButtonLoadSceneRelocationTraining()
    { 
        SceneManager.LoadScene("RelocationTrainingScene");
        lenkungID = 2;
        kursID = 0; 
    }

    public void ButtonLoadSceneRelocationLevel1()
    {
        SceneManager.LoadScene("RelocationLevel1Scene"); 
        lenkungID = 2;
        kursID = 1; 
    }
    public void ButtonLoadSceneRelocationLevel2()
    {
        SceneManager.LoadScene("RelocationLevel2Scene");
        lenkungID = 2;
        kursID = 2;
    }
    public void ButtonLoadSceneRelocationLevel3()
    {
        SceneManager.LoadScene("RelocationLevel3Scene"); 
        lenkungID = 2;
        kursID = 3; 
    }

}
