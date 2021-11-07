using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Rendering.PostProcessing;
public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text txt;
    public float score;
    public GameObject particle;
    private Rigidbody2D rb;
    public TrailRenderer trail;
    public float higherVel;
   // public ChromaticAberration chromaticAberrationLayer = null;
    //public float test = 5f;
    void Start()
    {
     //    PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
       // volume.profile.TryGetSettings(out chromaticAberrationLayer);
     rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
      Vector2 v2 = rb.velocity;
      if (Mathf.Abs(v2[0]) > Mathf.Abs(v2[1])){
          higherVel = Mathf.Abs(v2[0]);
      }
      else{
          higherVel = Mathf.Abs(v2[1]);
      }
     //ChromaticAberration chromSettings = post.ChromaticAberration.settings;
      if (Mathf.Abs(v2[0]) > 15.0f || Mathf.Abs(v2[1]) > 15.0f) {
            trail.emitting = true;
          //  chromaticAberrationLayer.intensity.value = test;
            //chromSettings.intensity = 1;
      }
    
      else{
        trail.emitting = false;
      }
      
        
    }
    public void resetScore(){
        score = 0;
        txt.text = "Score: "+score.ToString();
    }
    void OnCollisionEnter2D(Collision2D coll)
{
    Debug.Log(coll.gameObject.name);
    GameObject particleClone = Instantiate(particle);
    particleClone.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z);
    particleClone.GetComponent<ParticleSystem>().startColor = coll.gameObject.GetComponent<SpriteRenderer>().color;
    if (coll.gameObject.name == "BigPoint")
   {    
        score = score + 10*higherVel;
        
        txt.text = "Score: "+Mathf.Floor(score).ToString();
   }

   if (coll.gameObject.name == "SidePoint"){
       score += 2*higherVel;
       txt.text = "Score: "+Mathf.Floor(score).ToString();
   }

    if (coll.transform.parent.gameObject.name == "Spikes"){
            score -= 1*higherVel;
      
          txt.text = "Score: "+Mathf.Floor(score).ToString();
    }

    if (coll.transform.parent.gameObject.name == "BigSpikes"){
            score = score - 10*higherVel;
      
          txt.text = "Score: "+Mathf.Floor(score).ToString();
    }

}
}
