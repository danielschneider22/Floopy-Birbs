using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private float thrust = 500f;
    private float initPositionX;
    private float maxSpeed = 10f;
    private AudioManager audioManager;

    public Transform forcePosition;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        initPositionX = transform.position.x;
    }
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                BirdGoUp();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BirdGoUp();
        }

        transform.position = new Vector2(initPositionX, transform.position.y);
        playerRigidBody.velocity = Vector3.ClampMagnitude(playerRigidBody.velocity, maxSpeed);
        playerRigidBody.angularVelocity = playerRigidBody.velocity.y > 0f ? playerRigidBody.velocity.y * 30f : playerRigidBody.velocity.y * 20f;
        // playerRigidBody.angularVelocity = Mathf.Max(playerRigidBody.angularVelocity, -10f);
    }

    private void BirdGoUp()
    {
        audioManager.Play("Whistle");
        if (playerRigidBody.velocity.y < 0f)
        {
            playerRigidBody.AddForce(new Vector3(0, 1.0f, 0) * thrust * 3f);
        } else
        {
            playerRigidBody.AddForce(new Vector3(0, 1.0f, 0) * thrust);
        }
       
    }

    void FixedUpdate()
    {
        if (transform.eulerAngles.z > 45f && transform.eulerAngles.z < 100f)
        {
            transform.eulerAngles = new Vector3(0, 0, 45f);
        } else if (transform.eulerAngles.z < 290 && transform.eulerAngles.z > 270f)
        {
            transform.eulerAngles = new Vector3(0, 0, 290f);
        }

        transform.position = new Vector2(initPositionX, transform.position.y);
    }
}
