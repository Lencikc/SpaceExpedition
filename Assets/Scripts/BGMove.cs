using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 0.005f;
    [SerializeField] private float _valueZ = 0;
    private Transform _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 desiredPosition = new Vector3(_player.position.x, _player.position.y, _valueZ);
        Vector3 smoothedPositin = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        transform.position = smoothedPositin;
    }
}
