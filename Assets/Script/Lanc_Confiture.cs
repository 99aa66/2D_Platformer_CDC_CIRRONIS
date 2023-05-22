using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public LayerMask GrabLayer; // couche du sol
    public Transform groundCheck;

    public bool isPick;
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            PickUp();
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

        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && isPick)
        {
            Shoot();
        }

        if (apparitionPoint == true)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PointPosition(i * spaceBetweenUs);
            }
        }
    }

    //void FixedUpdate()
    //{

    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, GrabLayer);

    //    if (isGrounded)
    //    {
    //        //Follow.enabled = true;
    //    }
    //}

    void PickUp()
    {
        isPick = !isPick;
    }

    void Shoot()
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
