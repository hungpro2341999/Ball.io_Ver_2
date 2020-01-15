using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlowPlayer : MonoBehaviour
{
    public Vector3 pos;
   public Player player;
    public float offset = 5;
    public float Speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        GamePlayerCtrl.Instance.Event_Over_Game += Reset;
    }
    public void Reset()
    {
        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        player = GamePlayerCtrl.Instance.Main_Player;
        if (player != null)
        {
            if (player.GetComponent<Enemy>().isGround)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - offset), Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
            }
        }
          
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
        }
      
    }
  
}
