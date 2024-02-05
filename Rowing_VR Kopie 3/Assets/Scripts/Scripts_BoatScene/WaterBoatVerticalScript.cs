
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

[RequireComponent(typeof(WaterFloatScript))]
public class WaterBoatScript : MonoBehaviour
{
    //visible Properties
    public Transform Motor;
    public float SteerPower = 200f;
    private float Power; 
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;



    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    


    //internal Properties
    protected Vector3 CamVel;





    private float Diff = 15; 

    public GameObject LeftHand;
    public GameObject RightHand;

    private float LeftHandY_Alt;
    private float RightHandY_Alt;

    private float LeftHandY_Neu;
    private float RightHandY_Neu; 

    private float DiffLinksdrehung;
    private float DiffRechtsdrehung;
    private float minDiff = 5f;
    private float maxDiff = 50f;



    public TextMeshPro txt; 

    public void Awake()
    {
        
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;

        /*
        LeftHandY_Alt = LeftHand.transform.position.y * 100;
        RightHandY_Alt = RightHand.transform.position.y * 100; 
        txt.SetText("y : " +  LeftHandY_Alt.ToString());

        */
    }


    private float letzteGeschwindigkeit = 0f;

    public float berechnePower(float geschwindigkeit)
    {
        float power;
        if(geschwindigkeit != letzteGeschwindigkeit)
        {
            //power = geschwindigkeit;
            power = SpeedFunctionScript.functionV(geschwindigkeit, 1.0f, 0.5f); 
        }
        else
        {
            power = geschwindigkeit * 0.9f; 
        }
        letzteGeschwindigkeit = geschwindigkeit;
        return power; 
    }

    public void Update()
    {
        if (Text_Countdown.CountdownFinished)
        {
            //  Power = VerbindungScript.v;
            // Power = SpeedFunctionScript.functionV(VerbindungScript.v, 1.0f , 0.5f);

            // Power = 20;

         Power = berechnePower(VerbindungScript.v); 


        }

        Vector3 Positon_HandLeft = LeftHand.transform.position;
        Vector3 Position_HandRight = RightHand.transform.position;

        LeftHandY_Alt = Positon_HandLeft.y * 100;
        RightHandY_Alt = Position_HandRight.y * 100;

        DiffLinksdrehung = RightHandY_Alt - LeftHandY_Alt;
        DiffRechtsdrehung = LeftHandY_Alt - RightHandY_Alt;


        /*
        LeftHandY_Neu = LeftHand.transform.position.y * 100;
        RightHandY_Neu = RightHand.transform.position.y * 100;

        if(LeftHandY_Neu != LeftHandY_Alt)
        {
            updateHandLeft(LeftHandY_Neu); 
        }
        if(RightHandY_Alt != LeftHandY_Alt)
        {
            updateHandRight(RightHandY_Neu); 
        }

        DiffLinksdrehung = RightHandY_Alt - LeftHandY_Alt;
        DiffRechtsdrehung = LeftHandY_Alt - RightHandY_Alt; */

    }

    void updateHandLeft(float y)
    {
        LeftHandY_Alt = y;
        txt.SetText("y : " +  y.ToString());
        
    }
    void updateHandRight(float y)
    {
        LeftHandY_Alt = y;  
    }


    public void FixedUpdate()
    {
        if (Text_Countdown.CountdownFinished) { 
        //default direction
        var forceDirection = transform.forward;
        float steer = 0;
        /*
        //steer direction [-1,0,1]
        if (Input.GetKey(KeyCode.A))
            steer = 1;
        if (Input.GetKey(KeyCode.D))
            steer = -1;*/

        //Linksdrehung
        if (DiffLinksdrehung >= Diff)
        {
            DiffLinksdrehung = Mathf.Clamp(DiffLinksdrehung, minDiff, maxDiff);

            steer = 1;
        }
        //Rechtsdrehung
        if (DiffRechtsdrehung >= Diff)
        {
            DiffRechtsdrehung = Mathf.Clamp(DiffRechtsdrehung, minDiff, maxDiff);

            steer = -1;
        }



        //Rotational Force
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);

        //compute vectors
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        var targetVel = Vector3.zero;




        //forward/backward poewr
        //if (Input.GetKey(KeyCode.W))  //Vorwärts
        PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        /* 
        if (Input.GetKey(KeyCode.S))    //Rückwärts 
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * -MaxSpeed, Power);

        */

        //moving forward
        var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

        //move in direction
        Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;


        }
    }

}