using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour, ShopElement
{
    [Header("Shelf Info")]
    public ShopItem shelfItem;
    public int Cost;
    public bool isFairtrade;

    [Space]
    [Header("UI")]
    public UnityEngine.UI.Text itemText;
    public UnityEngine.UI.Image fairtradeIcon;


    private void Awake()
    {
        itemText.text = shelfItem.ToString() + " " + Cost + "$";
        if (isFairtrade)
        {
            fairtradeIcon.gameObject.SetActive(true);
        }
        else
        {
            fairtradeIcon.gameObject.SetActive(false);
        }
    }
    public void BuyItem()
    {
        GameManager.Instance.Player2Money -= Cost;
        GameManager.Instance.Player2List.MarkItem(shelfItem, FarmItem.None);
        GameManager.Instance.Player2Counter.StartCoroutine(GameManager.Instance.Player2Counter.ShowBuyCounter(Cost));

    }
}
