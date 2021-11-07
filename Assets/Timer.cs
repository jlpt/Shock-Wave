using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
     public Text txt;
     public int time;
     public GameObject player;
     public GameObject particle;
     public GameObject button;
     public Vector3 oldPos;
     public Vector3 oldText;
    
    // Start is called before the first frame update
    void Start()
    {
        oldPos = player.transform.position;
        oldText = txt.transform.position;
        
        StartCoroutine(wait());
        
     
        
    }

    public void resetTimer(){
       
        time = 60;
        txt.text = "1:00";
        player.transform.position = oldPos;
        txt.transform.position = oldText;
         StartCoroutine(wait());
       // rigidbody.velocity = new Vector3(0f,0f,0f);
        button.SetActive(false);
        
      
    }

     IEnumerator wait(){
     while (time >= 1){
          if (time >= 60){
              txt.text = "1:00";
          }
          else if (time < 60 && time >= 10){
              txt.text = "0:"+time.ToString();
          }
          else if (time < 10){
              txt.text = "0:0"+time.ToString();
          }
           yield return new WaitForSeconds(1);
           time--;
           

        }
        txt.text = "Time's up!";
        GameObject particleClone = Instantiate(particle);
        particleClone.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z);
        player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y+500,player.transform.position.z);
        button.SetActive(true);
        txt.transform.position = new Vector3(500,100,0);
        StopCoroutine(wait());
        
     }
       
    
    
     
}
