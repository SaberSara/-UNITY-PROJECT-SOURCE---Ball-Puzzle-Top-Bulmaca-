using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : MonoBehaviour
{//-----Attributs--------"PUT YOUR ATTRIBUTS HERE BELLOW THIS COMMMENTS"--
 //--Privates Attributs
    public GameObject gameMaanagerGO;

    public GameObject playerPrefabGO;
    private GameManager gameManagerInstance;


    //--Public Attributs


    //-----Methods----------"PUT YOUR METHODS HERE BELLOW THIS COMMENTSsS"------

    // Start is called before the first frame update
    void Start()
    {
        playerPrefabGO = GameObject.FindGameObjectWithTag("Player");
        gameManagerInstance = gameMaanagerGO.GetComponent<GameManager>();
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
            if (gameObject.transform.parent.parent.name.Equals("PF_ColorsKeyBlue") && gameManagerInstance.isBallBlue)
            {
                gameManagerInstance.isKeyBlueFound = true;
                Debug.Log("Ball COlor := isKeyBlueFound");
                gameManagerInstance.openFences();
                //Play aanimations
                //Play SOunds? no times XD
                gameObject.transform.parent.gameObject.SetActive(false); //Deactivat parents of the objects and all the floating holoo
            }
            if (gameObject.transform.parent.parent.name.Equals("PF_ColorsKeyYellow") && gameManagerInstance.isBallYellow)
            {
                gameManagerInstance.isKeyYellowFound = true;
                Debug.Log("Ball COlor := isKeyYellowFound");
                gameManagerInstance.openFences();
                gameObject.transform.parent.gameObject.SetActive(false); //Deactivat parents of the objects and all the floating holoo
            }
            if (gameObject.transform.parent.parent.name.Equals("PF_ColorsKeyGreen") && gameManagerInstance.isBallGreen)
            {
                gameManagerInstance.isKeyGreenFound = true;
                Debug.Log("Ball COlor := isKeyGreenFound");
                gameManagerInstance.openFences();
                gameObject.transform.parent.gameObject.SetActive(false); //Deactivat parents of the objects and all the floating holoo
            }
        }
    }
}
