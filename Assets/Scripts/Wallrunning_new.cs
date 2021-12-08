using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning_new : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform orientation;

    [Header("Wall Running")]
    [SerializeField] private float wallDistance = .5f;
    [SerializeField] private float wallDistance2 = .7f;
    [SerializeField] private float minimumJumpHeight = 1.5f;

    [Header("Wall Running")]
    [SerializeField] private float wallRunGravity;
    [SerializeField] private float wallRunJumpForce;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunfov;
    [SerializeField] private float wallRunfovTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

    public float tilt { get; private set; }

    private bool wallLeft = false;
    private bool wallRight = false;

    RaycastHit leftWallHit;
    RaycastHit rightWallHit;

    private Rigidbody rb;
    
    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Wall run")
        {
            if (Physics.Raycast(transform.position, -orientation.right, out RaycastHit leftWallHit, wallDistance2))
            {
                wallLeft = true;

            }

            if (Physics.Raycast(transform.position, orientation.right, out RaycastHit rightWallHit, wallDistance2))
            {
                wallRight = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall run")
        {
            if (Physics.Raycast(transform.position, -orientation.right, out RaycastHit leftWallHit, wallDistance))
            {
                wallLeft = true;

            }

            if (Physics.Raycast(transform.position, orientation.right, out RaycastHit rightWallHit, wallDistance))
            {
                wallRight = true;
            }
        }
    }

    private void Update()
    {
        if (CanWallRun())
        {
            if (wallLeft)
            {
                StartWallRunLeft();
                
            }
            else if (wallRight)
            {
                StartWallRunRight();
                
            }
            else
            {
                StopWallRun();
            }
        }
        else
        {
            StopWallRun();
        }
    }

    public void StartWallRunLeft()
    {
        Debug.Log("wall running on the left");

        rb.useGravity = false;

        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

        if (wallLeft)
            tilt = Mathf.Lerp(tilt, -camTilt, camTiltTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallLeft)
            {
                Vector3 wallrunJumpDirection = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallrunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);

                StopWallRun();
            }

        }
    }

    public void StartWallRunRight()
    {
        Debug.Log("wall running on the right");

        rb.useGravity = false;

        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunfov, wallRunfovTime * Time.deltaTime);

        if (wallRight)
            tilt = Mathf.Lerp(tilt, camTilt, camTiltTime * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallRight)
            {
                Vector3 wallrunJumpDirection = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallrunJumpDirection * wallRunJumpForce * 100, ForceMode.Force);

                StopWallRun();
            }

        }
    }

    void StopWallRun()
    {
        rb.useGravity = true;

        wallLeft = false;
        wallRight = false;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunfovTime * Time.deltaTime);
        tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
    }
}
