using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int speed = 4;

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
        if (other.tag == "Player")
        {
            //TODO: playerın canını bir eksilt
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            playerController.Damage();

            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
   
}
