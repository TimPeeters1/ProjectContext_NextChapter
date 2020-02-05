using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    enum PlayerNumber
    {
        Player1,
        Player2
    }
    [SerializeField] PlayerNumber ThisPlayer;
    [SerializeField] float MovePower;//Value that how much fast
    [SerializeField] float JumpPower;

    private Rigidbody Player1Rigid;
    private Rigidbody Player2Rigid;
    private TrailRenderer Player1Trail;
    private TrailRenderer Player2Trail;

    private bool Player1isGround = false;
    private bool Player2isGround = false;
    private float Player1Vertical = 0;
    private float Player2Vertical = 0;

    void Start()
    {
        //if(Camera.main.targetDisplay == 1)
        //else if(Camera.main.targetDisplay == 2)
        if(ThisPlayer == PlayerNumber.Player1)
            Player1Rigid = gameObject.GetComponent<Rigidbody>();
            Player1Trail = gameObject.GetComponentInChildren<TrailRenderer>();
        if (ThisPlayer == PlayerNumber.Player2)
        {
            Player2Rigid = gameObject.GetComponent<Rigidbody>();
            Player2Trail = gameObject.GetComponentInChildren<TrailRenderer>();
        }
            //I will fix this code to both controller :)
    }

    void Update()
    {
        if (ThisPlayer == PlayerNumber.Player1)//Player1 is Move to WASD
        {
            if (Input.GetKey(KeyCode.W))
                Player1Vertical = 1 * MovePower;
            else if (Input.GetKey(KeyCode.S))
                Player1Vertical = -1 * MovePower;
            else
                Player1Vertical = 0;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Player1Vertical *= 1.8f;
                Player1Trail.emitting = true;
            }

            if (Input.GetKeyUp(KeyCode.Slash))
                Player1Trail.emitting = false;

            if (Input.GetKey(KeyCode.A))
                gameObject.transform.Rotate(0,-2,0);
            else if (Input.GetKey(KeyCode.D))
                gameObject.transform.Rotate(0, 2, 0);

            Player1Rigid.velocity = new Vector3(transform.forward.x * Player1Vertical, Player1Rigid.velocity.y, transform.forward.z * Player1Vertical);

            if (Input.GetKeyDown(KeyCode.Space) && Player1isGround)
            {
                Player1isGround = false;
                Player1Rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
        }

        else if (ThisPlayer == PlayerNumber.Player2)//Player2 is Move to Arrow
        {

            if (Input.GetKey(KeyCode.UpArrow))
                Player2Vertical = 1 * MovePower;
            else if (Input.GetKey(KeyCode.DownArrow))
                Player2Vertical = -1 * MovePower;
            else
                Player2Vertical = 0;

            if (Input.GetKey(KeyCode.Slash))
            {
                Player2Vertical *= 1.8f;
                Player2Trail.emitting = true;
            }

            if (Input.GetKeyUp(KeyCode.Slash))
                Player2Trail.emitting = false;

            if (Input.GetKey(KeyCode.LeftArrow))
                gameObject.transform.Rotate(0, -2, 0);
            else if (Input.GetKey(KeyCode.RightArrow))
                gameObject.transform.Rotate(0, 2, 0);

            Player2Rigid.velocity = new Vector3(transform.forward.x * Player2Vertical, Player2Rigid.velocity.y, transform.forward.z * Player2Vertical);

            if (Input.GetKeyDown(KeyCode.RightShift) && Player2isGround)
            {
                Player2isGround = false;
                Player2Rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (gameObject.name == "Player1")
    //        Player1isGround = true;
    //    else if (gameObject.name == "Player2")
    //        Player2isGround = true;
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.name == "Player1")
            Player1isGround = true;

        if (gameObject.name == "Player2")
            Player2isGround = true;
    }
}
