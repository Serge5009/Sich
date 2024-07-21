using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResSource : MonoBehaviour
{
    public RES resType;
    public int amountLeft;

    void Start()
    {
        
    }

    void Update()
    {
        if (amountLeft == 0)
        {
            Destroy(gameObject);
        }

    }

    public int TakeResource(int amount)
    {
        if(amountLeft >= amount)
        {
            amountLeft -= amount;
            return amount;
        }
        else
        {
            int leftover = amountLeft;
            amountLeft = 0;
            return leftover;
        }

    }

}
