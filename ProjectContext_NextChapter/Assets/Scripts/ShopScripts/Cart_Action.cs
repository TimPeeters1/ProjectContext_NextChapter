using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Action : MonoBehaviour
{
    [SerializeField] float FlyPower;
    [SerializeField] float From;
    private string[] ShelfName;
    private char UnderBar = '_';

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            collision.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(FlyPower, From), ForceMode.Impulse);
        }

        if (collision.gameObject.tag == "Shelf")
        {
            ShelfName = collision.gameObject.name.Split(UnderBar);
            switch (ShelfName[1])
            {
                case "Meat":
                    GameManager.Instance.Player1Money -= 10;
                    break;
                case "Soda":
                    GameManager.Instance.Player1Money -= 20;
                    break;
                case "Cereal":
                    GameManager.Instance.Player1Money -= 30;
                    break;
                default:
                    Debug.Log(ShelfName[1]);
                    break;
            }
            Debug.Log(GameManager.Instance.Player1Money);
            //GameManager.Player1Money -= 10;//Player2 Money in GameObject
        }
    }

}
