using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]

    float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.8f)
        {


            Destroy(this.gameObject);



        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //üçlü atış bonusunu aktifleştir

            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.TripleShotActive();
            }

            // bonus nesnesini yok et 
            Destroy(this.gameObject);
        }
    }
}
