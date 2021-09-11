using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlue : MonoBehaviour
{
    GameManager gameManager;
    //private float _speed = 10f;
    public int Player1Walks = 10;
    //bool MyTurn = true;
    void Start()
    {

    }

    void Update()
    {
        PlayerController();
    }

    void PlayerController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player1Walks -= 1;
            if(Player1Walks == 0)
            {
                gameManager.Player2();
            }
        }
        //float h = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        //transform.Translate(h , 0f, v);
    }
}
