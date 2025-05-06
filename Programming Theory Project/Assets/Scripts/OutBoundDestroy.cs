using UnityEngine;

public class OutBoundDestroy : MonoBehaviour
{
    private float limitY = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= limitY ||  transform.position.y <= -limitY)
        {
            Destroy(gameObject);
        }
    }
}
