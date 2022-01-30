using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody rigid;
    public Vector3 angleCam;
    public float speedProjectile = 5f;
    public GameObject Impact;

    public GameObject Trail;

    public ParticleSystem waterSplash;

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
        if (other.transform.tag == "Cible" ||other.transform.tag == "CibleMouvante")
        {
            CibleCont.CibleList.Remove(other.gameObject);
            other.gameObject.GetComponent<Cible>().CibleHit();
            GameObject.FindGameObjectWithTag("Player").GetComponent<fpsController>().score += 1;
            Debug.Log("CIBLE ELIMINE");
        }
        else
        {
            Debug.Log("Splash !!!!");
        }
        Vector3 normal = other.contacts[0].normal;
        Vector3 myCollisionVelocity = rigid.velocity;

        float collisionAngleTest1 = Vector3.Angle(myCollisionVelocity, -normal);
        GameObject Impact1 = Instantiate(Impact, other.contacts[0].point + other.contacts[0].normal * 0.02f,
        Quaternion.Euler(other.contacts[0].normal.z * 90, other.contacts[0].normal.y * -90, other.contacts[0].normal.x * -90));
        Instantiate(waterSplash, this.transform.position,
        Quaternion.identity);
        if (other != null)
            Impact1.transform.parent = other.transform;
        Impact1.transform.rotation = Quaternion.Euler(other.contacts[0].normal.z * 90 - Impact1.transform.parent.rotation.z,
        other.contacts[0].normal.y * -90 - Impact1.transform.parent.rotation.y,
        other.contacts[0].normal.x * -90 - Impact1.transform.parent.rotation.x);
        Trail.transform.parent = Impact1.transform;
        Destroy(this.gameObject);
    }
}
