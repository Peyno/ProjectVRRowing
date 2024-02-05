using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TextEndScene_Script : MonoBehaviour
{

    public TextMeshPro txt;

    
    // Start is called before the first frame update
    void Start()
    {
        txt.SetText("Hit Checkpoints = " +  Checkpoint_Collision.ReturnCheckpointCounter()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
