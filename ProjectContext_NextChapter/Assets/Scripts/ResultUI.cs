using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] GameObject resultUI;
    bool isFinish = false;
    string Submit;
    // Start is called before the first frame update
    void Start()
    {
        Submit = "Submit1";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameOver && !isFinish)
        {
            resultUI.SetActive(true);
        }

            if(Input.GetButtonDown(Submit) || Input.GetKeyDown(KeyCode.E))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
            }
    }
}
