using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody rigid;
    public Vector3 angleCam;
    public float speedProjectile = 5f;
    public GameObject Impact;

    private CiblesController CibleCont;
    // Start is called before the first frame update
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
        rigid.AddForce(this.transform.forward * speedProjectile);
        CibleCont = GameObject.FindGameObjectWithTag("CibleController").GetComponent<CiblesController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Cible")
        {
            CibleCont.CibleList.Remove(other.gameObject);
            other.gameObject.GetComponent<Cible>().CibleHit();
            Debug.Log("CIBLE ELIMINE");
        }
        else
        {
            Debug.Log("Splash !!!!");
        }
        GameObject Impact1 = Instantiate(Impact, this.transform.position, Quaternion.identity);
        if (other != null)
            Impact1.transform.parent = other.transform;
        Destroy(this.gameObject);
    }
}
