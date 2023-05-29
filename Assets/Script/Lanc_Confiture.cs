using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lanc_Confiture : MonoBehaviour
{
    public GameObject Confiture;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenUs;
    Vector2 direction;
    public bool apparitionPoint = false;


    private Rigidbody2D rb2d;
    public Transform grabCheck;
    public float grabRange;
    public LayerMask GrabLayer; // couche du sol
    public Transform groundCheck;

    public bool isPick;
    private bool isPickable;
    private bool isFly;

    private Follow Follow;
    [SerializeField] private bool isGrounded = false;


    private void Start()
    {
        rb2d = Confiture.GetComponent<Rigidbody2D>();
        Follow = Confiture.GetComponent<Follow>();

        points = new GameObject[numberOfPoints];
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if (apparitionPoint == true)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenUs);
            }
        }
    }

    void FixedUpdate()
    {

        isPickable = Physics2D.OverlapCircle(grabCheck.position, grabRange , GrabLayer);
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        if (isPick == false && isPickable )
        {
            isPick = !isPick;
            Confiture.GetComponent<Rigidbody2D>().gravityScale = 1;
            Follow.enabled = false;
            gameObject.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponentInParent<Player_Commande>().enabled = false;
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            }
            ApparitionPont();
        }
        else if (isPick == true)
        {
            isPick = false;
            Confiture.GetComponent<Rigidbody2D>().gravityScale = 3;
            Follow.enabled = true;
            gameObject.GetComponentInParent<Player_Commande>().enabled = true;
            apparitionPoint = false;
            for (int i = 0; i < numberOfPoints; i++)
            {
                Destroy(points[i]);
            }
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (isPick)
        {
            isPick = false;
            Confiture.GetComponent<bullet>().enabled = true;
            //GameObject newArrow = Instantiate(Confiture, shotPoint.position, shotPoint.rotation);
            Confiture.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            gameObject.GetComponentInParent<Player_Commande>().enabled = true;
            apparitionPoint = false;
            for (int i = 0; i < numberOfPoints; i++)
            {
                Destroy(points[i]);
            }
        } 
    }

    void ApparitionPont()
    {
        apparitionPoint = true;
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position;
    }
}
