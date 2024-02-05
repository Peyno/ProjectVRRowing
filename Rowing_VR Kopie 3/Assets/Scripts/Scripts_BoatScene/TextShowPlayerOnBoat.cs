using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class TextShowPlayerOnBoat : MonoBehaviour
{
    public TextMeshPro txt; 
    // Start is called before the first frame update
    void Start()
    {
        txt.SetText("Player : " + KeypadInteraction.playerNumber.ToString());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
