using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Status : MonoBehaviour
{

    public static float FoodState = 100;
    public static float WaterState = 100;
    public static int BeforeFoodState = 100;
    public static int BeforeWaterState = 100;

    [SerializeField]float HungerDelay;
    [SerializeField]float ThirstDelay;
    [SerializeField] int HungerAmount;
    [SerializeField] int ThirstAmount;

    Slider FoodSlider;
    Slider WaterSlider;

    // Start is called before the first frame update
    void Start()
    {
        FoodSlider = GameObject.Find("Player1Gauge").transform.GetChild(0).GetComponent<Slider>();
        WaterSlider = GameObject.Find("Player1Gauge").transform.GetChild(1).GetComponent<Slider>();
        StartCoroutine("Hungry");
        StartCoroutine("Thirsty");
    }

    void Update()
    {
        FoodState = Mathf.Lerp(FoodState,BeforeFoodState, 0.5f);
        WaterState = Mathf.Lerp(WaterState,BeforeWaterState, 0.5f);
        FoodSlider.value = FoodState;
        WaterSlider.value = WaterState;
        Debug.Log(WaterState);
    }

    IEnumerator Hungry()
    {
        yield return new WaitForSeconds(HungerDelay);
        if (BeforeFoodState > 0)
        BeforeFoodState -= HungerAmount;
        else
            GameManager.isGameOver = true;

        StartCoroutine("Hungry");
    }

    IEnumerator Thirsty()
    {
        yield return new WaitForSeconds(ThirstDelay);
        if (BeforeWaterState > 0)
            BeforeWaterState -= ThirstAmount;
        else
            GameManager.isGameOver = true;

            StartCoroutine("Thirsty");
    }
}
