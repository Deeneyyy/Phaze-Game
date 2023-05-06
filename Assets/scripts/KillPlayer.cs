using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TopDownMovement.instance.animator.SetTrigger("Death");
            TopDownMovement.instance.isGameOver = true;
            StartCoroutine(Restart());
        }



    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
