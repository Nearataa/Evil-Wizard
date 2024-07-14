using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject WINSCREEN;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            gameOver();
            Time.timeScale = 0f;
        }
    }
 

    public void gameOver()
    {
        WINSCREEN.SetActive(true);

    }


}
