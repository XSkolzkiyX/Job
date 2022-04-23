using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public short typeOfFood;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<Movement>().EatFood(typeOfFood);
            Destroy(gameObject);
        }
    }
}
