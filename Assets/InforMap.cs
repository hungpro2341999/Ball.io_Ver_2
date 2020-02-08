using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforMap : MonoBehaviour
{
    
    public float Radius;
    public float Radian;
    public float Ground;
    public Vector3 Vertice;
    public float RateTime;
    float time;
    float timeCurr=0;
    public float offsetLevel;
    int count = 0;
    bool complete = false;
    public GameObject Img_Warring;
    float warringTime;
    int farme = 0;
    // Start is called before the first frame update
    void Start()
    {
      
        timeCurr = 15;
        RateTime = 15;
        warringTime = RateTime*0.35f;

      //  time = RateTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePlayerCtrl.isPlayingGame)
        Setting_Level();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void Setting_Level()
    {

        if (!complete)
        {
            if (timeCurr < 0)
            {
                timeCurr = RateTime;
                Redution_Map(0.1f);
                count++;
                if (count > 7)
                {
                    complete = true;
                }
            }
            else
            {
                
                timeCurr -= Time.deltaTime;
                if (Img_Warring != null)
                {
                    if (timeCurr < warringTime)
                    {
                        if (farme % 10 == 0)
                        {
                            Warring(!Img_Warring.active);
                        }
                       
                        farme++;
                        
                    }
                    else
                    {
                        Warring(false);
                        farme++;
                    }
                  
                }
               
            }
        }
        else
        {
            Warring(false);
        }
       
    }
    public void Redution_Map(float offset)
    {
        transform.localScale -= Vector3.right * offset;
       
        transform.localScale -= Vector3.forward * offset;
    }
   
    public void Warring(bool active)
    {
        Img_Warring.SetActive(active);
    }
}
