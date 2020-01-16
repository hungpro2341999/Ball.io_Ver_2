using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Screen_Game {Screen_Start,Screen_Play,Screen_Loading};

public class GameMangaer : MonoBehaviour
{
    public List<Mutiply_Screen> mutiply_Screens;
    public static GameMangaer Instance = null; 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Open_Screen(Screen_Type.Screen_Start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenScreen(Mutiply_Screen screen)
    {
                Open_Screen(screen.Type_Screen);
            
    }


    public void CloseScreen(Mutiply_Screen screen)
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == screen.Type_Screen)
            {
                s.Close_Screen();
            }

        }
    }
    public void Open(Screen_Type screen)
    {
        foreach(Mutiply_Screen w in mutiply_Screens)
        {
            if(w.Type_Screen == screen)
            {
                w.Open_Screen();
                
            }
        }
    }

    public void Close(Screen_Type screen)
    {
        foreach (Mutiply_Screen w in mutiply_Screens)
        {
            if (w.Type_Screen == screen)
            {
                w.Close_Screen();
            }
        }
    }
    public Mutiply_Screen GetScreen(Screen_Type screen)
    {
        foreach(Mutiply_Screen s in mutiply_Screens)
        {
            if(s.Type_Screen == screen)
            {
                return s; 
            }
        }
        return null;
    } 

    public void Open_Screen(Screen_Type screen)
    {   
        switch (screen)
        {
            case Screen_Type.Screen_Play:
                Debug.Log("STARTTTTTT");
                Close(Screen_Type.Screen_loading);
                GamePlayerCtrl.Instance.Event_Reset_Game();
                Close(Screen_Type.Screen_Start);
                Open(Screen_Type.Screen_Play);
                break;

            case Screen_Type.Screen_loading:

                Open(Screen_Type.Screen_loading);
                Close(Screen_Type.Screen_Start);
                GetScreen(Screen_Type.Screen_loading).GetComponent<Loading_Screen>().StartProcess();
                break;

            case Screen_Type.Screen_Start:
                Open(Screen_Type.Screen_Start);
                Open(Screen_Type.Screen_Play);
                Close(Screen_Type.Screen_loading);
                break;
        }


    }
    public void Close_Screen(Screen_Type screen)
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == screen)
            {
                s.Close_Screen();
            }

        }
    }



    
    
    
    public void Start_Game_Window()
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == Screen_Type.Screen_Start || s.Type_Screen == Screen_Type.Screen_Play)
            {
                s.Open_Screen();
            }
            else
            {
                s.Close_Screen();
            }
        }
    }

    public void Open_Loading_Screen()
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == Screen_Type.Screen_loading)
            {
                s.Open_Screen();
                Debug.Log(s.gameObject.name);
            }
           
        }
    }
    public void Close_Loading_Screen()
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == Screen_Type.Screen_loading)
            {
                s.Close_Screen();
            }
            else
            {
              
            }
        }
    }


    public IEnumerator OpenLoading(Mutiply_Screen screen,float wait_Time)
    {

        Open_Loading_Screen();
        yield return new WaitForSeconds(wait_Time);
        CloseAll(screen.Type_Screen);
        
    }
    public  void CloseAll(Screen_Type screen)
    {
        foreach (Mutiply_Screen s in mutiply_Screens)
        {
            if (s.Type_Screen == screen)
            {
                s.Open_Screen();
            }
            else
            {
                s.Close_Screen();
            }
        }
    }
    public void Open_Ads_Reward() 
    {
       // ManagerAds.Ins.ShowRewardedVideo();
    }
    public void Open_Ads_Full() 
    {
        ManagerAds.Ins.ShowInterstitial();
    }
   
}
