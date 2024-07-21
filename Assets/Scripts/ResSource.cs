using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResSource : MonoBehaviour
{
    public RES resType;
    public int amountLeft;

    //  References
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.gameManager;

        //  Add to list
        if (!gameManager.resSources.Contains(this))
            gameManager.resSources.Add(this);
    }

    void Update()
    {
        if (amountLeft == 0)
        {
            gameManager.resSources.Remove(this);
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
