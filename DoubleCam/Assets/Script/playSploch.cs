using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSploch : MonoBehaviour
{
    public List<AudioClip> splochList; 

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
         int rand = Random.Range(0,splochList.Count);
            audioSource.clip = splochList[rand];
            audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
