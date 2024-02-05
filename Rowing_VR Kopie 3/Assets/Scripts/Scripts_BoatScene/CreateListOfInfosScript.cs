using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class CreateListOfInfosScript : MonoBehaviour
{



    /*
     * 
     * float[0] = PlayerNumber
     * float[1] = LenkungID (0 = Vertikal; 1 = Horizontal; 2 = relocation)
     * float[2] = KursID (0 = Training; 1 = leicht; 2 = mittel; 3 = schwer)
     * float[3] = Checkpoint
     * float[4] = Checkpoint Hit Time
     * float[5] = Diff zur Mitte von Checkpoint
     * float[6] = Lenkwinkel
     *
     * */
    public static List<string[]> playerInfos;
    private int lengthArray = 7; 

    private string playerNumber;
    private string lenkungID;
    private string kursID;
    private string ckeckpoint = "null";
    private string time;
    private string diffMitteCheckpoint;
    private string boatWinkel; 
    


    public static bool neuerCheckpoint = false;


    
    

    // Start is called before the first frame update
    void Start()
    {
        playerInfos = new List<string[]>();

        playerNumber = KeypadInteraction.playerNumber.ToString();
        lenkungID = ButtonInteraction.lenkungID.ToString();
        kursID = ButtonInteraction.kursID.ToString();


       

    }

    // Update is called once per frame
    void Update()
    {

        if (neuerCheckpoint){

           
            ckeckpoint = Checkpoint_Collision.hitCheckpoint;
            diffMitteCheckpoint = Checkpoint_Collision.diffMitteCheckpoint;
            time = Checkpoint_Collision.hitCheckpointTime;
            boatWinkel = Checkpoint_Collision.boatWinkel; 

            string[] data = new string[lengthArray];

            data[0] = playerNumber;
            data[1] = lenkungID;
            data[2] = kursID;
            data[3] = ckeckpoint;
            data[4] = time;
            data[5] = diffMitteCheckpoint;
            data[6] = boatWinkel; 


            playerInfos.Add(data);


            neuerCheckpoint = false; 
        }

    }


   


}
