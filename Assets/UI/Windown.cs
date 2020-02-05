using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windown : MonoBehaviour
{
    
    public Windown_Type type;
    public Animator Anim;
    bool Open_Anim = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    IEnumerator BackToStartScreen()
    {

        yield return new WaitForSeconds(3);
        GamePlayerCtrl.Instance.Event_Over_Game();
        GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Start);
        Close();
        Debug.Log("Back To Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
     
        gameObject.SetActive(true);
        if (Anim != null)
        {
            Open_Anim = !Open_Anim;
            Anim.SetBool("Open", Open_Anim);

            if (type == Windown_Type.Shop)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Open", true);
            }
            if (type == Windown_Type.End_Game)
            {
                StartCoroutine(BackToStartScreen());
            }
            else if (type == Windown_Type.Game_Over)
            {
                Cricle.Wait_Over_Game = true;
            }

        }
        else
        {
            if (type == Windown_Type.Shop)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Open", true);
            }
            if (type == Windown_Type.End_Game)
            {
                StartCoroutine(BackToStartScreen());
            }
            else if (type == Windown_Type.Game_Over)
            {
                Cricle.Wait_Over_Game = true;
            }
        }
       
        
    }
    public void Close()
    {
        gameObject.SetActive(false);
       
    }
}
