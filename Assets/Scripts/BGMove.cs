using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 0.005f;
    [SerializeField] private float valueZ = 0;
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, valueZ);
        Vector3 smoothedPositin = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPositin;
    }
}
