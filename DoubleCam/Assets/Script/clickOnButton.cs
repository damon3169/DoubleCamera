using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class clickOnButton : MonoBehaviour
{
CursorLockMode lockMode;

    private void Start() {
        lockMode = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.None;
    }

    public List<GameObject> buttonList;

    public void onClickButtonStartGame()
    {
        SceneManager.LoadScene("Level Manager", LoadSceneMode.Single);
    }

    public void onClickButtonLevel1()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void onClickButtonLevel2()
    {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    public void onClickButtonLevel3()
    {
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
        SceneManager.LoadScene("Start Game", LoadSceneMode.Single);
    }

}
