using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveVal;
    float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed); 
    }


    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

}