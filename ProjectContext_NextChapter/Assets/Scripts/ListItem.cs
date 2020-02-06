using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TaskList Item", menuName = "Task Items/Item", order = 0)]
public class ListItem : ScriptableObject
{
    public string taskDescription;
    public ShopItem shopItem;
    public FarmItem farmItem;
}
