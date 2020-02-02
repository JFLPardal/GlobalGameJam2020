using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int movementSpeed = 10;

    private Vector2 movement;
    private Vector3 rotation;
    private bool canMove = true;

    public void ChangeMoveAbility() { canMove = !canMove; }

    void Update()
    {
        if(canMove)
        {
            Move();
        }
        Rotate();
    }

    private void Move()
    {
        Vector3 newMovement = new Vector3(-movement.y, 0, movement.x) * Time.deltaTime * movementSpeed;
        transform.Translate(newMovement);
    }

    private void Rotate()
    {
        transform.Rotate(rotation, Space.World);
    }
    void OnMove(InputValue input)
    {
        movement = input.Get<Vector2>();
    }

    void OnRotate(InputValue input)
    {
        rotation = new Vector3(0, input.Get<float>(), 0);
    }
}
