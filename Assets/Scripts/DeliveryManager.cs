
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    #region Singleton
    public static DeliveryManager deliveryManager { get; private set; }

    private void Awake()
    {
        if (deliveryManager != null && deliveryManager != this)
        {
            Destroy(this);
        }
        else
        {
            deliveryManager = this;
        }
    }

    #endregion

    public List<Delivery> deliveries;

    void Start()
    {
        deliveries = new();
    }


    void Update()
    {
        
    }

    public void CreateDelivery(Building delFrom, Building delTo, RES resType, int amount, Pop assignee)
    {
        Delivery newDel = new();
        newDel.deliveredResource = resType;
        newDel.deliveryAmount = amount;
        newDel.destination = delTo; 
        newDel.origin = delFrom;
        newDel.assignedPop = assignee;



    }
}
