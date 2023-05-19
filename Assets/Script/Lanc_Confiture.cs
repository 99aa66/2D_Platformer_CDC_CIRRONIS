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
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPick == true)
        {
            PickedUp();
        }


        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && isPick)
        {
            Shoot();
        }

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenUs);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PickUp();
            Follow.enabled = false;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, GrabLayer);

        if (isGrounded)
        {
            Follow.enabled = true;
        }
    }

    void PickedUp()
    {
        transform.position = grabCheck.transform.position;
    }

    void PickUp()
    {
        isPick = true;
    }

    void Shoot()
    {
        isPick = false;
        //GameObject newArrow = Instantiate(Confiture, shotPoint.position, shotPoint.rotation);
        Confiture.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position;
    }
}
