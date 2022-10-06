using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBG : MonoBehaviour
{
    private static DontDestroyBG instance = null;

    public static DontDestroyBG Instance
    {
        get { return instance; }
    }

    private void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

}   

