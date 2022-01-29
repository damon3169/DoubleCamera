using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timerValue = 180;
    public TextMeshPro text;

    float currCountdownValue;
    // Start is called before the first frame update
    private void Start()
    {
        text.SetText(timerValue.ToString());
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {

    }

    private void changeTimer(int newValueCounter)
    {
        timerValue -= newValueCounter;
        if (timerValue < 0)
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else
        {
            text.SetText(timerValue.ToString());
            StartCoroutine(StartCountdown());
        }
    }


    public IEnumerator StartCountdown(float countdownValue = 1)
    {
        currCountdownValue = countdownValue;

        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        changeTimer(1);
    }
}
