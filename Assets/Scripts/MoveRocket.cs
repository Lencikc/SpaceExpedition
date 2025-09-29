using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MoveRocket : MonoBehaviour
{
    private Transform rocketPos;
    private float _speed = 2f;
    [SerializeField] private Joystick joystick;
    private Rigidbody2D rb;
    private Text text;

    void Start()
    {
        rocketPos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        text = GameObject.Find("Message").GetComponent<Text>();
     
    }

    void Update()
    {
        float speedRock = Time.deltaTime * _speed;
        Vector3 movement = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        rb.velocity = movement * _speed;

        rocketPos.rotation = Quaternion.FromToRotation(rocketPos.position, movement);

        if (Vector2.Distance(rocketPos.position, Vector2.zero) >= 165)
        {
            rb.velocity = rocketPos.position * (-0.5f);
            text.text = "daleko";
            StartCoroutine(Cooldown(1));
        }
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        // Проверяем, что столкновение произошло с нужным объектом
        if (collision.gameObject.CompareTag("Satellite") || collision.gameObject.CompareTag("GarBage")) // Замените "Wall" на тег вашего статического объекта
        {
            Debug.Log("Столкновение с: " + collision.gameObject.name);
      
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            //// Применяем силу отталкивания
            Rigidbody2D rb1 = GetComponent<Rigidbody2D>();
            rb1.velocity = collision.transform.position * (-550);
            //rb1.AddForce(direction * 550, ForceMode2D.Impulse);
            text.text = "Collision";
            StartCoroutine(Cooldown(1));
        }
    }
    private IEnumerator Cooldown(float sec)
    {
        yield return new WaitForSeconds(sec);
        text.text = "";
    }
}
