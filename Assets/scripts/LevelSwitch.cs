using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitch : MonoBehaviour
{
    public Image BG;
    public Button nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        BG.enabled = false;
        nextLevel.enabled = false;
        nextLevel.image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //test commit edit changes lol
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BG.enabled = true;
            nextLevel.enabled = true;
            nextLevel.image.enabled = true;
        }
    }

    public void nextLevelChange()
    {
        if(nextLevel.enabled) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
    }
}
