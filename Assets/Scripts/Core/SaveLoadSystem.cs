using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public GameObject save1;
    public GameObject save2;
    public GameObject save3;
    public GameObject save4;
    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushBackButton()
    {
        gameObject.transform.gameObject.SetActive(false);
    }

    
}
