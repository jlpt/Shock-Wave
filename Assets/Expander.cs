using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    public GameObject shockwave;
    public float scale;
    public float oldScale;
    public float holdTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        scale = shockwave.transform.localScale.x*5;
        oldScale = scale;

        if (scale > 1.5f/2){
            scale = 1.5f/2;
            oldScale = scale;
        }
        if (shockwave.name != "Shockwave"){
    StartCoroutine(wait());
        }
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator wait(){
        float percent;
        while (scale < 5*oldScale){
            percent = oldScale/scale;
           yield return new WaitForSeconds(.01f*(0.5f*2));
            scale = scale + 1.0f/6.0f;
            shockwave.transform.localScale = new Vector3(scale,scale,scale);
            GetComponent<SpriteRenderer>().color = new Color (1,1,1,percent);
        }
        Destroy(shockwave);
        
    }
}
