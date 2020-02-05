using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public PlayerNumber Player;
    public GameManager mgr;

    [SerializeField] UnityEngine.UI.Text textComponent;

    private void Start()
    {
        mgr = GameManager.Instance;
        textComponent = GetComponentInChildren<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        if (Player == PlayerNumber.Player1)
        {
            textComponent.text = mgr.Player1Money.ToString() + " €";
        }
        if (Player == PlayerNumber.Player2)
        {
            textComponent.text = mgr.Player2Money.ToString() + " €";
        }
    }
}
