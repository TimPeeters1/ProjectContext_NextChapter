using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerNumber
{
    Player1,
    Player2
}

public class PlayerMove_Controller : MonoBehaviour
{
    
    [SerializeField] PlayerNumber ThisPlayer;
    [SerializeField] float MovePower;//Value that how much fast
    [SerializeField] float JumpPower;
    [SerializeField] float RotationPower;

    private Rigidbody PlayerRigid;
    private TrailRenderer PlayerTrail;


    private bool isGrounded = false;
    private float PlayerVertical = 0;
    

    string HorizontalAxis;
    string VerticalAxis;

    string RotationVertical;
    string RotationHorizontal;

    string RunAxis;

    void Start()
    {
        //if(Camera.main.targetDisplay == 1)
        //else if(Camera.main.targetDisplay == 2)

        PlayerRigid = gameObject.GetComponent<Rigidbody>();
        PlayerTrail = gameObject.GetComponentInChildren<TrailRenderer>();

        if (ThisPlayer == PlayerNumber.Player1)
        {
            HorizontalAxis = "Horizontal1";
            VerticalAxis = "Vertical1";
            RotationVertical = "RotationVertical1";
            RotationHorizontal = "RotationHorizontal1";
            RunAxis = "Run1";
        }

        if (ThisPlayer == PlayerNumber.Player2)
        {
            HorizontalAxis = "Horizontal2";
            VerticalAxis = "Vertical2";
            RotationVertical = "RotationVertical2";
            RotationHorizontal = "RotationHorizontal2";
            RunAxis = "Run2";
        }

        
    }

    void Update()
    {
        if (!GameManager.isGameOver)
        {
            PlayerVertical = Input.GetAxis(VerticalAxis) * MovePower * -1;
            transform.Rotate(0, Input.GetAxis(RotationHorizontal) * RotationPower, 0);

            if (Input.GetAxis(RunAxis) > 0)
            {
                PlayerVertical *= 1.8f;
                //PlayerTrail.emitting = true;
            }
            else
            {
                PlayerVertical *= 1f;
                //PlayerTrail.emitting = false;
            }

            PlayerRigid.velocity = new Vector3(transform.forward.x * PlayerVertical, PlayerRigid.velocity.y, transform.forward.z * PlayerVertical);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                PlayerRigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.name == "Player1")
            isGrounded = true;

        if (gameObject.name == "Player2")
            isGrounded = true;
    }
}
