using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 



[RequireComponent(typeof(WaterFloatScript))]
public class WaterBoatHorizontalScript : MonoBehaviour
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


    public Transform boat;
    public Transform LeftHandT;
    public Transform RightHandT; 



    private float Diff = 7; 

    public GameObject LeftHand;
    public GameObject RightHand;

    private float LeftHandZ_Alt;
    private float RightHandZ_Alt;

    private float LeftHandZ_Neu;
    private float RightHandZ_Neu; 

    private float DiffLinksdrehung;
    private float DiffRechtsdrehung;
    private float minDiff = 5f;
    private float maxDiff = 50f;

    public GameObject relativeObject;


    private GameObject internHandLeft;
    private GameObject internHandRight;

    protected Rigidbody rigidbodyLeftHand; 

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

    private void Start()
    {
        internHandLeft = new GameObject("internHandLeft");
        internHandRight = new GameObject("internHandRight");
        
    }

    public void Update()
    {
        if (Text_Countdown.CountdownFinished)
        {
            //Power = VerbindungScript.v;
            // Power = SpeedFunctionScript.functionV(VerbindungScript.v, 1.0f , 0.5f); 
            Power = 20;
        }


        Quaternion relativeRotationLeftHand = Quaternion.Inverse(LeftHand.transform.rotation) * relativeObject.transform.rotation;
        Quaternion relativeRotationRightHand = Quaternion.Inverse(RightHand.transform.rotation) * relativeObject.transform.rotation;





        /*
        LeftHand.transform.rotation = relativeRotationLeftHand;
        RightHand.transform.rotation = relativeRotationRightHand;
        */


       Vector3 relativePositionLeftHand = LeftHand.transform.position - relativeObject.transform.position;
        // Vector3 relativePositionLeftHand = transform.TransformPoint(LeftHand.transform.localPosition) - transform.TransformPoint(relativeObject.transform.localPosition);
        Vector3 relativePositionRightHand = RightHand.transform.position - relativeObject.transform.position;

       // Vector3 relativePositionLeftHand = LeftHand.transform.InverseTransformPoint(relativeObject.transform.position);
        // Vector3 relativePositionRightHand = RightHand.transform.InverseTransformPoint(relativeObject.transform.position); 

        internHandLeft.transform.rotation = relativeRotationLeftHand;
        internHandRight.transform.rotation = relativeRotationRightHand;


       
        internHandLeft.transform.position = relativePositionLeftHand;
        internHandRight.transform.position = relativePositionRightHand;
       

      //  internHandLeft.transform.position = transform.TransformPoint(LeftHand.transform.localPosition);
       

       
            Vector3 Position_HandLeft = internHandLeft.transform.position;
            Vector3 Position_HandRight = internHandRight.transform.position;


        /*
        Vector3 Position_HandLeft = relativePositionLeftHand;
        Vector3 Position_HandRight = relativePositionRightHand;
  */







        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /*
        LeftHandZ_Alt = Position_HandLeft.z * 100; 
        RightHandZ_Alt = Position_HandRight.z * 100;
        */

        LeftHandZ_Alt = LeftHand.transform.localPosition.z * 100;
        RightHandZ_Alt = RightHand.transform.localPosition.z * 100; 

        DiffLinksdrehung = RightHandZ_Alt - LeftHandZ_Alt;
        DiffRechtsdrehung = LeftHandZ_Alt - RightHandZ_Alt;


       
    }

    

    public void FixedUpdate()
    {
        if (Text_Countdown.CountdownFinished) { 
        //default direction
        var forceDirection = transform.forward;
        float steer  = 0;
            /*
            //steer direction [-1,0,1]
            if (Input.GetKey(KeyCode.A))
                steer = 1;
            if (Input.GetKey(KeyCode.D))
                steer = -1;*/


            txt.SetText("Links z : " + LeftHandZ_Alt.ToString() + "\t\t\t" + "Rechts z: " + RightHandZ_Alt.ToString() + "\n"
                        + "Links x: " + internHandLeft.transform.position.x.ToString() + "\n"
                        + "Rotation Left: " + internHandLeft.transform.rotation.z); 

        //Linksdrehung
        if (DiffLinksdrehung >= Diff)
        {
          DiffLinksdrehung = Mathf.Clamp(DiffLinksdrehung, minDiff, maxDiff);

           steer = 1;
        }
        //Rechtsdrehung
        else if (DiffRechtsdrehung >= Diff)
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