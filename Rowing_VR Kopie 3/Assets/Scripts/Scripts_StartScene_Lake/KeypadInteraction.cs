using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadInteraction : MonoBehaviour
{
    public TextMeshPro txt;

    public static int playerNumber; 

    private string player = ""; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressed1()
    {
        player += "1";
        txt.SetText(player); 
    }
    public void pressed2()
    {
        player += "2";
        txt.SetText(player);

    }
    public void pressed3()
    {
        player += "3";
        txt.SetText(player);

    }
    public void pressed4()
    {
        player += "4";
        txt.SetText(player);

    }
    public void pressed5()
    {
        player += "5";
        txt.SetText(player);

    }
    public void pressed6()
    {
        player += "6";
        txt.SetText(player);

    }
    public void pressed7()
    {
        player += "7";
        txt.SetText(player);

    }
    public void pressed8()
    {
        player += "8";
        txt.SetText(player);

    }
    public void pressed9()
    {
        player += "9";
        txt.SetText(player);

    }
    public void pressed0()
    {
        player += "0";
        txt.SetText(player);

    }
    public void pressedReset()
    {
        player = "";
        txt.SetText(player);

    }

    public void pressedEnter()
    {
        playerNumber = int.Parse(player);
        txt.SetText("SUCCESSFUL \n" +
                    "Player : " + playerNumber.ToString()); 
    }
}
