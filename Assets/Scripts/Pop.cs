using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{


    public GameObject target;
    public POP_STATE popState;

    public float popSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        switch (popState)
        {
            case POP_STATE.IDLE:

                break;
            case POP_STATE.MOVE_TO:
                transform.position += (target.transform.position - transform.position).normalized * popSpeed * Time.deltaTime;
                break;
            default:
                break;
        }


    }

}

public enum POP_STATE
{
    IDLE,
    MOVE_TO,
}

