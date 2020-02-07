using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlowPlayer : MonoBehaviour
{
    public static MoveFlowPlayer Instance = null;
    public Vector3 pos;
    public Player player;
    public float offset = 5;
    public float Speed = 2;
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
        pos = new Vector3(0.15f,25,-5);
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
                Camera.main.fieldOfView = 25;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
                Camera.main.fieldOfView = 80;
            }
        }
          
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Speed * Time.deltaTime);
            Camera.main.fieldOfView = 80;
        }
      
    }
  
}
