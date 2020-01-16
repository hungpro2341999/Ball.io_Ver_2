using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cricle : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Image_Cricle;
    public float Cool_Time=0.1f;
    public static bool Wait_Over_Game = false;
    public float Amount = 0.05f;
    void Start()
    {
        Image_Cricle.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Wait_Over_Game) 
        {
            
        }
        else 
        {
         
                 Image_Cricle.fillAmount+=Amount;
                if (Image_Cricle.fillAmount > 1)
                {
                    Wait_Over_Game = false;
                    Image_Cricle.fillAmount = 0;
                    GamePlayerCtrl.Instance.Back_To_Game();
                }
         
        }
    }
    public void Start_Game_Over()
    {


    }
}
