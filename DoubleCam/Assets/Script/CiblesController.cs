using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CiblesController : MonoBehaviour
{
    public List<GameObject> CibleList;
    // Start is called before the first frame update
    void Start()
    {
       CibleList= new List<GameObject>(GameObject.FindGameObjectsWithTag("Cible"));
    }

    // Update is called once per frame
    void Update()
    {
        if (CibleList.Count == 0)
        {
             SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
    }
}
