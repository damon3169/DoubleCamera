using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody rigid;
    public Vector3 angleCam;
    public float speedProjectile = 5f;
    public GameObject Impact;
    // Start is called before the first frame update
    void Start()
    {
        rigid = transform.GetComponent<Rigidbody>();
        rigid.AddForce(this.transform.forward * speedProjectile);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Cible")
        {

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
