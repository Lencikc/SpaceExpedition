using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSatellite : MonoBehaviour
{
    private FuelSpawnLogic _fuelScript;

    void Start()
    {
        _fuelScript = GameObject.Find("FuelSpawner").GetComponent<FuelSpawnLogic>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _fuelScript._fuelCount = 12;
            _fuelScript.DeleteFuelCells();
            _fuelScript.DrawFuelCells();
            Destroy(gameObject);
           
        }
    }
}
