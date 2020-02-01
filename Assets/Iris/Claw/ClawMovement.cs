using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OrderCompletion;

public class ClawMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Body body;
    private Order order;
    private float speed;
    private bool movingLeft = false;
    private float maxXPosition = 6;
    private float maxOutsideXPosition = 10;

    public bool switchDirections = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        body = transform.GetComponentInChildren<Body>();
        order = transform.GetComponentInChildren<Order>();
        speed = .5f;
    }

    void FixedUpdate()
    {
        Vector3 tempVect = Vector3.right;
        if (movingLeft)
            tempVect = Vector3.left;

        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + tempVect);

        if (movingLeft && transform.position.x <= -maxXPosition || !movingLeft && transform.position.x >= maxXPosition)
            CheckOnEdges();

    }

    private void CheckOnEdges()
    {
        if (switchDirections)
            movingLeft = !movingLeft;
        else if (IsOrderComplete(body, order) && body.HasNotDropped())
        {
            body.DropFromClaw();
            speed = 5;
        }
        else
            CheckOutsideEdges();
    }

    private void CheckOutsideEdges()
    {
        if (movingLeft && transform.position.x <= -maxOutsideXPosition
            || !movingLeft && transform.position.x >= maxOutsideXPosition)
        {
            Destroy(gameObject);
        }
    }

}
