using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float moveSpeed = 10.0f;
    public Animator playerAnim;
    private PlayerInput playerInput;
    private Vector2 move;
    readonly float xRange = 15.0f;
    readonly float zRange = 6.5f;
    //private NavMeshAgent navMeshAgent;
    

    // Start is called before the first frame update
    void Start()
    {
       playerInput = GetComponent<PlayerInput>();
       playerAnim = GetComponent<Animator>();
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Shoot();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void MovePlayer()
    {
        //Keeps player inbound
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        //Makes player move
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        if(playerInput.actions.FindAction("Move").inProgress)
        {
            playerAnim.SetFloat("Speed_f", 2);
            playerAnim.SetBool("Static_b", false);
        }
        else if(!playerInput.actions.FindAction("Move").triggered)
        {
            playerAnim.SetFloat("Speed_f", 0);
            playerAnim.SetBool("Static_b", true);
        }
        
        

        /*Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            dir.x = -1.0f;
        if (Input.GetKey(KeyCode.RightArrow))
            dir.x = 1.0f;
        if (Input.GetKey(KeyCode.UpArrow))
            dir.z = 1.0f;
        if (Input.GetKey(KeyCode.DownArrow))
            dir.z = -1.0f;
        navMeshAgent.velocity = dir.normalized * moveSpeed;*/


        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(horizontalInput * moveSpeed * Time.deltaTime * Vector3.right);

        //verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(verticalInput * moveSpeed * Time.deltaTime * Vector3.forward);
    }

    void Shoot()
    {
        if(playerInput.actions.FindAction("Shoot").inProgress)
        {
            playerAnim.SetInteger("WeaponType_int", 1);
            playerAnim.SetBool("Shoot_b", true);
            playerAnim.SetBool("Reload_b", false);
        }
        //else if (!playerInput.actions.FindAction("Shoot").triggered)
        //{
        //    playerAnim.SetInteger("WeaponType_int", 0);
        //    playerAnim.SetBool("Shoot_b", false);
        //    playerAnim.SetBool("Reload_b", false);
        //}
    }
}
