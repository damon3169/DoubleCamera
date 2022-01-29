using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> soundList;
    Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CibleHit()
    {
        animator.SetTrigger("Hit");
        this.GetComponent<Collider>().isTrigger = true;
    }

   
}
