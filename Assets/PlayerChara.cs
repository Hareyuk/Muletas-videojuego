using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChara : MonoBehaviour
{
    //States
    public bool isIdle = false;
    public bool isWalking = false;
    public bool isJumping = false;
    public bool isFalling = false;
    public bool isGhost = false;
    public int currentState = 0; //0 = idle | walk = 1 | jump = 2 | fall = 3 | ghost = 4
    //Booleans
    public bool isInFloor = false;
    public bool canInteractue = false;
    public bool canJumpLevel = false;
    public bool pressedUp = false;
    //Data
    public float speed = 10;
    public float speedJump = 10;
    public float idCharacter = -1;
    bool changeAnimation = false;
    Animator anim;
    Rigidbody2D rb;
    Vector3 currentSize;
    void Awake()
    {
        currentSize = transform.localScale;
        canInteractue = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdateChara(float id)
    {
        idCharacter = id;
        switch(idCharacter)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;
        }
    }

    void TryToJump()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(changeAnimation)
        {
            changeAnimation = false;
            if (isIdle) anim.Play("idle");
            if (isWalking) anim.Play("walk");
            if (isJumping) anim.Play("jumping");
            if (isFalling) anim.Play("falling");
            if (isGhost)
            {
                anim.Play("ghost");
                canInteractue = false;
            }
        }

        if(canInteractue)
        {
            if (!pressedUp)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)) pressedUp = true;
            }
            else pressedUp = false;
            //Movement
            float direction = 0;
            if(isIdle || isJumping || isFalling || isWalking)
            {
                if (Input.GetKey(KeyCode.LeftArrow)) direction = -1;
                else if (Input.GetKey(KeyCode.RightArrow)) direction = 1;
                if (direction != 0)
                {
                    Vector3 newSize = new Vector3(currentSize.x * direction, currentSize.y, currentSize.z);
                    transform.localScale = newSize;
                }
                /*Vector2 newPos = new Vector2(rb.position.x + (direction * speed * Time.deltaTime), rb.position.y);
                rb.MovePosition(newPos);*/
                rb.velocity= new Vector2(speed * direction,0);
                if(isIdle && direction != 0)
                {
                    isIdle = false;
                    isWalking = true;
                    changeAnimation = true;
                    currentState = 1;
                }
                if(direction == 0 && isWalking)
                {
                    isIdle = true;
                    isWalking = false;
                    changeAnimation = true;
                    currentState = 0;
                }
            }
        }
    }

    public void Die()
    {
        changeAnimation = true;
        isGhost = true;
        canInteractue = false;
        isIdle = false;
        isJumping = false;
        isWalking = false;
        isFalling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.IndexOf("floor") != -1)
        {
            isFalling = false;
            isJumping = false;
            isIdle = true;
            isInFloor = true;
            changeAnimation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.IndexOf("floor") != -1)
        {
            isInFloor = false;
            isWalking = false;
            if (!isJumping) isFalling = true;
            changeAnimation = true;
        }
    }
}
