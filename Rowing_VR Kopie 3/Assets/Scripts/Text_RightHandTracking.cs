using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro; 

public class Text_RightHandTracking : MonoBehaviour
{

    public TextMeshPro txt;
    public static double RightHandX;
    public static double RightHandY;
    public static double RightHandZ;

    public GameObject RightHand;

    public GameObject sceneCamera;

    private Quaternion targetRotation;
    private float step;
    private Vector3 newPosition; 

    // Start is called before the first frame update
    void Start()
    {
        /*
        sceneCamera = GameObject.Find("OVRCameraRig"); 
        txt = GetComponent<TextMeshPro>();
        RightHand = GameObject.Find("RightHandAnchor");
        */
    }

    // Update is called once per frame
    void Update()
    {
        step = 10.0f * Time.deltaTime;

        centerText(); 

        RightHandX = Math.Round(RightHand.transform.position.x * 100);
        RightHandY = Math.Round(RightHand.transform.position.y * 100);
        RightHandZ = Math.Round(RightHand.transform.position.z * 100);

        txt.SetText("Rechte Hand: \n" +
                    "X = " + RightHandX.ToString() + "\n" + 
                    "Y = " + RightHandY.ToString() + "\n" + 
                    "Z = " + RightHandZ.ToString()); 
    }

    void centerText()
    {
        newPosition.x = sceneCamera.transform.position.x + 20f;
        newPosition.y = sceneCamera.transform.position.y + 10f;
        newPosition.z = sceneCamera.transform.position.z + 40f;

        targetRotation = Quaternion.LookRotation(transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position, newPosition, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step); 
    }
}
