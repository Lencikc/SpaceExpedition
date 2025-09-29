using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMKS : MonoBehaviour
{
    // Start is called before the first frame update
     private Transform MksPos;
    
    void Start()
    {
        int randomX = Random.Range(-150, -146);
        int randomY = Random.Range(-70, 74);
        MksPos = GetComponent<Transform>();
        MksPos.position = new Vector3(randomX, randomY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
