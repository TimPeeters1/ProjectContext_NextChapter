using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TaskList : MonoBehaviour
{
    [SerializeField] PlayerNumber ThisPlayer;

    public UnityEngine.UI.Text ListText;

    [Space]
    [Header("Task List")]
    public List<ListItem> Items = new List<ListItem>();


    private void Start()
    {
        if (ThisPlayer == PlayerNumber.Player1)
        {
            GameManager.Instance.Player1List = this;
        }

        if (ThisPlayer == PlayerNumber.Player2)
        {
            GameManager.Instance.Player2List = this;
        }

        for (int i = 0; i < Items.Count; i++)
        {
            ListText.text += Items[i].taskDescription + "\n";
        }
    }

    public void MarkItem(ShopItem shopItem, FarmItem farmItem)
    {
        List<ListItem> results = new List<ListItem>();

        if (ThisPlayer == PlayerNumber.Player1)
        {
            results = Items.FindAll(x => x.farmItem == farmItem);
        }

        if (ThisPlayer == PlayerNumber.Player2)
        {
            results = Items.FindAll(x => x.shopItem == shopItem);
        }


        if (results.Count > 0)
        {
            string oldString = results[0].taskDescription;
            string newString = StrikeThrough(results[0].taskDescription);
            ListText.text = ListText.text.Replace(results[0].taskDescription, newString);
        }


    }

    string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }
}
