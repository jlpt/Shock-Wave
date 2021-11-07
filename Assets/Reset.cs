using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
   
    
     public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testawdawdawd");
        player.transform.position = new Vector3(-5.82f,1.85f,3.02089f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
