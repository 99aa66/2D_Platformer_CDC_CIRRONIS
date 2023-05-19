using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch_Perso : MonoBehaviour
{
    [SerializeField] private GameObject Tartine;
    [SerializeField] private GameObject Confiture;
    [SerializeField] private GameObject FlecheTartine;
    [SerializeField] private GameObject FlecheConfi;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {

    }
    public void Switch(InputAction.CallbackContext context)
    {
        if(gameObject.tag == "Player")
        {
            Tartine.GetComponent<Player_Commande>().enabled = true;
            Tartine.GetComponent<MeleeWeapon>().enabled = true;
            FlecheTartine.SetActive(true);
            FlecheConfi.SetActive(false);
            Tartine.tag = "Player";
            Confiture.tag = "Switch";
            Confiture.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Confiture.GetComponent<Follow>().enabled = true;
            Confiture.GetComponent<PickUpAndThrow>().enabled = true;
            Confiture.GetComponent<Confiture_Mov>().enabled = false;
            Confiture.GetComponent<PlayerInput>().enabled = false;
            Tartine.GetComponent<PlayerInput>().enabled = true;
        }
    }
}
