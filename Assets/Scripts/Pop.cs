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
    public float interactDistance;

    //  Extra info
    public Building nearestWarehouse;
    public ResSource minedResource;

    //  References
    GameManager gameManager;

    //  Periodic update
    float periodicUpdateTime = 1;
    float periodicUpdateTimer = 0;

    void Start()
    {
        gameManager = GameManager.gameManager;

        //  Randomization
        periodicUpdateTime = Random.Range(periodicUpdateTime, periodicUpdateTime * 1.05f);
        popSpeed = Random.Range(popSpeed, popSpeed * 1.05f);

        PeriodicUpdate();
    }

    void Update()
    {
        UpdateMovement();

        //  Handle an update that happens once every second
        periodicUpdateTimer += Time.deltaTime;
        if(periodicUpdateTimer >= periodicUpdateTime)
        {
            periodicUpdateTimer = 0;
            PeriodicUpdate();
        }
    }

    void PeriodicUpdate()
    {
        nearestWarehouse = FindClosestWarehouse(transform.position);
    }

    void UpdateMovement()
    {
        switch (popState)
        {
            case POP_STATE.IDLE:

                break;
            case POP_STATE.MINE:

                //  If inventory not full
                if(carryCapacity > carrying)
                {
                    //  If within range of a target
                    if (Vector3.Distance(transform.position, minedResource.transform.position) <= interactDistance)
                    {
                        //  Mine it
                        carrying += minedResource.TakeResource(carryCapacity - carrying);
                    }
                    //  If too far - head to
                    else
                    {
                        transform.position += (minedResource.transform.position - transform.position).normalized * popSpeed * Time.deltaTime;
                    }
                }
                //  If inventory full
                else
                {
                    //  If within range of a warehouse
                    if (Vector3.Distance(transform.position, nearestWarehouse.transform.position) <= interactDistance)
                    {
                        //  Deposit
                        DepositAllResourceToStorage();
                    }
                    //  If too far - head to
                    else
                    {
                        transform.position += (nearestWarehouse.transform.position - transform.position).normalized * popSpeed * Time.deltaTime;
                    }
                }
                


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

    public Building FindClosestWarehouse(Vector3 startLocation)
    {
        Building closest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Building wHouse in gameManager.warehouses)
        {
            float dist = Vector3.Distance(startLocation, wHouse.transform.position);
            if (dist < shortestDistance)
            {
                closest = wHouse;
                shortestDistance = dist;
            }
        }

        return closest;
    }

}

public enum POP_STATE
{
    IDLE,
    MINE,
    MOVE_TO,
}

