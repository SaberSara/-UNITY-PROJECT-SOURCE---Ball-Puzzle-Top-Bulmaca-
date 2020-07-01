using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Transform only position foool
/// </summary>
public class Follow : MonoBehaviour
{
    public GameObject gameMaanagerGO;

    public GameObject playerPrefabGO;
    private GameManager gameManagerInstance;
    public Material blueMat;
    // Start is called before the first frame update
    void Start()
    {
        playerPrefabGO = GameObject.FindGameObjectWithTag("Player");
        gameManagerInstance = GameObject.FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position= playerPrefabGO.transform.position;
        if(!playerPrefabGO.activeSelf)
        {
            gameObject.SetActive(false);
            

            //Lerp(gameManagerInstance.r)
        }
    }
}
