﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Mananger : MonoBehaviour
{
    public static int Stuff_Choice=-1;
    public static Shop_Mananger Instance = null;
    public GameObject Skill;
    public Transform parent;
    public static string Cost ="";
    public Text Text_Cost;
    public  List<GameObject> listSkill;
    public Transform Parent_Review;
    public static Transform Review;
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
        Shop_Mananger.Review = Parent_Review;
        Load_Shop();
    }

    // Update is called once per frame
    void Update()
    {
        Text_Cost.text = Shop_Mananger.Cost;
    }
    public void Load_Shop()
    {
        int count = DataMananger.Instance.Data_Skills.ListModel.Count;
        Debug.Log("LOAD : " + count);
        for(int i = 0; i < count; i++)
        {
           var a = Instantiate(Skill, parent);
            a.GetComponent<InforSkill>().infor  = DataMananger.Instance.Data_Skills.List_infor_Skill[i];
            a.GetComponent<InforSkill>().Load_Infor();
            listSkill.Add(a);
        }
    }
    public void SetCode(string cost)
    {
        Shop_Mananger.Cost = cost;
    }
    public static  void Choice(int id)
    {
     
        Stuff_Choice = id;
      for(int i = 0; i < Shop_Mananger.Instance.listSkill.Count; i++)
        {
            if (Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.id == id)
            {

                Debug.Log("CHILD :: " +Shop_Mananger.Review.childCount);
                if (Shop_Mananger.Review.childCount >= 1)
                {
                    Shop_Mananger.Review.GetChild(0).GetComponent<Destroy_Review>().Destroy();
                }

                Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().Choice();
                var a =    Instantiate(DataMananger.Instance.Data_Skills.ListModel[i],Shop_Mananger.Review);

                a.transform.localPosition = Vector3.zero;
                a.transform.localScale = Vector3.one;
                a.AddComponent<Destroy_Review>();
            }
            else
            {
                Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().Un_Choice();
            }

        }
    }
    public void Buy()
    {
        if (Text_Cost.text!="BUYED")
        {
         

            if (Stuff_Choice != -1)
            {
                    for (int i = 0; i < listSkill.Count; i++)
                {
                    InforSkill infor =  Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>();
                    if (Stuff_Choice == infor.infor.id)
                    {
                        if (!infor.infor.isBuy)
                        {
                            if (infor.infor.Cost <= DataMananger.Instance.Get_Coin_Current())
                            {
                               
                                DataMananger.Instance.Earn_Coin(infor.infor.Cost);
                                infor.infor.isBuy = true;
                                SetCode("Buy");
                                Load_Infor();

                            }

                        }
                    }
                   
                }                
            }
        }
        else
        {

        }
     
    }
    public void Load_Infor()
    {
        List<Infor_Skill> lists = new List<Infor_Skill>();
        
        for(int i=0;i< Shop_Mananger.Instance.listSkill.Count; i++)
        {
            Infor_Skill infor = new Infor_Skill(i, Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.isBuy,
                Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.isUse, DataMananger.Instance.Data_Skills.Cost[i]);

            lists.Add(infor);


        }
        DataMananger.Instance.Save_Shop(lists);
        DataMananger.Instance.Render();
       
        
    }
}
