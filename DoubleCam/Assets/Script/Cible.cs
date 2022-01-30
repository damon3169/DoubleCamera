using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public List<AudioClip> splochList;
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
        if (this.tag == "Cible")
        {
            animator.SetTrigger("Hit");
            this.tag = "CibleDead";

        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            this.tag = "CibleDead";
            this.GetComponent<Animator>().enabled = false;
        }
    }
private void OnCollisionEnter(Collision other) 
{
    if (this.tag=="CibleDead" && other.transform.tag!= "Projectile")
    {
         AudioSource audioSource = GetComponent<AudioSource>();
         int rand = Random.Range(0,splochList.Count);
            audioSource.clip = splochList[rand];
            audioSource.Play();
    }
    
}

}
