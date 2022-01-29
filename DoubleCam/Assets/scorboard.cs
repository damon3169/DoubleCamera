using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorboard : MonoBehaviour
{
     public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         text.SetText(GameObject.FindGameObjectWithTag("Player").GetComponent<fpsController>().score.ToString());
    }
}
