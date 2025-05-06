using UnityEngine;

public class Player : Ship
{
    private float MaxMovement = 8;

    private void Start()
    {
        speed = 50;
    }

    public override void Move()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
