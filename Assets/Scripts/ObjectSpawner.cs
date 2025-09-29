using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawner : MonoBehaviour
{
    //Обломок спутника(топливо, 3)[1], космический мусор(замедление, 5)[2], метиорит(отталкивание, 3)[3], НЛО(враг, 4)[4], Черная дыра(тп, 2)[5], балоны(рефилл кислорода, 3)[6].
    [SerializeField] private GameObject[] objects;
    private Transform playerPos;
    private Transform stationPos;
    private int _randomX;
    private int _randomY;
    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();

        SpawnBlackHole(2); //ID - 4
        SpawnBrokenSatellite(3); //ID - 0
        SpawnMeteor(3); //ID - 2
        SpawnOxygenBar(3); //ID - 5
        SpawnSpaceTrash(5); //ID - 1
        SpawnUFO(4); //ID - 3
        SpawnEndPosition(6); //ID - 6
    }

    private void SpawnUFO(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[3]);
        }
    }
    private void SpawnBlackHole(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[4]);
        }
    }
    private void SpawnOxygenBar(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[5]);
        }
    }

    private void SpawnSpaceTrash(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[1]);
        }
    }
    private void SpawnMeteor(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[2]);
        }
    }
    private void SpawnBrokenSatellite(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(objects[0]);
        }
    }
    private void SpawnEndPosition(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetOppositePosition(objects[6]);
        }
    }
    private void GetOppositePosition(GameObject obj)
    {
        stationPos.position = playerPos.position * -1;
        Instantiate(obj, stationPos.position, Quaternion.identity);
    }
    private void GetRandomPosition(GameObject obj)
    {
        do
        {
            GenerateRandomXY();
        } while (Vector2.Distance(new Vector2(_randomX, _randomY), Vector2.zero) > 50f);

        Instantiate(obj, new Vector2(_randomX, _randomY), Quaternion.identity);

    }
    private void GenerateRandomXY()
    {
        _randomX = Random.Range(-50, 50);
        _randomY = Random.Range(-50, 50);
    }
}
