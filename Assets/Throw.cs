using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform target;
    private bool isBeingThrown = false; // Indique si le compagnon est en train d'être lancé

    private Vector3 initialPosition; // Position initiale du compagnon
    private Quaternion initialRotation; // Rotation initiale du compagnon

    private Rigidbody2D rb; // Composant Rigidbody du compagnon
    private Transform projectileSpawnPoint;

    private void Awake()
    {
        projectileSpawnPoint = transform;
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isBeingThrown)
        {
            LaunchProjectile();
        }
    }
   


    private void LaunchProjectile()
    {
        isBeingThrown = true;

        // Détacher le compagnon du joueur
        transform.parent = null;

        // Calcul de la distance entre le compagnon et la cible
        float targetDistance = Vector2.Distance(transform.position, target.position);

        float firingAngle = CalculateFiringAngle(targetDistance);
        float gravity = CalculateGravity(targetDistance, firingAngle);

        // Calcul de la vitesse horizontale requise
        float projectileVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Calcul des composantes x et y de la vitesse initiale
        float Vx = Mathf.Sqrt(projectileVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectileVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Lancer le compagnon en lui appliquant une force initiale
        rb.velocity = new Vector2(transform.forward * Vx , Vector2.up * Vy);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void ResetProjectile()
    {
        isBeingThrown = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    private float CalculateFiringAngle(float distance)
    {
        float angle = 0f;
        float targetHeight = target.position.y - projectileSpawnPoint.position.y;
        float gravity = Physics.gravity.magnitude;

        float maxDistance = distance / 2f;

        float numerator = Mathf.Pow(maxDistance, 2) * gravity;
        float denominator = Mathf.Pow(maxDistance, 2) + targetHeight * gravity * 2f;

        angle = Mathf.Atan(numerator / denominator) * Mathf.Rad2Deg;

        return angle;
    }

    private float CalculateGravity(float distance, float firingAngle)
    {
        float gravity = 0f;

        float maxDistance = distance / 2f;
        float time = maxDistance / (Mathf.Cos(firingAngle * Mathf.Deg2Rad) * Mathf.Sqrt(maxDistance * Physics.gravity.magnitude));

        gravity = (2f * target.position.y) / Mathf.Pow(time, 2);

        return gravity;
    }
}

