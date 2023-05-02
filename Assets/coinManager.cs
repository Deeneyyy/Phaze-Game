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
    void Start()
    {
        
    }

    void Update()
    {
        coinText.text = "Capsules Saved:" + coinCount.ToString() + "/8";
        if (coinCount == 8 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
