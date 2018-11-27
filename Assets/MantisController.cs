using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MantisController : MonoBehaviour {

    Rigidbody mantisControls;
    CharacterController mantisChar;
    [SerializeField] public float jumpForce = 30f;
    [SerializeField] public float flutterPower = 100f;
    [SerializeField] public float speed = 0.1f;
    [SerializeField] public float strafe = 1.2f;
    [SerializeField] public float Delays = 100f;
    [SerializeField] public float Recovery = 1f;
    [SerializeField] public float RecoveryF = 1f;

    float InitialDelays;
    [SerializeField] public float flutterState = 0f;
    [SerializeField] public Slider valM;

    bool isDelay;
    bool isJumping;

    // Use this for initialization
    void Start () {
        InitialDelays = Delays;
        isDelay = false;
        isJumping = false;
        mantisControls = this.GetComponent<Rigidbody>();
        mantisChar = this.GetComponent<CharacterController>();
        Camera.main.transform.position = mantisChar.transform.position;
    }

    // Update is called once per frame
    void Update () {

        float forward = Input.GetAxis("Vertical") * speed;
        float sideways = Input.GetAxis("Horizontal") * speed;

        forward *= Time.deltaTime;
        sideways *= Time.deltaTime;

        localize(forward,sideways);
        flutterCheck();

        valM.value = flutterState;
       
        //mantisControls.MoveRotation(Camera.main.transform.rotation);

    }

    void flutterCheck(){
        if (Input.GetAxis("Jump").Equals(1) && isDelay == false)
        {
            mantisControls.AddForce(0, jumpForce, 0);
            flutterState++;
            isJumping = true;
        }else{
            isJumping = false;
        }
        if (isJumping == false && flutterState > 0)
        {
            flutterState -= RecoveryF;
        }
        if (flutterState > flutterPower)
        {
            isDelay = true;
        }

        if (isDelay == true)
        {
            Delays -= Recovery;
            if (Delays <= 0)
            {
                flutterState = 0;
                isDelay = false;
                Delays = InitialDelays;
            }
        }

    }

    void localize(float x, float z) {

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");

            Vector3 rot = new Vector3(x, 0, z);
            Vector3 dirs = Quaternion.Euler(0, -90, 0) * rot;
            Vector3 moveDir = Camera.main.transform.TransformDirection(dirs);
            moveDir *= (z * strafe);
            transform.Translate(moveDir);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            Vector3 rot = new Vector3(x, 0, z);
            Vector3 dirs = Quaternion.Euler(0, 90, 0) * rot;
            Vector3 moveDir = Camera.main.transform.TransformDirection(dirs);
            moveDir *= (z * strafe);
            transform.Translate(moveDir);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Forward");

            Vector3 rot = new Vector3(x, 0, z);
            Vector3 dirs = Quaternion.Euler(0, -90, 0) * rot;
            Vector3 moveDir = Camera.main.transform.TransformDirection(dirs);
            moveDir *= x;
            transform.Translate(moveDir);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Backward");

            Vector3 rot = new Vector3(x, 0, z);
            Vector3 dirs = Quaternion.Euler(0, 90, 0) * rot;
            Vector3 moveDir = Camera.main.transform.TransformDirection(dirs);
            moveDir *= x;
            transform.Translate(moveDir);
        }
    }
}
