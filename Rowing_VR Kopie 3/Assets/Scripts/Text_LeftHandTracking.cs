using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Oculus; 


public class Text_LeftHandTracking : MonoBehaviour
{

    public TextMeshPro txt;
    private static double LeftHandX;
    private static double LeftHandY;
    private static double LeftHandZ;

    public GameObject LeftHand;

    public GameObject sceneCamera;

    private Vector3 targetPositon; 
    private Quaternion targetRotation;
    private float step;
    private Vector3 newPositon;


    public OVRCameraRig OVRCameraRig;










    private static double LeftHandX_Alt;
    private static double LeftHandY_Alt;
    private static double LeftHandZ_Alt;

    public double LeftHandX_Neu; 

    // Start is called before the first frame update
    void Start()
    {
        LeftHandX_Alt = Math.Round(LeftHand.transform.position.x * 100);
        wirteText(LeftHandX_Alt); 
       
    }

    // Update is called once per frame
    void Update()
    {
        step = 10.0f * Time.deltaTime;

        //if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            centerText();

        LeftHandX_Neu = Math.Round(LeftHand.transform.position.x * 100);


        if(LeftHandX_Neu != LeftHandX_Alt)
        {
            wirteText(LeftHandX_Neu); 
        }


     //   LeftHandX = Math.Round(LeftHand.transform.position.x * 100);
        LeftHandY = Math.Round(LeftHand.transform.position.y * 100);
        LeftHandZ = Math.Round(LeftHand.transform.position.z * 100);



        /*
        txt.SetText("Linke Hand : \n" +
                   "X = " + LeftHandX_Alt.ToString() + "\n" +
                   "Y = " + LeftHandY.ToString() + "\n" +
                   "Z = " + LeftHandZ.ToString());*/


    }



    void wirteText(double x)
    {
        txt.SetText("Linke Hand : \n" +
                    "X = " + x.ToString()); 
    }



















    void centerText()
    {
       
        newPositon.x = sceneCamera.transform.position.x + -20f;
        newPositon.y = sceneCamera.transform.position.y + 10f;
        newPositon.z = sceneCamera.transform.position.z + 40f;
        

        //  Vector3 blickrichtung = OVRCameraRig.centerEyeAnchor.forward; 
       
        targetRotation = Quaternion.LookRotation( transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position , newPositon, step);
        //transform.position = OVRCameraRig.centerEyeAnchor.position + OVRCameraRig.centerEyeAnchor.forward * 40f; 
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);

       // transform.LookAt(sceneCamera.transform.position); 
       
        
    }

    void centerText2()
    {
        Vector3 cameraForward = OVRCameraRig.centerEyeAnchor.forward;
        Vector3 targetPositon = OVRCameraRig.centerEyeAnchor.position + cameraForward * 50f;
        targetPositon.y = 10f;
        
        transform.position = targetPositon;


        transform.LookAt(OVRCameraRig.centerEyeAnchor); 

    }

   
}
