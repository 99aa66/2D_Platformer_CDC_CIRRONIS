using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch_Confiture : MonoBehaviour
{
    [SerializeField] private GameObject Tartine;
    [SerializeField] private GameObject Confiture;
    [SerializeField] private GameObject FlecheTartine;
    [SerializeField] private GameObject FlecheConfi;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Switch(InputAction.CallbackContext context)
    {
        if (gameObject.tag == "Player")
        {
            Tartine.GetComponent<Player_Commande>().enabled = false;
            Tartine.GetComponent<MeleeWeapon>().enabled = false;
            FlecheTartine.SetActive(false);
            FlecheConfi.SetActive(true);
            rb.velocity = Vector2.zero;
            Tartine.tag = "Switch";
            Confiture.tag = "Player";
            Confiture.GetComponent<Follow>().enabled = false;
            Confiture.GetComponent<PickUpAndThrow>().enabled = false;
            Confiture.GetComponent<Confiture_Mov>().enabled = true;
            Confiture.GetComponent<PlayerInput>().enabled = true;
            Tartine.GetComponent<PlayerInput>().enabled = false;
        }
    }
}
