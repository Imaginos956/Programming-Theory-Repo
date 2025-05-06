using UnityEngine;

// INHERITANCE
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

    public override void Update()
    {
        base.Update();
    }

    // POLYMORPHISM
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

    // POLYMORPHISM
    public override void Death(GameObject proj)
    {
        if (proj.GetComponent<Projectile>().ami && gameObject.CompareTag("Enemy"))
        {
            MainManager.Instance.score += 10;
            Destroy(gameObject);
            Destroy(proj);
        }        
    }

    // POLYMORPHISM
    public override void Fire()
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.transform.Rotate(0, 0, 180);
        proj.GetComponent<Projectile>().ami = false;
    }
}
