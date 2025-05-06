using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f;
    public bool ami;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
