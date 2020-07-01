using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsSpawners : MonoBehaviour
{

    public float intervalOfshoot;
    private float counterStarts;
    private float counterMax;
    private float counter;
    public GameObject bulletPrefabsGO;
    public GameObject bulletsContainerGO;
    // Start is called before the first frame update
    void Start()
    {
        counterStarts = 0;
        counter = 0;
        counterMax = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        float nextCounterVel = Random.Range(1, intervalOfshoot);
        if (counter >= counterMax)
        {
            counter = 0;

            Transform bullet = Instantiate(bulletPrefabsGO, transform.position, Quaternion.identity).transform;
            
            counterMax = nextCounterVel;
            counter = 0;
        }
        else if (counter < counterMax)
        {
            counter += Time.deltaTime;

        }
    }
}
