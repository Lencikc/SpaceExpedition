using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MoveRocket : MonoBehaviour
{
    private Transform _rocketPos;
    private float _speed = 2f;
    [HideInInspector] public float boost = 1f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _rotatejoy;
    private Rigidbody2D _rb;
    private Text _text;
    [HideInInspector] public bool isTeleported = false;
    private OxygenSpawnLogic _oxygenScript;
    private FuelSpawnLogic _fuelScript;
    private bool _playSound = false;
    void Start()
    {
        _rocketPos = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _text = GameObject.Find("Message").GetComponent<Text>();
        _oxygenScript = GameObject.Find("OxygenSpawner").GetComponent<OxygenSpawnLogic>();
        _fuelScript = GameObject.Find("FuelSpawner").GetComponent <FuelSpawnLogic>();

        AudioController.Instance.PlayMusic();
    }

    void Update()
    {
        _oxygenScript.LoseOxygen();

        float speedRock = Time.deltaTime * _speed;
        Vector3 movement = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0);
        _rb.velocity = movement * _speed * boost;

        if(movement != Vector3.zero)
        {
            _fuelScript.LoseFuel();
            if(!_playSound) {
                AudioController.Instance.PlaySound(1);
                StartCoroutine("SoundCD");
            }
        }

        _rocketPos.rotation = Quaternion.FromToRotation(_rocketPos.position, _rotatejoy.GetComponent<Joystick>().Direction);

        if (Vector2.Distance(_rocketPos.position, Vector2.zero) >= 495)
        {
            _rb.velocity = _rocketPos.position * (-0.5f);
            _text.text = "daleko";
            StartCoroutine(Cooldown(1));
        }
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        // Проверяем, что столкновение произошло с нужным объектом
        if (collision.gameObject.CompareTag("Satellite") || collision.gameObject.CompareTag("GarBage")) 
        {
            Debug.Log("Столкновение с: " + collision.gameObject.name);
      
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            //// Применяем силу отталкивания
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = collision.transform.position * (-550);
            //rb1.AddForce(direction * 550, ForceMode2D.Impulse);
            _text.text = "Collision";
            StartCoroutine(Cooldown(1));
        }
    }
    private IEnumerator Cooldown(float sec)
    {
        yield return new WaitForSeconds(sec);
        _text.text = "";
    }
    private IEnumerator SoundCD()
    {
        _playSound = !_playSound;
        yield return new WaitForSeconds(3);
        _playSound = !_playSound;
    }
}
