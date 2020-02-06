using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Interaction : MonoBehaviour
{
    [SerializeField] int GetFood;
    [SerializeField] int GetWater;

    [SerializeField] Sprite FoodImage;
    [SerializeField] Sprite WaterImage;

    Image Player1UI;

    private void Start()
    {
        Player1UI = transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Food")
        {
            Player1UI.sprite = FoodImage;

            if (Input.GetKeyDown(KeyCode.E))//and XBOX Controller ( A )
            {
                if (Player1Status.BeforeFoodState + 20 > 100)
                    Player1Status.BeforeFoodState = 100;
                else
                    Player1Status.BeforeFoodState += GetFood;
            }
        }

            if (other.tag == "Water")
            {

                Player1UI.sprite = WaterImage;


                if (Input.GetKeyDown(KeyCode.E))//and XBOX Controller ( A )
                {
                    if (Player1Status.BeforeWaterState + 20 > 100)
                        Player1Status.BeforeWaterState = 100;
                    else
                        Player1Status.BeforeWaterState += GetWater;
                }

            }
    }

    private void OnTriggerExit(Collider other)
    {
        Player1UI.sprite = null;
    }
}
