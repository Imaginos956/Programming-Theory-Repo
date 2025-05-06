using UnityEngine;

public class Ship : MonoBehaviour
{
    protected float m_speed;
    protected int m_life;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed
    {  get { return m_speed; } set { m_speed = value; } }

    public int life
    {  get { return m_life; } set { m_life = value; } }

    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {

    }

    public virtual void Fire()
    { 
    
    }

    public virtual void Death()
    {

    }
}
