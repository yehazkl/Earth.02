using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    //player rotation
    float mouseX;
    float lookSpeed;
    public Transform cameraTurn;
    float mouseY;
    float cameraX;
    //player movement
    float xAxis;
    float zAxis;
    float moveSpeed;
    float moveSpeedBonus;
    CharacterController cc;
    public static float xpos;
    Vector3 v;
    public Transform weapon;
    Animator animecontrol;
    // gravity
    public bool isGround;
    float radius;
    public LayerMask groundLayerMask;
    public Transform groundCheck;
    float gravity;
    Vector3 velocity;
    int multiJumps;

    // Weapon
    Vector3 StartPoint;

    // Start is called before the first frame update
    void Start()
    {
       
     
        //player rotation
        lookSpeed = 90;
        cameraX = 0;

        // player movement
        cc = GetComponent<CharacterController>();
        animecontrol = GetComponent<Animator>();
        moveSpeed = 20;
        moveSpeedBonus = 6;
        xpos = transform.position.x;
      

        //gravity
        isGround = false;
        radius = 0.2f;
        gravity = -9.81f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerMove();
        Gravity();
        Crouch();
       
    }

    void Gravity()
    {
        if (Physics.CheckSphere(groundCheck.position, radius, groundLayerMask))
        {
            isGround = true;
            multiJumps = 2;
        }
        else
        {
            isGround = false;
        }
        if (isGround == false)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }
        if (Input.GetButtonDown("Jump") && multiJumps > 0)
        {
            velocity.y += 6;
            multiJumps--;
        }
        cc.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            velocity.y += 30;

        }
    }

    void PlayerMove()
    {
        xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        v = transform.forward * zAxis + transform.right * xAxis;
        cc.Move(v * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Z))
        {
            cc.Move(v * moveSpeed * moveSpeedBonus * Time.deltaTime);
            animecontrol.SetBool("RunPlayer", true);
        }
        else
        {
            animecontrol.SetBool("RunPlayer", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animecontrol.SetBool("WalkPlayer", true);
        

        }
        else
        {
            animecontrol.SetBool("WalkPlayer", false);
        }

       

    }
    void PlayerRotation()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
        mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        cameraX -= mouseY;
        cameraX = MyClamp(cameraX, -90, 42.5f);
        cameraTurn.localRotation = Quaternion.Euler(cameraX, 0, 0);
    }

    float MyClamp(float curr, float min, float max)
    {
        if (curr < min)
        {
            return min;
        }
        else if (curr > max)
        {
            return max;
        }
        else
        {
            return curr;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.X) && transform.localScale.y == 1)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            weapon.transform.localScale = new Vector3(1, 2, 1);

        }
        else if (Input.GetKeyDown(KeyCode.X) && transform.localScale.y == 0.5f)
        {
          
            transform.localScale = new Vector3(1, 1, 1);
            weapon.transform.localScale = new Vector3(1, 1, 1);
            
        }


    }
}
