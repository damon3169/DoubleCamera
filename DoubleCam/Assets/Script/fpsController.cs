using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    public Camera cam2;
    public GameObject projectile;
    float currCountdownValue;
    bool canShoot = true;


    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }

    void Start()
    {
        cam = Camera.main;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        cam.transform.eulerAngles = new Vector3(xRotation, yRotation+55, 0.0f);
        this.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        cam2.transform.eulerAngles = new Vector3(xRotation, yRotation-55, 0.0f);

        if (Input.GetButton("Fire1") && canShoot)
        {
            canShoot = false;
            StartCoroutine(StartCountdown());
            GameObject projectileInstance = GameObject.Instantiate(projectile, this.gameObject.transform.position , this.transform.localRotation);
            projectile.transform.eulerAngles = cam.transform.eulerAngles;
        }
    }

    public IEnumerator StartCountdown(float countdownValue = 1)
    {
        currCountdownValue = countdownValue;

        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        canShoot = true;

    }
}
