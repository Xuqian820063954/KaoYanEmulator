using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }
    void Run()
    {
        myRigidBody.velocity = new Vector2(0, 0);
        myAnim.SetBool("Up", false);
        myAnim.SetBool("Down", false);
        myAnim.SetBool("Left", false);
        myAnim.SetBool("Right", false);
        float moveDirY = Input.GetAxis("Vertical");
        Debug.Log(moveDirY);
        if (moveDirY != 0)
        {
            Vector2 playerVel = new Vector2(0.0f, moveDirY * speed);
            myRigidBody.velocity = playerVel;
            if (moveDirY > Mathf.Epsilon)
                myAnim.SetBool("Up", true);
            else if (moveDirY < -Mathf.Epsilon)
                myAnim.SetBool("Down", true);
            return;
        }
        float moveDirX = Input.GetAxis("Horizontal");
        if (moveDirX != 0)
        {
            Vector2 playerVel = new Vector2(moveDirX * speed, 0.0f);
            myRigidBody.velocity = playerVel;
            if (moveDirX > Mathf.Epsilon)
                myAnim.SetBool("Right", true);
            else if (moveDirX < -Mathf.Epsilon)
                myAnim.SetBool("Left", true);
        }
    }
}
