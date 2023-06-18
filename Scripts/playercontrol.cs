using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity, sprintSpeed, jumpForce, smoothTime, walkSpeed;
    [SerializeField] GameObject cameraHolder;
    bool grounded;
    float verticalLookRotation;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    Rigidbody rb;
    Animator anm;
    public GameObject gm;
    public GameObject gm2;
    public GameObject gm3;
    GameObject animasyon;
    public bool permission = true;
    public bool permission2 = false;

    GameObject medkitCount;
   

    private void Awake()
    {
        StartCoroutine("IsKinematicOff");
        medkitCount = GameObject.Find("kit");
        animasyon = GameObject.Find("FPS-AK47");
        anm = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        Look();
        if(permission && permission2 == true)
        {
        Move();
        Jump();
        }
        useKit();
        animasyon.GetComponent<animationScript>().ChangeWeapon();
    }
    IEnumerator IsKinematicOff()
    {
        yield return new WaitForSeconds(20);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        permission2 = true;
    }

    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    public void useKit()
    {
        int fark=0;
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (gameObject.GetComponent<playerPROP>().can != 100 && medkitCount.GetComponent<medkit>().count > 0)
            {
                medkitCount.GetComponent<medkit>().count--;
                if (gameObject.GetComponent<playerPROP>().can <= 75)
                {
                    gameObject.GetComponent<playerPROP>().can += 25;
                }
                else
                {
                    fark = 100 - gameObject.GetComponent<playerPROP>().can;
                    gameObject.GetComponent<playerPROP>().can += fark;
                }
            }
        }
    }
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }
}