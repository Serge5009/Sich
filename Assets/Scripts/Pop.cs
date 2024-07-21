using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{


    public GameObject target;
    public POP_STATE popState;

    public int carrying;
    public RES currentRes;

    public int carryCapacity;
    public float popSpeed;

    //  References
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;


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

    public void DepositAllResourceToStorage()
    {
        gameManager.AddResource(currentRes, carrying);

        carrying = 0;
    }

    public bool GetResourceFromStorage(RES resType, int amount)
    {
        //  If trying to override the current Res - fail
        if(amount > 0 && resType != currentRes)
        {   
            return false;
        }
        //  If amount doesn't fit - fail
        else if(amount + carrying > carryCapacity && resType == currentRes)
        {
            return false;
        }

        //  Try to take from GameManager
        if(!gameManager.TryTakeResource(resType, amount))   
        {
            return false;   //  If not enough - fail
        }


        //  If didn't fail before - add resources
        currentRes = resType;
        carrying += amount;

        return true;
    }

}

public enum POP_STATE
{
    IDLE,
    MOVE_TO,
}

