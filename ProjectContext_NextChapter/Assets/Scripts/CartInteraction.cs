using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

		try
		{
			collision.GetComponent<ShopElement>().BuyItem();
		}
		catch 
		{
		}
    }
}
