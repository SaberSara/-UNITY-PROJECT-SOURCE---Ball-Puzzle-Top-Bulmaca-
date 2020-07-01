using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The script controller for main cameras attached to thec
/// </summary>
public class CameraController : MonoBehaviour
{
    //-----Attributs--------"PUT YOUR ATTRIBUTS HERE BELLOW THIS COMMMENTS"--
    //--Privates Attributs
    private Vector3 mainCameraOffsets;

    //--Public Attributs
    public GameObject playerBall;

    //-----Methods----------"PUT YOUR METHODS HERE BELLOW THIS COMMENTSsS"------

    //Function called in the begining of the script
    private void Start()
    {
        //Get offsets
        mainCameraOffsets = transform.position - playerBall.transform.position;
    }
    //Function called every frames after alllls s   updat
    private void LateUpdate()
    {
        
        transform.position = playerBall.transform.position + mainCameraOffsets;
        


    }
}
