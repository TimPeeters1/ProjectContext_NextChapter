using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartAction : MonoBehaviour
{
    [SerializeField] float HowMuchWantMakeFlyTo;
    [SerializeField] float From;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
        Debug.Log("Go to Fly");
            collision.rigidbody.AddForce(Vector3.up * Random.Range(HowMuchWantMakeFlyTo, From), ForceMode.Impulse);
        }
    }
}
