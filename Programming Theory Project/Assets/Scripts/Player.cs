using UnityEditor;
using UnityEngine;

public class Player : Ship
{
    private float MaxMovement = 6;
    
    private void Start()
    {
        speed = 15;
    }

    public override void Update()
    {
        base.Update();
        Fire();
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

    public override void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proj = Instantiate(projectile,transform.position,Quaternion.identity);
            proj.GetComponent<Projectile>().ami = true;
        }
    }

    public override void Death(GameObject proj)
    {
        if (!proj.GetComponent<Projectile>().ami && gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(proj);
        }
    }
}
