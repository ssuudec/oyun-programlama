using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        
        public float speed = 10f;
    
       [SerializeField]
       float speedMultiplier =2; 

    [SerializeField]  GameObject laserPrefab; // Laser prefab
    [SerializeField] float fireRate = 0.25f; // Seri atış aralığı

    [SerializeField] bool isTripleShotActive = false;
    [SerializeField] bool isSpeedBonusActive = false;
    
    [SerializeField] bool isShieldBonusActive = false;
    [SerializeField]  GameObject shieldVisualizer; 

    [SerializeField]  GameObject tripleLaserPrefab;





    private float nextFire = 0f;
    [SerializeField]
    private int lives = 3;

   

    


    void Update()
    {
        MovePlayer();

        // Space basılı tutulursa seri atış
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireLaser();
        }
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);

        // Ekran sınırları
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -11.7f, 11.7f),
            Mathf.Clamp(transform.position.y, -3.8f, 0),
            0
        );
    }

    void FireLaser()
    {
        if (!isTripleShotActive)
        {
            Instantiate(laserPrefab, (this.transform.position + new Vector3(0, 1.05f, 0)), Quaternion.identity);
        }
        else
        {
            Instantiate(tripleLaserPrefab, (this.transform.position), Quaternion.identity);
        }
    }

    public void Damage()
    {
        //koruma kalkanı aktifse canı azalmasın ama koruma kalkanı pasif duruma dönsün
        if (isShieldBonusActive)
        {
            isShieldBonusActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }

        //koruma kalkanı aktif değilse canı bir azaltır 

        lives--;

        if (lives == 0)
        {
            SpawnManager spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

            if (spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();

            }
            else
            {
                Debug.LogError("PlayerController:: Damage spawnManager_sc is NULL");
            }

            Destroy(this.gameObject);


        }
    }
    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCancelRoutine());
    }

    public void SpeedBonusActive()
    {
        isSpeedBonusActive= true;
        speed*= speedMultiplier;
        StartCoroutine(SpeedBonusCancelRoutine());
    }

    public void ShieldBonusActive()
    {
        isShieldBonusActive = true;
        shieldVisualizer.SetActive(true);
        
    }



    IEnumerator TripleShotCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBonusActive = false;
        speed/= speedMultiplier;
    }

  
    

}

