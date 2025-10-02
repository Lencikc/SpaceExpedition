using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FuelSpawnLogic : MonoBehaviour
{
    private Transform _spawnFuelPosition;
    [HideInInspector] public float _fuelCount = 12;
    [SerializeField] private GameObject _fuelPrefab;
    private List<GameObject> _fuelCells = new List<GameObject>();
    private GameObject _fuelIcon;
    private GameObject _fuelParent;
    [HideInInspector] public float boost = 1;
    private Animator _anim;
    void Start()
    {
        _fuelParent = GameObject.Find("FuelSpawner");
        _spawnFuelPosition = GetComponent<Transform>();
        DrawFuelCells();
        _anim = GameObject.Find("LosePanel").GetComponent<Animator>();
    }

    public void LoseFuel()
    {
        if (_fuelCount <= 0)
        {
            _anim.SetFloat("SpeedMult", 1f);
        }
        else
        {
            _fuelCount -= 0.005f * boost;
            DeleteFuelCells();
            DrawFuelCells();
        }
    }

    public void DrawFuelCells()
    {
        for (int i = 0; i < _fuelCount; i++)
        {
            _fuelIcon = Instantiate(_fuelPrefab, new Vector2(_spawnFuelPosition.position.x + 0.45f * i, _spawnFuelPosition.position.y), Quaternion.identity);
            _fuelIcon.transform.SetParent(_fuelParent.transform);
            _fuelCells.Add(_fuelIcon);
        }
    }

    public void DeleteFuelCells()
    {
        foreach (GameObject cell in _fuelCells)
        {
            Destroy(cell);
        }
    }
}
