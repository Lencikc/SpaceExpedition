using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEndGame : MonoBehaviour
{
    private Animator _anim;
    private void Start()
    {
        _anim = GameObject.Find("WinnerPanel").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
     
        if (col.CompareTag("Player"))
        {
            _anim.SetFloat("MultSpeed",1f);
            Destroy(GameObject.Find("Player"));
            Destroy(gameObject);
        }
    }
}
