using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int speed = 4;

    PlayerController playerController;

    Animator animator;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.5f)
        {


            this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);



        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("çarpışma: " + other.tag);
        if (other.tag == "Player")
        {
            //TODO: playerın canını bir eksilt
            //PlayerController playerController = other.transform.GetComponent<PlayerController>();
            if(playerController != null)
            {
               playerController.Damage(); 
            }

            //patlama animasyonunu göster
            animator.SetTrigger("OnEnemyDeath");
            //hızı sıfırla 
            speed = 0;
            
            //kendini yok et 
            Destroy(this.gameObject, 2.3f);
        }
        else if(other.tag == "Laser")

        {
            //çarpıştığı lazeri yok et 
            Destroy(other.gameObject);
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
           
           //puanı arttır
            if (playerController!= null)
            {
                playerController.AddScore(10);
            }

            //patlama asnimasyonunu göster
            animator.SetTrigger("OnEnemyDeath");
            // hızı sıfırla
            speed = 0;
            // kendini yok et 
            Destroy(this.gameObject, 2.3f);
        }
    }
   
}
