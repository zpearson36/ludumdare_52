using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        action
    }

    [SerializeField] private State state;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float walkingSpeed = 3.0f;
    [SerializeField] private float RunningSpeed = 6.0f;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        state = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown("Fire1"))
        //    Debug.Log("Fire1");
        //if(Input.GetButtonDown("Fire2"))
        //    Debug.Log("Fire2");
        //if(Input.GetButtonDown("Fire3"))
        //    Debug.Log("Fire3");
        //Debug.Log(getMovement().normalized * speed);
        switch(state)
        {
            case State.idle:
                if(getMovement() != Vector2.zero)
                    state = State.walking;
                break;
            case State.walking:
                speed = walkingSpeed;
                if(Input.GetButton("Fire2"))
                    speed = RunningSpeed;
                rb.velocity = getMovement().normalized * speed;
                break;
            case State.action:
                break;
        }
    }

    Vector2 getMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
