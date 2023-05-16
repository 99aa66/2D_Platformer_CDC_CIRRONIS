using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Switch_Perso : MonoBehaviour
{
    [SerializeField] private GameObject PlayerToSwitch;
    [SerializeField] private GameObject FlechePlayer;

    // Update is called once per frame
    void start()
    {
       
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if(gameObject.tag == "Player")
        {
            GetComponent<Player_Commande>().enabled = false;
            GetComponent<MeleeWeapon>().enabled = false;
            gameObject.tag = "Switch";
            PlayerToSwitch.GetComponent<Follow>().enabled = false;
            PlayerToSwitch.GetComponent<Confiture_Mov>().enabled = true;
        }
        
    }
}
