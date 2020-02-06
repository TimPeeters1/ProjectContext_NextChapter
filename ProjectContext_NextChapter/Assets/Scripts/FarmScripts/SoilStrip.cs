using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilStrip : MonoBehaviour
{
    [Header("Farm Product Info")]
    public FarmItem farmItem;
    public int CostToPlant;
    public bool isFairtrade;

    [Space]
    [Header("UI")]
    public UnityEngine.UI.Text itemText;
    public void PlantItem()
    {
        GameManager.Instance.Player1Money -= CostToPlant;
        GameManager.Instance.Player1List.MarkItem(ShopItem.None, farmItem);
        GameManager.Instance.Player2Counter.StartCoroutine(GameManager.Instance.Player2Counter.ShowBuyCounter(CostToPlant));

    }
}
