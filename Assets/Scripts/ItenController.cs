using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenController : MonoBehaviour
{
    public InterfaceControll scriptIntefaceControl;
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().Collections += value;
            scriptIntefaceControl.UpdateSliderCollections();
            Destroy(gameObject);
        }
    }
}