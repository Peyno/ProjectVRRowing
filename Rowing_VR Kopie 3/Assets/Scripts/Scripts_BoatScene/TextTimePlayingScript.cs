using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTimePlayingScript : MonoBehaviour
{

    public TextMeshPro txt;
    public static float time = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Text_Countdown.CountdownFinished)
        {
            time += Time.deltaTime;
            txt.SetText("Time Playing : " + time.ToString()); 
        }
    }
}
