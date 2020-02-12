using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Player1Money;
    public int Player2Money;

    public MoneyCounter Player1Counter;
    public MoneyCounter Player2Counter;

    public TaskList Player1List;
    public TaskList Player2List;

    public static bool isGameOver = false;

    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject instance = new GameObject("GameManager");
                instance.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;
    }
    #endregion

    private void Update()
    {
        if (isGameOver)
            GameOver();
    }
    public void GameOver()
    {
        
    }
}


