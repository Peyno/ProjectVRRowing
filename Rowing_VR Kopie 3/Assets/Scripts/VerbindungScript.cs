using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbindungScript : MonoBehaviour
{


    public static float v; 

    public void m(string s)
    {
        MyDataObject data = JsonUtility.FromJson<MyDataObject>(s);

        v = data.speed / 100;

        Debug.Log("Geschwindigkeit" + v); 
    }
}
public class MyDataObject
{
    public float speed;

    // Füge hier weitere Felder hinzu, die deiner JSON-Struktur entsprechen
}