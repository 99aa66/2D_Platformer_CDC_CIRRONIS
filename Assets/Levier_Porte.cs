using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier_Porte : MonoBehaviour
{
    [SerializeField]private GameObject porte;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("argh");
        if (collision.CompareTag("Player")==true)
        {
            Debug.Log("ffg");
            porte.gameObject.SetActive(false);
        }
    }
}
