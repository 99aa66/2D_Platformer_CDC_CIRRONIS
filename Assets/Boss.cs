using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool actionFini;
    public enum BossState
    {
        Jump,
        Dash,
        MoveToDestination,
        ThrowShield,
        intro,
        Idle,
    }

    [SerializeField] private BossState currentState;
    private Transform destination;
    private int currentHealth;
    private int maxHealth = 100;
    private bool isInSecondPhase;

    private float stateChangeDelay = 3f; // D�lai entre les changements d'�tat
    private float stateTimer; // Timer pour g�rer les transitions d'�tat

    private void Start()
    {
        // Initialiser l'�tat du boss
        currentState = BossState.intro;
        currentHealth = maxHealth;
        isInSecondPhase = false;

        // D�marrer le timer pour le premier changement d'�tat
        stateTimer = stateChangeDelay;
    }

    private void Update()
    {
        // D�cr�menter le timer
        stateTimer -= Time.deltaTime;

        // V�rifier si le timer a atteint z�ro
        if (stateTimer <= 0f)
        {
            // Effectuer un changement d'�tat al�atoire
            ChangeToRandomState();

            // R�initialiser le timer
            stateTimer = stateChangeDelay;
        }

        // V�rifier l'�tat actuel du boss et ex�cuter le code appropri�
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'�tat Jump
                break;

            case BossState.Dash:
                // Code pour l'�tat Dash
                break;

            case BossState.MoveToDestination:
                // Code pour l'�tat MoveToDestination
                break;

            case BossState.ThrowShield:
                // Code pour l'�tat ThrowShield
                break;

            case BossState.intro:

                break;

            case BossState.Idle:
                // Code pour l'�tat Idle
                break;
        }
    }

    public void ChangeState(BossState newState)
    {
        // Changer l'�tat du boss
        currentState = newState;
    }

    public void SetDestination(Transform newDestination)
    {
        // D�finir une nouvelle destination pour le d�placement du boss
        destination = newDestination;
    }

    public void ThrowShield()
    {
        // Code pour lancer le bouclier
    }

    public void Jump()
    {
        // Code pour lancer le bouclier
    }

    public void FacePlayer()
    {

    }


    private void ChangeToRandomState()
    {
        if (actionFini)
        {

        // G�n�rer un nombre al�atoire pour s�lectionner un nouvel �tat
            int randomState = Random.Range(0, 4); // 6 est exclus, car il y a 6 �tats possibles

        // Convertir le nombre al�atoire en BossState
            BossState newState = (BossState)randomState;

        // V�rifier si le nouvel �tat est diff�rent de l'�tat actuel
            if (newState != currentState)
            {
            // Changer l'�tat du boss
                currentState = newState;
            }
            else if (newState == currentState)
            {
            // Si le nouvel �tat est identique � l'�tat actuel, g�n�rer un nouvel �tat al�atoire
                ChangeToRandomState();
            }
        }

    }

}
