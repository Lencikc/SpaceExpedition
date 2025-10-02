using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _text;
    private Transform _posPl;
    private GameObject[] _blackHolePositions;
    private Transform _posBL2;
    private MoveRocket _moveRocket;
    void Start()
    {
        _blackHolePositions = GameObject.FindGameObjectsWithTag("BlackHole");
        _text = GameObject.Find("Message").GetComponent<Text>();
        _moveRocket = GameObject.Find("Player").GetComponent<MoveRocket>();
        _posPl = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine("FindOtherBlackHole");
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        

        if (col.CompareTag("Player") 
            && !_moveRocket.isTeleported)
        {
            _posPl.position = new Vector3(_posBL2.position.x,_posBL2.position.y);
            StartCoroutine(Col(1));
        }
    }
    private IEnumerator Col(float sec)
    {
        _moveRocket.isTeleported = !_moveRocket.isTeleported;
        yield return new WaitForSeconds(sec);
        _moveRocket.isTeleported = !_moveRocket.isTeleported;
    }

    private IEnumerator FindOtherBlackHole()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < _blackHolePositions.Length; i++)
        {
            if (_blackHolePositions[i].GetComponent<Transform>() != GetComponent<Transform>())
            {
                _posBL2 = _blackHolePositions[i].GetComponent<Transform>();
                yield return null;
            }
        }
    }
}
