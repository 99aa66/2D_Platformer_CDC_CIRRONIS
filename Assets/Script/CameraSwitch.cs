using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private CameraFollow CF;
    // Start is called before the first frame update
    private void Start()
    {
        CF.enabled = true;
        cam.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.SetActive(true);
            CF.enabled = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            cam.SetActive(false);
            CF.enabled = true;
        }
    }
}
