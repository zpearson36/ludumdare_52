using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Inventory inventory;
    public enum State
    {
        idle,
        walking,
        action,
        inventory
    }
    public GameObject gameManager;

    [SerializeField] private State state;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float walkingSpeed = 3.0f;
    [SerializeField] private float runningSpeed = 6.0f;
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
        if(Input.GetButtonDown("Jump"))
            Debug.Log("Jump");
        //Debug.Log(getMovement().normalized * speed);
        switch(gameManager.GetComponent<GameManager>().getState())
        {
            case GameManager.State.idle:
                switch(state)
                {
                    case State.idle:
                        if(Input.GetButtonDown("Jump"))
                        {
                            inventory.GetComponent<Inventory>().open();
                            state = State.inventory;
                            break;
                        }
                        if(getMovement() != Vector2.zero)
                            state = State.walking;
                        break;
                    case State.walking:
                        if(getMovement() == Vector2.zero)
                            state = State.idle;
                        speed = walkingSpeed;
                        if(Input.GetButton("Fire2"))
                            speed = runningSpeed;
                        rb.velocity = getMovement().normalized * speed;
                        break;
                    case State.action:
                        break;
                    case State.inventory:
                        if(Input.GetButtonDown("Fire2"))
                        {
                            inventory.GetComponent<Inventory>().close();
                            state = State.idle;
                        }
                        break;
                }
                break;
            default:
                break;
        }
    }

    Vector2 getMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
