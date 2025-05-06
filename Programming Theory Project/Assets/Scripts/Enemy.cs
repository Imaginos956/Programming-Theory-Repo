using UnityEngine;

public class Enemy : Ship
{

    private float moveDistance = 1.5f;
    private float dropDistance = 0.1f;

    private Vector3 startPosition;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 0.2f;
        startPosition = transform.position;
    }

    // Update is called once per frame
    public override void Move()
    {

        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
                transform.Translate(Vector3.down * dropDistance);
                speed += 0.05f;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPosition.x)
            {
                movingRight = true;
                transform.Translate(Vector3.down * dropDistance);
                speed += 0.05f;
            }
        }

    }
}
