using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class clickOnButton : MonoBehaviour
{
CursorLockMode lockMode;
public AudioSource audioSource;

    private void Start() {
        lockMode = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.None;
    }

    public List<GameObject> buttonList;

    public void onClickButtonStartGame()
    {
        audioSource.Play();
        SceneManager.LoadScene("Level Manager", LoadSceneMode.Single);
    }

    public void onClickButtonLevel1()
    {
        audioSource.Play();
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void onClickButtonLevel2()
    {
        audioSource.Play();
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void onClickButtonLevel3()
    {
        audioSource.Play();
        SceneManager.LoadScene("Level 3", LoadSceneMode.Single);
    }
  /*  private void Update()
    {
        if (SceneManager.GetActiveScene().ToString() == "Level Manager")
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (PlayerPrefs.GetInt("levelUnlock") <= i)
                {
                    
                }
            }
        }
    }*/

     public void onClickButtonBackToMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene("Start Game", LoadSceneMode.Single);
    }

}
