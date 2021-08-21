using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRed : MonoBehaviour
{ 
    GameManager gameManager;
    //[SerializeField] float _speed = 10f;
    //float targetPostition;
    public int Player2Walks = 10;
    //bool _myTurn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();

    }
    void PlayerController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player2Walks -= 1;
            if(Player2Walks == 0)
            {
                gameManager.Player1();
            }
        }
        //float h = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        //float v = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        //transform.Translate(h, 0f, v);
    }

}