using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClick : MonoBehaviour
{

    public GameObject shockwave;

    private float holdDownStartTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            holdDownStartTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            {
                GameObject shockwaveClone = Instantiate(shockwave);
                if (holdDownTime > 1.5f){
                    holdDownTime = 1.5f;
                }
                shockwaveClone.transform.localScale = new Vector3(holdDownTime/2,holdDownTime/2,holdDownTime/2);
                shockwaveClone.transform.position = new Vector3(mousePos.x,mousePos.y,30);
                
            }
        }
    }
}
