using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskList : MonoBehaviour
{
    public UnityEngine.UI.Text ListText;
    string listText;

    [Space]
    [Header("Task List")]
    public List<ListItem> Items = new List<ListItem>();


    private void Start()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            ListText.text += "-" + Items[i].taskDescription + "\n";
        }
    }

    void MarkItem()
    {

    }
}
