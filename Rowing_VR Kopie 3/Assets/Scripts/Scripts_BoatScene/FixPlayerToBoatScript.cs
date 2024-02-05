using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; 

public class FixPlayerToBoatScript : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;

    private Vector3 positonBoat;

    public OVRCameraRig oVRCameraRig; 

    // Start is called before the first frame update
    void Start()
    {
      //  positonBoat = boat.transform.position;

       
    }

    Vector3 point = new Vector3(0, 0, 0); 
    // Update is called once per frame
    void Update()
    {

        transform.position = point; 
        /*
        positonBoat = boat.transform.position;

        player.transform.position = positonBoat;
        */
      
    }
}
