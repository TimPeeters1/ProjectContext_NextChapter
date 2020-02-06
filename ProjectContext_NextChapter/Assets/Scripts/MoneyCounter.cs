using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public PlayerNumber Player;
    public GameManager mgr;

    [SerializeField] UnityEngine.UI.Text Counter;
    [SerializeField] UnityEngine.UI.Text MinusCounter;

    private void Start()
    {
        mgr = GameManager.Instance;
        
        if (Player == PlayerNumber.Player1)
        {
            mgr.Player1Counter = this;
        }
        if (Player == PlayerNumber.Player2)
        {
            mgr.Player2Counter = this;
        }

        MinusCounter.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Player == PlayerNumber.Player1)
        {
            Counter.text = mgr.Player1Money.ToString() + " €";
        }
        if (Player == PlayerNumber.Player2)
        {
            Counter.text = mgr.Player2Money.ToString() + " €";
        }
    }

    public IEnumerator ShowBuyCounter(int Amount)
    {
        MinusCounter.gameObject.SetActive(true);
        MinusCounter.text = "-" + Amount + "$";
        
        yield return new WaitForSeconds(2);

        MinusCounter.gameObject.SetActive(false);
    }
}
