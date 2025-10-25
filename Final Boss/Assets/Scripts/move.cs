using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedFactor = speed * Time.deltaTime;

        float x = speedFactor * Input.GetAxis("Horizontal"); 
        float y = 0f;
        float z = speedFactor * Input.GetAxis("Vertical");  
        

        transform.Translate(x, y, z);
    }
}
