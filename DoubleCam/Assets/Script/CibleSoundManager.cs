using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> soundList;
     private void Start()
    {

        AudioSource sourceAudio = GetComponent<AudioSource>();
        int rand = Random.Range(0, soundList.Count);
        sourceAudio.clip = soundList[rand];
        sourceAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
