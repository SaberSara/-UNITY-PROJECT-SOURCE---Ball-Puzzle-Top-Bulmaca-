using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndsPortal : MonoBehaviour

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
            //Animation later
            //mo tim   playerPrefabGO.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            gameManagerInstance.enteredPortalLvl1=true;
            gameManagerInstance.CheckGameOver();
            Debug.Log("FinishedLevel");
            

        }
    }

}
