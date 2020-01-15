using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Screen : MonoBehaviour
{
    public GameObject Flag;
    public Transform Parent;
    public List<GameObject> list = new List<GameObject>();
    public List<Process_Player> list_Process = new List<Process_Player>();
    
    public int numberPlayer;
    public List<int> Loaded;
    public float WaitTime = 2;
    public bool isComplete = false;
    // Start is called before the first frame update
    private void Awake()
    {
        GamePlayerCtrl.Instance.Event_Over_Game += GameOver;
    }
    void Start()
    {
      
    }
   
    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
     for(int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<LoadInfor>().Destroy();
        }
        Loaded = new List<int>();
        list = new List<GameObject>();
        list_Process = new List<Process_Player>();
        isComplete = false;
        
    }
    public void StartProcess()
    {

        for (int i = 0; i < numberPlayer; i++)
        {
            var a = Instantiate(Flag, Parent);
            list.Add(a);

        }
        for (int i = 0; i < list.Count; i++)
        {
            bool isLoaded = false;
            while (!isLoaded)
            {
           
                int index = Random.Range(0, numberPlayer);
                Debug.Log("INDEX : " + index);
                if (Loaded.Contains(index))
                {
                    continue;
                }
                else
                {
                    isLoaded = true;
                    Loaded.Add(index);
                    if(i == numberPlayer - 1)
                    {
                        StartCoroutine(Process_Loading(index, list[index], Random.Range(0, WaitTime),true));
                    }
                    else
                    {
                        StartCoroutine(Process_Loading(index, list[index], Random.Range(0, WaitTime),false));
                    }
                  
                }
                   
            }
          



        }
    }

    public IEnumerator Process_Loading(int index,GameObject game,float wait_time,bool isComplete)
    {
        Debug.Log("INDEX : "+index);
        Process_Player process = DataMananger.Instance.Set_Random_Infor();
        Debug.Log(process.name);
        list_Process.Add(process);
       
     yield return new WaitForSeconds(wait_time);
        game.GetComponent<LoadInfor>().SetImage(process.sprite);
        if (isComplete)
        {
            DataMananger.Instance.Push_Data(list_Process);
            DataMananger.Instance.CountPlayer = numberPlayer;
            yield return new WaitForSeconds(WaitTime*1.5f);
            GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Play);
            
            Debug.Log("Start_Game");

        }
    }
  
  
}
