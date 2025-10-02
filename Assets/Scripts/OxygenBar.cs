using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    private OxygenSpawnLogic _oxygenScript;
    void Start()
    {
        _oxygenScript = GameObject.Find("OxygenSpawner").GetComponent<OxygenSpawnLogic>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _oxygenScript._oxygenCount = 12;
            _oxygenScript.DeleteOxygenCells();
            _oxygenScript.DrawOxygenCells();
            Destroy(gameObject);
        }
    }
}
