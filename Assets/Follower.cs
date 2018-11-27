//Source taken from: https://github.com/Acacia-Developer/Acacia-Developer-Tutorials/tree/master/%5BUnity%20C%23%20%5D%20First%20Person%20Controller%20Series/E01%20Basic%20FPS%20Controller%20and%20Jumping

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    Vector2 rotation = new Vector2(0, 0);
    [SerializeField] float speed;
    public float reach = 4f;
    public float punch = 15f;
    public float holdP = 10f;
    private float xAxisClamp;
    MantisController multiplier;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        multiplier = target.GetComponent<MantisController>();
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        this.transform.position = target.transform.position;
        CameraRotation();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Push();
        }

    }

    private void CameraRotation()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }

    void Push()
    {
        RaycastHit rays;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rays, punch))
        {
            Rigidbody array = rays.transform.GetComponent<Rigidbody>();
            if (array != null)
            {
                float punchHold = 0;
                while (punchHold < holdP)
                {
                    Vector3 forcer = Camera.main.transform.forward * reach;
                    array.AddForce(forcer);
                    punchHold++;
                }
            }
        }
    }

    
}