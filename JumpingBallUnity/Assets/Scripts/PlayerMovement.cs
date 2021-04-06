using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool jump = false;
    Rigidbody rb;
    Transform cameraHolder;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    Vector3 vec;

    [SerializeField] GameObject obstacle;
    [SerializeField] float obstacleDistance;
    [SerializeField] float obstaclePosY;
    [SerializeField] int numberOfObstacles;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraHolder = Camera.main.transform.parent;

        BuildObstacles();
    }

    private void BuildObstacles()
    {
        vec.z = 56.4f;
        for (int i = 0; i < numberOfObstacles; i++)
        {
            vec.z += obstacleDistance;
            vec.y = UnityEngine.Random.Range(-obstaclePosY, obstaclePosY);
            Instantiate(obstacle, vec, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * playerSpeed * Time.fixedDeltaTime);
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce*1000 * Time.fixedDeltaTime);
            jump = false;
        }
    }

    void LateUpdate()
    {
        vec.x = cameraHolder.transform.position.x;
        vec.y = cameraHolder.transform.position.y;
        vec.z = transform.position.z;

        cameraHolder.transform.position = vec;

    }
}
