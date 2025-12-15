using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]

    float speed = 3;
    
    [SerializeField]
    int bonusId;

    [SerializeField]
    
    AudioClip audioClip;
    
   
  

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
            

            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            if(playerController != null)
            {
                //bonus yakalandığında ses çal
                AudioSource.PlayClipAtPoint(audioClip , this.transform.position , volume: 0.85f);

                switch (bonusId)
                {
                    //0 üçlü atış bonusunu temsil eder
                    case 0:
                          playerController.TripleShotActive();
                          break;
                    //1 hız bonusunu temsil eder      
                    case 1:
                          playerController.SpeedBonusActive();
                          Debug.Log("hız bonusu aktif");
                          break;
                    //2 kalakn bonusunu temsil eder      
                    case 2: 
                          playerController.ShieldBonusActive();
                          Debug.Log("kalakn bonusu aktif");
                          break;   
                    // yalnızca 3 tane tanımladık bunların dışı hata durumu
                    default: 
                          Debug.Log("hata");
                          break;     
                                
                }
                //TODO if ......(yakalanan triple shot bonusu ise)
                
                //TODO else if ....( yakalanan hız bonusu ise)
                Debug.Log("hız bonusu aktif");
                //TODO else if ...( yakalanan kalkan bonsuu ise)
                Debug.Log("kalkan bonusu aktif");
            }

            // bonus nesnesini yok et 
            Destroy(this.gameObject);
        }
    }
}
