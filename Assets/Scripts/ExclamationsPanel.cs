using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Exclamations Panel Script
/// </summary>
public class ExclamationsPanel : MonoBehaviour
{
    //-----Attributs--------"PUT YOUR ATTRIBUTS HERE BELLOW THIS COMMMENTS"--
    //--Privates Attributs
    public GameObject exclamationsPanelUIGO;
    public GameObject exclamationTextFieldZoneUIGO;
    public GameObject gameMaanagerGO;
    public string exclamationToSayTxt;
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
            gameManagerInstance.virtualJoysticksUIs.SetActive(false);
            exclamationTextFieldZoneUIGO.GetComponent<Text>().text = exclamationToSayTxt;
            //Put the given text in the inspectors unity engine tp the UI Canvas blanc optimised text
            FindObjectOfType<AcceleroPlayerControls>().decreassSpeed();
            //Lanch the animation and :Pop the UI exclamations for this object specific message
            exclamationsPanelUIGO.SetActive(true);

            //Play an animation after the move(TBD_)
            //tbd

            //Destroy gameObject 
            Destroy(gameObject);
            //Play some sounds? (tbd)

        }
    }
}
