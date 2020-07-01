using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintsZone : MonoBehaviour
{
    //-----Attributs--------"PUT YOUR ATTRIBUTS HERE BELLOW THIS COMMMENTS"--
    //--Privates Attributs

    public GameObject gameMaanagerGO;
    
    public GameObject playerPrefabGO;
    private GameManager gameManagerInstance;

    //--Public Attributs


    //-----Methods----------"PUT YOUR METHODS HERE BELLOW THIS COMMENTSsS"------

    // Start is called before the first frame update

    void Start()
    {
        gameManagerInstance = gameMaanagerGO.GetComponent<GameManager>();
        playerPrefabGO = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Detects Triggers Coliision enter Functions
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.name.Equals("PF_ColorsZoneBlue") && !gameManagerInstance.isBallBlue)
            {
                gameManagerInstance.isBallBlue=true;
                Debug.Log("Ball COlor := Bleueuee");
                gameManagerInstance.changeColors();
            }
            if (gameObject.name.Equals("PF_ColorsZoneYl") && !gameManagerInstance.isBallYellow)
            {
                gameManagerInstance.isBallYellow = true;
                Debug.Log("Ball COlor := Yellow");
                gameManagerInstance.changeColors();
            }
            if (gameObject.name.Equals("PF_ActivationGreenArea") && !gameManagerInstance.isBallGreen)
            {
                gameManagerInstance.isBallGreen = true;
                Debug.Log("Ball COlor := Yellow");
                gameManagerInstance.changeColors();
            }
        }
    }
}
