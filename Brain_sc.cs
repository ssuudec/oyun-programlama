using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Brain_sc : MonoBehaviour
{

    int DNALength = 1;
    public float timeAlive = 0;
    public DNA_sc dna_sc;
    
    ThirdPersonCharacter character;
    bool isAlive= true;

    Vector3 mVector;
    bool isJumping;
    Vector3 startPos;  
    public float distanceTravelled;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //read dna 
        float h = 0;
        float v = 0;
        bool crouch = false;
        if(dna_sc.GetGene(0) ==0) v = 1;
        
        else if(dna_sc.GetGene(0) ==1) v =-1;
        
        else if(dna_sc.GetGene(0) ==2) h = -1;
        
        else if(dna_sc.GetGene(0) ==3) h = 1;
        
        else if(dna_sc.GetGene(0) ==4) isJumping = true;
        
        else if(dna_sc.GetGene(0) ==5) crouch = true;
        
        mVector = v*Vector3.forward + h*Vector3.right;
        
        if(isAlive)
        {
            character.Move(mVector, crouch, isJumping);
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance( this.transform.position, startPos);

        }
        isJumping = false;

    }
       
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "dead")
        {
            isAlive = false;
        }
    }
    

    public void Init()
    {
        //initialize DNA
        //0 forward
        //1 back 
        //2 left 
        //3 right
        //4 jump
        //5 crouch
        dna_sc = new DNA_sc(DNALength, 6);
        character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        isAlive = true;
        startPos = this.transform.position;
    }
}
