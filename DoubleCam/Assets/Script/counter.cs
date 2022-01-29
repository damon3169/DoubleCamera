using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class counter : MonoBehaviour
{
    public int counterValue = 30;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    private void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        text.SetText(counterValue.ToString());
    }
    public void changeCounter(int newValueCounter)
    {
        counterValue -= newValueCounter;
        if (counterValue < 0)
        {
            PlayerPrefs.SetInt("score",GameObject.FindGameObjectWithTag("Player").GetComponent<fpsController>().score);
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
        else
        {
            text.SetText(counterValue.ToString());
        }
    }

}
