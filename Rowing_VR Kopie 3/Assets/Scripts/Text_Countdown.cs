using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 

public class Text_Countdown : MonoBehaviour
{
    public TextMeshPro txt;
    

    public float count;
    public static Boolean CountdownFinished = false; 

    // Start is called before the first frame update
    void Start()
    {
        //  txt = GetComponent<TextMeshPro>();
        CountdownFinished = false; 

    }
   

    private void Update()
    {
        if(count >= 0)
        {
           
            txt.SetText(Math.Round(count).ToString());
            count = count -1 * Time.deltaTime;

        }

        // wenn der Countdown fertig ist 
        if(count <= 1 && !CountdownFinished)
        {
           // OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch); 
           
            
            ToggleVisibility();
            CountdownFinished = true;
        }
        
    }

    void ToggleVisibility()
    {
        txt.enabled = !txt.enabled;
    }


}
