using UnityEngine;

public class LaserMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Ekrandan çıktığında yok et
        if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }
}
