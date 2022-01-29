using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsController : MonoBehaviour
{
    public float playerSpeed = 5f;
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public Camera cam;
    public Camera cam2;
    public GameObject projectile;
    float currCountdownValue;
    bool canShoot = true;
    Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
    Vector3 moveDirection;

    Animator anim;
    Animator anim2;

    Rigidbody rigid;
    public counter counter;

    public List<AudioClip> audioClips ;

    private AudioSource audioSource;
    CursorLockMode lockMode;

    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        rigid = transform.parent.GetComponent<Rigidbody>();
    }

    void Start()
    {
        anim = cam.transform.parent.GetComponent<Animator>();
        anim2 = cam2.transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation+50, 0.0f);
        cam2.transform.eulerAngles = new Vector3(xRotation, yRotation-50, 0.0f);
        this.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

        if (Input.GetButton("Fire1") && canShoot)
        {
            canShoot = false;
            StartCoroutine(StartCountdown());
            GameObject projectileInstance = GameObject.Instantiate(projectile, this.gameObject.transform.position, this.transform.localRotation);
            projectileInstance.transform.eulerAngles = cam.transform.eulerAngles-new Vector3(0,55,0);
            counter.changeCounter(1);
            anim.SetTrigger("HeadBumpTrigger");
            anim2.SetTrigger("HeadBumpTrigger");
            int rand = Random.Range(0,audioClips.Count);
            Debug.Log(audioClips[rand]);
            audioSource.clip = audioClips[rand];
            audioSource.Play();
        }
        Vector3 moveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		Vector3 targetMoveAmount = moveDir * playerSpeed;
		moveAmount = Vector3.SmoothDamp (moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        
    }

    void FixedUpdate() {
		rigid.MovePosition (rigid.position + this.transform.TransformDirection (moveAmount) * Time.fixedDeltaTime);
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
