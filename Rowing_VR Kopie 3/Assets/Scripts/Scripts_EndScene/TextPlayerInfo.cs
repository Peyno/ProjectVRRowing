using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System; 
public class TextPlayerInfo : MonoBehaviour
{


    public TextMeshPro txt;

    string filePath;
    string filename;
    StreamWriter sw;

 



    List<string[]> l = new List<string[]>();
    string[] s = new string[6];


    // Start is called before the first frame update
    void Start()
    {
        txt.SetText("PlayerNumber \t" + "LenkungID \t" + "kursID \t" + "Checkpoint\t"  +  "TimeHitCheckpoint\t" + "DiffMitte\t" + "BoatWinkel" + "\n");


       printPlayerInfo(CreateListOfInfosScript.playerInfos);





        /*
        s[0] = "0";
        s[1] = "0";
        s[2] = "0";
        s[3] = "checkpoint";
        s[4] = "55";
        s[5] = "20";
        l.Add(s);
        */
      createTSV(CreateListOfInfosScript.playerInfos);


       


    }

    // Update is called once per frame
    void Update()
    {
        
    }





    void printPlayerInfo(List<string[]> list)
    {
        

        foreach(string[] x in list)
        {
            string zeilen = "";
            for (int i = 0; i < x.Length; i++)
            {
            
                zeilen += ("" + x[i] + "\t\t\t"); 
            }
            txt.text += (zeilen + "\n"); 
          
        }
    }



    void createTSV(List<string[]> list)
    {


        filePath = Application.persistentDataPath;
       // filename = "/1"; 
        filename = "/InfosPlayer_" + KeypadInteraction.playerNumber.ToString() + "_Lenkung_" + ButtonInteraction.lenkungID.ToString() + "_Kurs_" +ButtonInteraction.kursID.ToString() + "__" + DateTime.Now.ToShortTimeString()  + ".tsv";
        sw = File.CreateText(filePath + filename);

        sw.WriteLine("PlayerNumber\tLenkungID\tKursID\tCheckpoint\tCheckpointHitTime\tCheckpointDiff\tBoatWinkel");
       


   
        
        foreach (string[] x in list)
        {
            string zeilen = "";
            for (int i = 0; i < x.Length; i++)
            {
                zeilen += ("" + x[i] + "\t");
            }
            sw.WriteLine(zeilen );
        }


        sw.Close();
    }


    
    


}
