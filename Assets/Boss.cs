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

    private float stateChangeDelay = 3f; // Délai entre les changements d'état
    private float stateTimer; // Timer pour gérer les transitions d'état

    private void Start()
    {
        // Initialiser l'état du boss
        currentState = BossState.intro;
        currentHealth = maxHealth;
        isInSecondPhase = false;

        // Démarrer le timer pour le premier changement d'état
        stateTimer = stateChangeDelay;
    }

    private void Update()
    {
        // Décrémenter le timer
        stateTimer -= Time.deltaTime;

        // Vérifier si le timer a atteint zéro
        if (stateTimer <= 0f)
        {
            // Effectuer un changement d'état aléatoire
            ChangeToRandomState();

            // Réinitialiser le timer
            stateTimer = stateChangeDelay;
        }

        // Vérifier l'état actuel du boss et exécuter le code approprié
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'état Jump
                break;

            case BossState.Dash:
                // Code pour l'état Dash
                break;

            case BossState.MoveToDestination:
                // Code pour l'état MoveToDestination
                break;

            case BossState.ThrowShield:
                // Code pour l'état ThrowShield
                break;

            case BossState.intro:

                break;

            case BossState.Idle:
                // Code pour l'état Idle
                break;
        }
    }

    public void ChangeState(BossState newState)
    {
        // Changer l'état du boss
        currentState = newState;
    }

    public void SetDestination(Transform newDestination)
    {
        // Définir une nouvelle destination pour le déplacement du boss
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

        // Générer un nombre aléatoire pour sélectionner un nouvel état
            int randomState = Random.Range(0, 4); // 6 est exclus, car il y a 6 états possibles

        // Convertir le nombre aléatoire en BossState
            BossState newState = (BossState)randomState;

        // Vérifier si le nouvel état est différent de l'état actuel
            if (newState != currentState)
            {
            // Changer l'état du boss
                currentState = newState;
            }
            else if (newState == currentState)
            {
            // Si le nouvel état est identique à l'état actuel, générer un nouvel état aléatoire
                ChangeToRandomState();
            }
        }

    }

}
