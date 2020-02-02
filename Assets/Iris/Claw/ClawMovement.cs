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
    private float maxPosition = 25;
    private float maxOutsidePosition = 30;

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
        Vector3 tempVect = Vector3.back;
        if (movingLeft)
            tempVect = Vector3.forward;

        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + tempVect);

        if (movingLeft && transform.position.z <= -maxPosition || !movingLeft && transform.position.z >= maxPosition)
            CheckOnEdges();

    }

    private void CheckOnEdges()
    {
        if (switchDirections)
            movingLeft = !movingLeft;
        else if (IsOrderComplete(body, order) && body.HasNotDropped())
        {
            body.DropFromClaw();
        }
        else
            CheckOutsideEdges();
        speed = 5;
    }

    private void CheckOutsideEdges()
    {
        if (movingLeft && transform.position.z <= -maxOutsidePosition
            || !movingLeft && transform.position.z >= maxOutsidePosition)
        {
            Destroy(gameObject);
        }
    }

}
