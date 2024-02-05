using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System; 

public class Checkpoint_Collision : MonoBehaviour
{

    public GameObject boat; 

    private static int CheckpointCounter = 0;
    public GameObject lastCheckpoint;

    public TextMeshPro txtCheckpoint;

    public static string hitCheckpoint;
    public static string diffMitteCheckpoint;
    public static string hitCheckpointTime;
    public static string boatWinkel; 

    GameObject[] checkpoints;
    private int currentCheckpointIndex = 0; 


    // Start is called before the first frame update
    void Start()
    {
        //checkpoints nach der reihe anzeigen lassen 
        /*
        checkpoints = createChecpointArray();
        Debug.Log("Checkpoints Array Lengt : " + checkpoints.Length.ToString());


        int i = 0;
        foreach (GameObject x in checkpoints)
        {
            if (x != null)
            {
                Debug.Log("Index = " + i.ToString() + " beinhaltet + " + x.name);
                i++;
                x.SetActive(false); 
            }
        }

        checkpoints[currentCheckpointIndex].SetActive(true);
        checkpoints[currentCheckpointIndex + 1].SetActive(true); 
        */



        
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }

   


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Checkpoint")
        {
           // Debug.Log("Hit the Checkpoint");
            CheckpointCounter = CheckpointCounter + 1;

            float centerCheckpoint = collider.bounds.center.x;
            float diffCheckpointPlayer = Math.Abs( centerCheckpoint - transform.position.x); 


            txtCheckpoint.SetText("Hit " + collider.gameObject.name + "\n" + 
                                    "Diff : " + diffCheckpointPlayer.ToString() + "\n" +
                                     "Hit on Time: " + TextTimePlayingScript.time);




            Vector3 vectorboatcheckpoint = collider.transform.position - boat.transform.position;
            float angle = Vector3.Angle(transform.forward, vectorboatcheckpoint); 


            boatWinkel = angle.ToString(); 
            hitCheckpoint = collider.name.ToString();
            diffMitteCheckpoint = diffCheckpointPlayer.ToString();
            hitCheckpointTime = TextTimePlayingScript.time.ToString(); 
            CreateListOfInfosScript.neuerCheckpoint = true;





            //checkpoints nach der reihe anzeigen lasen 
            /*
            checkpoints[currentCheckpointIndex].SetActive(false);
            currentCheckpointIndex++;
            if(currentCheckpointIndex < checkpoints.Length)
            {
                checkpoints[currentCheckpointIndex].SetActive(true);
                checkpoints[currentCheckpointIndex + 1].SetActive(true); 
            }*/
            
            /*
            else
            {
                Debug.Log("Alle checkpoints erreicht"); 
            }*/

        }

        if(collider.gameObject == lastCheckpoint)
        {
            
          //  SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()); 
            SceneManager.LoadScene("EndScene"); 
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            Debug.Log("HIT HIT HIT"); 
        }
    }*/


    public static int ReturnCheckpointCounter()
    {
        return CheckpointCounter; 
    }




    private GameObject[] createChecpointArray()
    {
        int counter = 0; 
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        
        foreach(GameObject x in allGameObjects){
            if(x.tag == "Checkpoint")
            {
                counter++; 
            }
        }

        GameObject[] checkpoints = new GameObject[counter];

        /*
        for(int j = 0; j < checkpoints.Length; j++)
        {
            checkpoints[j] = GameObject.Find("TestObject"); 
        }*/

        
        int index = 1;
        int k = 0;
        bool arrayfull = false;

        for (int u = 0; u < checkpoints.Length-1; u++)
        {
            for (int i = 0; i < allGameObjects.Length; i++)
            {
                if (allGameObjects[i].name == "Checkpoint" + index)
                {
                    checkpoints[k] = allGameObjects[i];
                    k++;
                    index++;
                }

            }

        }


        return checkpoints; 
    }





}
