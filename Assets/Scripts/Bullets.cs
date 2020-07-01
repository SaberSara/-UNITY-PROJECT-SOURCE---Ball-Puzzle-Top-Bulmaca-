using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    

    
    private GameManager gameManagerInstance;
    
    public float shootBulletSpeeds = 2;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-transform.forward) * shootBulletSpeeds * Time.deltaTime);
    }
    //Detects Triggers Coliision enter Functions
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Animation later
            //mo tim   playerPrefabGO.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            gameManagerInstance.lives--;
            Debug.Log("GaOvr");
            gameManagerInstance.CheckGameOver();
            Destroy(gameObject);

        }
        else if(!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


    //Collider Functions
    public void OnColliderEnter(Collider other)
    {
        
         if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
