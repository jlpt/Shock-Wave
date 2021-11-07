using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;
    void Start()
    {
          StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator wait(){
    
           yield return new WaitForSeconds(1);
           if (particle.gameObject.name != "CollisionParticle" && particle.gameObject.name != "DeathParticle"){
  Destroy(particle);
           }
         
          
     }
       
}
