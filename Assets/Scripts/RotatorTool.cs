using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script used as a generics tools for rotatings a GOOOOOOsOSs
/// </summary>
public class RotatorTool : MonoBehaviour
{
    //-----Attributs--------"PUT YOUR ATTRIBUTS HERE BELLOW THIS COMMMENTS"--
    //--Privates Attributs
    

    //--Public Attributs
    

    //-----Methods----------"PUT YOUR METHODS HERE BELLOW THIS COMMENTSsS"------

    //Function called in the begining of the script
    private void Start()
    {
       
    }
    //Function called every frames after alllls s 
    private void Update()
    {
        //Rotate the obj
        transform.Rotate(new Vector3(15, 30, 45f) * Time.deltaTime);

    }
}
