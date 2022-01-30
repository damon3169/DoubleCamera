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
        public List<AudioClip> footstepList ;


    private AudioSource audioSource;
    private bool isWalking = false;
    CursorLockMode lockMode;
    public float FOVCam1 = 50;
    public float FOVCam2 = 50;
    public float AngleCam1 = 50;
    public float AngleCam2 = 50;
    public int score;

    Coroutine lastRoutineWalk ;

    private float currCountdownValue2;

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
        cam.fieldOfView = FOVCam1;
        cam2.fieldOfView = FOVCam2;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation+AngleCam1, 0.0f);
        cam2.transform.eulerAngles = new Vector3(xRotation, yRotation-AngleCam2, 0.0f);
        this.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);

        if (Input.GetButton("Fire1") && canShoot)
        {
            canShoot = false;
            StartCoroutine(StartCountdown());
            GameObject projectileInstance = GameObject.Instantiate(projectile, this.gameObject.transform.position, this.transform.localRotation);
            counter.changeCounter(1);
            anim.SetTrigger("HeadBumpTrigger");
            anim2.SetTrigger("HeadBumpTrigger");
            int rand = Random.Range(0,audioClips.Count);
            audioSource.clip = audioClips[rand];
            audioSource.Play();
        }
        Vector3 moveDir = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
      

        if (Input.GetAxisRaw ("Horizontal")!=0  && !isWalking|| Input.GetAxisRaw ("Vertical")!=0 && !isWalking){
            isWalking = true;
            lastRoutineWalk = StartCoroutine(countdownWalk());
        }
        if (Input.GetAxisRaw ("Horizontal")==0  && Input.GetAxisRaw ("Vertical")==0 && isWalking ){
            isWalking = false;
            StopCoroutine(lastRoutineWalk);
        }
		Vector3 targetMoveAmount = moveDir * playerSpeed;
		moveAmount = Vector3.SmoothDamp (moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
          if(Input.GetAxisRaw ("Horizontal")==0  && Input.GetAxisRaw ("Vertical")==0)
        {
            rigid.velocity =Vector3.zero;
        }
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
    public IEnumerator countdownWalk(float countdownValue = 0.7f)
    {
        currCountdownValue2 = countdownValue;
        int rand = Random.Range(0,footstepList.Count);
            audioSource.clip = footstepList[rand];
            audioSource.Play();
        while (currCountdownValue2 > 0)
        {
            yield return new WaitForSeconds(0.7f);
            currCountdownValue2--;
        }
        lastRoutineWalk = StartCoroutine(countdownWalk());
    }
}
