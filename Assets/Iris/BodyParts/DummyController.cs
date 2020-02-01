using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    public int movementspeed = 100;

    BodyPart bp;

    // Use this for initialization
    void Start()
    {
        bp = GetComponent<BodyPart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bp.isInMixer())
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * movementspeed * Time.deltaTime);
            }
        }
    }
}
