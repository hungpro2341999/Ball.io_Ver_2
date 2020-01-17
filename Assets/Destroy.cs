using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public TextAlignment text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start_Destroy(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Start_Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
