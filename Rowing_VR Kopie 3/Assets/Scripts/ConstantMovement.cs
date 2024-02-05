using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    private static float speed = 10f; //Geschwindigkeit des Spielers
    private float Diff = 5; //Differenz die zwischen den Händen sein muss um zu lenken
    private float RotationSpeed = 1;  


    private float LeftHandY;
    private float RightHandY;

    private float DiffLinksdrehung; //Diff Linksdrehung
    private float DiffRechtsdrehung; //Diff Rechtsdrehung
    private float minDiff = 5f;
    private float maxDiff = 50f; 


    Vector3 moveDirection;

    public GameObject LeftHand;
    public GameObject RightHand;

    private float smoothness = 3; 
    // Start is called before the first frame update
    void Start()
    {
        
                //ruft die Methode increaseSpeed alle 10 Sekunden auf
               // InvokeRepeating("increaseSpeed", 0f, 10f);
            
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //Begrenzung des Feldes 
        if (transform.position.x * 100 >= 10000 || transform.position.z * 100 >= 10000 || transform.position.x *100 <= -10000 || transform.position.z <= -10000 )
        {
            StopGame(); 
        }

        if (Text_Countdown.CountdownFinished)
        {


            move();  



    }


       
   
    }

    void move()
    {


        Vector3 Position_HandLeft = LeftHand.transform.position;
        Vector3 Position_HandRight = RightHand.transform.position;

        LeftHandY = Position_HandLeft.y * 100;
        RightHandY = Position_HandRight.y * 100;




        DiffLinksdrehung = RightHandY - LeftHandY;
        DiffRechtsdrehung = LeftHandY - RightHandY;

        /*
        aktuelleZeit += Time.deltaTime;
        if (aktuelleZeit >= ZeitZumAufrufen)
        {
            setHandParameters();
            aktuelleZeit = 0.0f;
        }*/



        //Linksdrehung
        if ((DiffLinksdrehung) >= Diff)
        {

            DiffLinksdrehung = Mathf.Clamp(DiffLinksdrehung, minDiff, maxDiff); //Begrenzt Die Differenz für die Linksdrehung

            RotationSpeed = DiffLinksdrehung * (speed * 0.1f); //Gibt die Geschwindigkeit für die Rotation an 
            RotationSpeed = Mathf.Clamp(RotationSpeed, 0.1f, 10f); //Begrenzt die Geschwindigkeit für die Rotation 

            moveDirection = new Vector3(-1f, 0f, 1f).normalized;
            transform.Rotate(0, (-1f * DiffLinksdrehung * (RotationSpeed)) * Time.deltaTime, 0, Space.World);

            //transform.Rotate(transform.position, 1); 

        }
        //Rechtsdrehung
        else if (DiffRechtsdrehung >= Diff)
        {
            DiffRechtsdrehung = Mathf.Clamp(DiffRechtsdrehung, minDiff, maxDiff); //Begrenzt die Differenz für die Rechtsdrehung

            RotationSpeed = DiffRechtsdrehung * (speed * 0.1f); //Gibt die Geschwindigkeit für die Rotation an
            RotationSpeed = Mathf.Clamp(RotationSpeed, 0.1f, 10f); //Begrenzt die Geschwindigkeit für die Rotation 

            moveDirection = new Vector3(1f, 0f, 1f).normalized;
            transform.Rotate(0, (1f * DiffRechtsdrehung * (RotationSpeed)) * Time.deltaTime, 0, Space.World);
        }
        else
        {
            moveDirection = new Vector3(0, 0f, 1).normalized;
        }
        Vector3 moveAmount = moveDirection * speed * Time.deltaTime;

        transform.Translate(moveAmount);
    }




    private float ZeitZumAufrufen = 1.0f;
    private float aktuelleZeit = 0.0f; 

    void move2()
    {
        /*
        Vector3 Position_HandLeft = LeftHand.transform.position;
        Vector3 Position_HandRight = RightHand.transform.position;

        LeftHandY = Position_HandLeft.y * 100;
        RightHandY = Position_HandRight.y * 100;

        DiffLinksdrehung = RightHandY - LeftHandY;
        DiffRechtsdrehung = LeftHandY - RightHandY; */

        aktuelleZeit += Time.deltaTime;
        if(aktuelleZeit >= ZeitZumAufrufen)
        {
            setHandParameters(); 
            aktuelleZeit = 0.0f; 
        }


        if (DiffLinksdrehung >= Diff && (Mathf.Round(transform.rotation.eulerAngles.y) > 90f || Mathf.Round(transform.rotation.eulerAngles.y) <90))
        {
            /*
            Vector3 targetPosition = new Vector3(transform.position.x - 1f , transform.position.y +  0, transform.position.z + 1) * speed * 0.1f; 
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);
            */
            transform.Rotate(0, -0.5f, 0, Space.World); 

        }else if(DiffRechtsdrehung >= Diff && (Mathf.Round(transform.rotation.eulerAngles.y) > 90f || Mathf.Round(transform.rotation.eulerAngles.y) < 90))
        {
            /*
            Vector3 targetPositon = new Vector3(transform.position.x +  1, transform.position.y +  0, transform.position.z +  1) * speed * 0.1f;
            transform.position = Vector3.Lerp(transform.position, targetPositon, Time.deltaTime * smoothness);
            */
            transform.Rotate(0, 0.5f, 0, Space.World); 
        }
        else
        {
            /*
            Vector3 targetPositon = new Vector3(transform.position.x +  0, transform.position.y +  0, transform.position.z +  1) * speed * 0.1f; 
            transform.position = Vector3.Lerp(transform.position, targetPositon, Time.deltaTime * smoothness);
            */
        }
    }

    // Die Methode setzt die Parameter für die Hände
    // Also die Y-Kord und die Differenz für die Lenkung
    void setHandParameters()
    {
        Vector3 Position_HandLeft = LeftHand.transform.position;
        Vector3 Position_HandRight = RightHand.transform.position;

        LeftHandY = Position_HandLeft.y * 100;
        RightHandY = Position_HandRight.y * 100;

        DiffLinksdrehung = RightHandY - LeftHandY;
        DiffRechtsdrehung = LeftHandY - RightHandY;
    }


    public Rigidbody rigidBody;
    public float force = 40; 
    void moveWithRigidBody()
    {

        setHandParameters(); 

        if (DiffLinksdrehung >= Diff)
        {
            Vector3 targetPosition = new Vector3(transform.position.x + 1, transform.position.y + 0, transform.position.z + 1);
            Vector3 f = targetPosition - transform.position;
            f = f.normalized;
            f = f * force;
            rigidBody.AddForce(f); 

        }
        else if (DiffRechtsdrehung >= Diff)
        {
            Vector3 targetPosition = new Vector3(transform.position.x + 1, transform.position.y + 0, transform.position.z + 1); 
            Vector3 f = targetPosition - transform.position;
            f = f.normalized;
            f = f * force;
            rigidBody.AddForce(f);
        }
        else
        {
            Vector3 targetPosition = new Vector3(transform.position.x + 0, transform.position.y + 0, transform.position.z + 1);
            Vector3 f = targetPosition - transform.position;
            f = f.normalized;
            f = f * force;
            rigidBody.AddForce(f);
        }
    }




    /// <summary>
    /// Die Methode stopt das Programm
    /// </summary>
    void StopGame()
    {
        Time.timeScale = 0f;
      //  Application.Quit(); 
    }



    
    /// <summary>
    /// Die Methode erhöht den den Wert speed um 1 solange bis er 15 ist 
    /// </summary>
    void increaseSpeed()
    {
        speed = speed  + 1.0f  ;
        Debug.Log("Speed = " + speed); 

        if(speed >= 15)
        {
            //Beendet die Wiederholung der Methode increaseSpeed
            CancelInvoke("increaseSpeed"); 
        }
    }
}
