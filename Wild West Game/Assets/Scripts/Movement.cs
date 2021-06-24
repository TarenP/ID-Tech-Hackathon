using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public int speed = 5;
    Rigidbody rb;
    public float jumpForce = 4.0f;
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;

    [SerializeField] bool lockCursor = true;

    public EnemyGun gun;

    float cameraPitch = 0.0f;

    public float minClampy = -90f;
    public float maxClampy = 90f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(lockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.LeftLeg == false || gun.RightLeg == false)
        {
            speed = 2;
        }
        if (gun.LeftLeg == false && gun.RightLeg == false)
        {
            speed = 0;
        }

        MouseLook();
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        //if (Input.GetKey(KeyCode.Space) && jump==false){
        //rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        //jump = true;
        //anim.Play("Jump");
        //}
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
    }

    void MouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, minClampy, maxClampy);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
    }

    /*void OnCollisionEnter(Collision other){
            if(other.gameObject.CompareTag("Floor")){
                Debug.Log("Hit");
                jump = false;
            }
        }*/
}
