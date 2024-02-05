using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class SpeedFunctionScript : MonoBehaviour
{
    public static float functionV(float x, float skalierungsfaktor, float wachstumsrate)
    {
        
        return skalierungsfaktor * (float)Math.Exp(wachstumsrate * x); 
    }
}
