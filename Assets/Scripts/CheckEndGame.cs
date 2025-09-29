using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEndGame : MonoBehaviour
{
    private Collider2D cl;
    private Text text;
    private void Start()
    {
        text = GameObject.Find("Message").GetComponent<Text>();
    }
    void Update()
    {
        cl = GetComponent<Collider2D>();
        //Debug.Log("work");
        OnTriggerStay2D(cl);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
     
        if (col.CompareTag("Player"))
        {
            text.text = "Winner";
            StartCoroutine(Cooldown(10));
            EndGame();
            Destroy(GameObject.Find("Player"));
            Destroy(gameObject);
        }
    }

    private void EndGame()
    {
        // Завершаем игру
        Debug.Log("endGameWinner");
//#if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//#else
//        Application.Quit();
//#endif
    }
    private IEnumerator Cooldown(float sec)
    {
        yield return new WaitForSeconds(sec);
    } 
}
