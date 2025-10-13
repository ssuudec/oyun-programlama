using UnityEngine;

public class Cube_move : MonoBehaviour
{
    public float speed = 5f; 
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical");   

        
        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;
    }
}