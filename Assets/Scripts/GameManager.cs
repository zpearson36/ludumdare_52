using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        idle,
        menu
    }

    [SerializeField] private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public State getState()
    {
        return state;
    }

    public State getIdle()
    {
        return State.idle;
    }

    public State getMenu()
    {
        return State.menu;
    }
}
