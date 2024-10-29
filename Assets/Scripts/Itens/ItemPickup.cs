using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;
    private Color colorEmission;
    private void Start ()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        //colorEmission = GetComponent<Renderer>.Material.GetColor("_EmissionColor");
    }
    /* private void Pickup
     {
       InventoryManager.instance.AddItens(itens);
       Destroy(gameObject); 
     }*/
}
