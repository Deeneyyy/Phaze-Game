using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    public GameObject door;
    private bool doorDestroyed;
    public int totalCap;
    void Start()
    {
        
    }

    void Update()
    {
        coinText.text = "Saved:" + coinCount.ToString() + "/"+totalCap.ToString();
        if (coinCount == totalCap && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
