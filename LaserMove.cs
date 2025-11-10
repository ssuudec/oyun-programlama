using UnityEngine;

public class LaserMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Ekrandan çıktığında yok et
        if (this.transform.position.y > 7)
        {
            if(this.transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
