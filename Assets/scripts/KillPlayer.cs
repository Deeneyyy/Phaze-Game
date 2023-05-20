using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;
using EZCameraShake;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource DeathSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            TopDownMovement.instance.animator.SetTrigger("Death");
            TopDownMovement.instance.isGameOver = true;
            StartCoroutine(Restart());
            //JumpFeedback.PlayFeedbacks();
            //StartCoroutine(CameraFollow.instance.Shake(0.2f,1f));
            CameraShaker.Instance.ShakeOnce(2f, 4f, .1f, 1f);

            DeathSoundEffect.Play();

        }

     

    }
    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
