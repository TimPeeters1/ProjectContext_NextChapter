using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Action : MonoBehaviour
{
    [SerializeField] float FlyPower;
    [SerializeField] float From;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Debug.Log("Go to Fly");
            collision.rigidbody.AddForce(Vector3.up * Random.Range(FlyPower, From), ForceMode.Impulse);
        }
    }
}
