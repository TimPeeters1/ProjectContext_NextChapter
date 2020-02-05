using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerController
{
    Player1,
    Player2
}

public class Player_Controls : MonoBehaviour
{
    public PlayerController thisPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(thisPlayer == PlayerController.Player1)
        {

        }
        if(thisPlayer == PlayerController.Player2)
        {

        }
    }
}
