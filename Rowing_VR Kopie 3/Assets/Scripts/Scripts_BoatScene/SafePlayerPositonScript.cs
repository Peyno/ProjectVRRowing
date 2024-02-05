using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System; 
public class SafePlayerPositonScript : MonoBehaviour
{


    string filePath;
    string fileName; 
    public GameObject player;

    private StreamWriter sr;



 
    // Start is called before the first frame update
    void Start()
    {
        string time = DateTime.Now.ToShortTimeString(); 


        Debug.Log("Datenpfad = " + Application.persistentDataPath);

       // filePath =   "/Users/heikotausch/Desktop/RowingPlayerPositon"; 
       filePath = Application.persistentDataPath; 
       fileName = "/CordsFromPlayer_" + KeypadInteraction.playerNumber.ToString() + "_Lenkunt_" + ButtonInteraction.lenkungID.ToString() + "_Kurs_" + ButtonInteraction.kursID.ToString() + "___" + time ;
       //fileName = "/99"; 
         sr = File.CreateText(filePath + fileName);
        // sr.WriteLine("Moin Zusammen");
        //  sr.Close();



        InvokeRepeating("safePosition", 0f, 1f);
       




    }

    // Update is called once per frame
    void Update()
    {

        sr.WriteLine("PlayerPositon : " + player.transform.position + "\t time : " + Time.time.ToString());



    }

  
  
}
