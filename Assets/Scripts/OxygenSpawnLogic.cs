using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OxygenSpawnLogic : MonoBehaviour
{
    private Transform _spawnOxygenPosition;
    public int _oxygenCount = 13;
    [SerializeField] private GameObject _oxygenPrefab;
    private List<GameObject> _oxygenCells = new List<GameObject>();
    private GameObject _oxygenIcon;
    private bool isLosingOxygen = false;
    private GameObject _oxygenParent;
    private Animator _anim;

    void Start()
    {
        _spawnOxygenPosition = GetComponent<Transform>();
        _oxygenParent = GameObject.Find("OxygenSpawner");
        DrawOxygenCells();
        _anim = GameObject.Find("LosePanel").GetComponent<Animator>();
    }

    public void LoseOxygen()
    {
        if (_oxygenCount <= 0)
        {
            _anim.SetFloat("SpeedMult", 1f);
        }
        else
        {
            if (!isLosingOxygen)
            {

                _oxygenCount--;
                DeleteOxygenCells();
                DrawOxygenCells();
                StartCoroutine("OxygenCooldown");
            }
        }
    }

    public void DrawOxygenCells()
    {
        for (int i = 0; i < _oxygenCount; i++)
        {
            _oxygenIcon = Instantiate(_oxygenPrefab, new Vector2(_spawnOxygenPosition.position.x + 0.45f * i, _spawnOxygenPosition.position.y), Quaternion.identity);
            _oxygenIcon.transform.SetParent(_oxygenParent.transform);
            _oxygenCells.Add(_oxygenIcon);
        }
    }

    public void DeleteOxygenCells()
    {
        foreach (GameObject cell in _oxygenCells)
        {
            Destroy(cell);
        }
    }

    private IEnumerator OxygenCooldown()
    {
        isLosingOxygen = !isLosingOxygen;
        yield return new WaitForSeconds(10f);
        isLosingOxygen = !isLosingOxygen;
    }
}
