using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLogic : MonoBehaviour
{
    private Transform _transformUFO;
    private Transform _transformPlayer;
    private float _angerDistance = 5f;
    private float _speed = 2f;
    private float _randomX;
    private float _randomY;
    private Vector2 _desiredPosition;
    private bool _isMoving = false;
    private Animator _anim;
    void Start()
    {
        _transformUFO = GetComponent<Transform>();
        _transformPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _anim = GameObject.Find("LosePanel").GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector2.Distance(_transformPlayer.position, _transformUFO.position) <= _angerDistance)
        {
            _isMoving = false;
            _transformUFO.position = Vector2.MoveTowards(_transformUFO.position, _transformPlayer.position, _speed*Time.deltaTime);
        }
        else
        {
            Patrol();
        }
    }
    private void Patrol()
    {
        if (Vector2.Distance(_transformUFO.position, _desiredPosition) <= 0.5f)
            _isMoving = !_isMoving;

        if (!_isMoving)
        {
            do {
                _randomX = Random.Range(-5f, 5f);
                _randomY = Random.Range(-5f, 5f);
                _desiredPosition = new Vector2(_transformUFO.position.x + _randomX, _transformUFO.position.y + _randomY);
            } while (Vector2.Distance(_desiredPosition, Vector2.zero) > 500f);

            _isMoving = !_isMoving;
        }

        _transformUFO.position = Vector2.MoveTowards(_transformUFO.position, _desiredPosition, _speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _anim.SetFloat("SpeedMult", 1f);
        }
    }
}
