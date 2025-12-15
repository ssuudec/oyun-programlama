using Unity.VisualScripting;
using UnityEngine;

public class Asteroid_sc : MonoBehaviour
{
    
    float rotateSpeed = 20.0f;

    [SerializeField]
     
    GameObject explosionPrefab;  

    SpawnManager spawnManager;
    
    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(spawnManager == null)
        {
            Debug.Log("Asteroid_sc:: Start , spawnManager bulunamadı");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Laser")
        {
            GameObject explosion = Instantiate(explosionPrefab , this.transform.position , Quaternion.identity);
            Instantiate(explosionPrefab , this.transform.position , Quaternion.identity);
            Destroy(other.gameObject);
            spawnManager.StartSpawning();
            Destroy(this.gameObject);

        }
    }

}
