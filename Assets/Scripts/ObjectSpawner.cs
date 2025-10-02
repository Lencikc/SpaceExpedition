using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawner : MonoBehaviour
{
    //������� ��������(�������, 3)[1], ����������� �����(����������, 5)[2], ��������(������������, 3)[3], ���(����, 4)[4], ������ ����(��, 2)[5], ������(������ ���������, 3)[6].
    [SerializeField] private GameObject[] _objects;
    private Transform _playerPos;
    private Transform _stationPos;
    private int _randomX;
    private int _randomY;

    void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _stationPos = new GameObject("StationPosition").transform; 

        SpawnBlackHole(2); //ID - 4
        SpawnBrokenSatellite(3); //ID - 0
        SpawnMeteor(50); //ID - 2
        SpawnOxygenBar(3); //ID - 5
        SpawnSpaceTrash(25); //ID - 1
        SpawnUFO(4); //ID - 3
        SpawnEndPosition(1); //ID - 6
    }

    private void SpawnUFO(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[3]);
        }
    }
    private void SpawnBlackHole(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[4]);
        }
    }
    private void SpawnOxygenBar(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[5]);
        }
    }

    private void SpawnSpaceTrash(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[1]);
        }
    }
    private void SpawnMeteor(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[2]);
        }
    }
    private void SpawnBrokenSatellite(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetRandomPosition(_objects[0]);
        }
    }
    private void SpawnEndPosition(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetOppositePosition(_objects[6]);
        }
    }
    private void GetOppositePosition(GameObject obj)
    {
        _stationPos.position = _playerPos.position * -1;
        Instantiate(obj, _stationPos.position, Quaternion.identity);
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
        _randomX = Random.Range(-500, 500);
        _randomY = Random.Range(-500, 500);
    }
}