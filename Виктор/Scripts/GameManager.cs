using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject PlayerBlue;
    public GameObject PlayerRed;
    public Vector3[] Respawns;
    enum State { Player1, Player2 };
    private State _state;
 


    void Start()
    {

        Instantiate(PlayerBlue, Respawns[0], Quaternion.identity);
        Instantiate(PlayerRed, Respawns[1], Quaternion.identity);
        
        if (Random.Range(1, 2) == 1)
        {
            //turn = true;
            _state = State.Player1;
            Debug.Log("Player1");
        }
        else
        {
            _state = State.Player2;
            //turn = false;
            Debug.Log("Player2");
        }

        if (_state == State.Player1)
        {
            Player1();
        }
        else if (_state == State.Player2)
        {
            Player2();
        }
    }
    void Update()
    {

    }

    public void Player1()
    {
        PlayerBlue.gameObject.SetActive(true);
        PlayerRed.gameObject.SetActive(false);
    }
    public void Player2()
    {
        PlayerRed.gameObject.SetActive(true);
        PlayerBlue.gameObject.SetActive(false);
    }
}
/*bool turn;  */                        //[SerializeField] float _speed = 10f;

//public void MovePlayers()
//{
//    if (turn == true) //Игрок 1
//    {
//        Debug.Log("Player 1");
//        if (Input.GetKeyDown(KeyCode.Space))

//            _state = State.Player2;
//    }


//    if (turn == false) //Игрок 2
//    {
//        Debug.Log("Player 2");
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            _state = State.Player1;
//        }
//    }
//}


// void PlayerController(int a)
//{
//    if (turn == true) //Игрок 1
//    {
//        _state = State.Player2;
//    }
//    if (turn == false) //Игрок 2
//    {
//        _state = State.Player1;
//    }

//}


