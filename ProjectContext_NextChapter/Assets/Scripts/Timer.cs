using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]float StartTime;
    float CurrentTime;
    string CurrentMinText;
    string CurrentSecText;
    string CurrentBeforeText;
    string CurrentTimeText;
    Image TimerUI;
    Text TimerText;
    Animation TextAnimation;

    private void Awake()
    {
        CurrentTime = StartTime;
    }
    void Start()
    {
        TimerUI = transform.GetChild(0).GetComponent<Image>();
        TimerText = transform.GetChild(1).GetComponent<Text>();
        TextAnimation = transform.GetChild(1).GetComponent<Animation>();
    }

    void MoveTime()
    {
        CurrentTime -= Time.deltaTime;

            CurrentMinText = Mathf.Floor(CurrentTime / 60).ToString("F0");

            if (CurrentTime % 60 != 10 && CurrentTime % 60 != 60 && CurrentTime % 60 < 10)
                CurrentSecText = "0" + Mathf.Floor(CurrentTime % 60).ToString("F0");
            else
                CurrentSecText = Mathf.Floor(CurrentTime % 60).ToString("F0");



        CurrentTimeText = CurrentMinText + " : " + CurrentSecText;
        TimerUI.fillAmount = (CurrentTime / StartTime);
        TimerText.text = CurrentTimeText;

        if (CurrentTime <= 11)
        {
            if (CurrentSecText != CurrentBeforeText)
            {
                TextAnimation.Play();
                CurrentBeforeText = CurrentSecText;
            }
        }
    }

    void Update()
    {
        if (CurrentTime < 0)
        {
            GameOver();
        }
        else
        {
            MoveTime();
        }
    }

    public void GameOver()
    {
        TimerText.color = new Color(255, 0, 0);
        TimerText.text = "Round Over";
    }

}
