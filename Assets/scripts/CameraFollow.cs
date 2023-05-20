using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using EZCameraShake;

public class CameraFollow : MonoBehaviour
{  
    
    //targetting the player

    public GameObject target;
    public Vector3 offset;
    public float damping;

    public float rightJam;
    public float leftJam;
    public float upJam;
    public float downJam;

    private Vector3 velocity = Vector3.zero;
    public static CameraFollow instance;

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }
    private void Start()
    {
        offset = transform.position - target.transform.position;
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Vector3 movePosition = target.transform.position + offset;
        //transform.position = Vector3.SmoothDamp(transform.position, movePosition,ref velocity, damping);
        CameraShaker.Instance.RestPositionOffset = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        if (CameraShaker.Instance.RestPositionOffset.x>rightJam)
                {
            CameraShaker.Instance.RestPositionOffset = new Vector3(rightJam, CameraShaker.Instance.RestPositionOffset.y, CameraShaker.Instance.RestPositionOffset.z);
        }
        else if(CameraShaker.Instance.RestPositionOffset.x < leftJam)
        {
            CameraShaker.Instance.RestPositionOffset = new Vector3(leftJam, CameraShaker.Instance.RestPositionOffset.y, CameraShaker.Instance.RestPositionOffset.z);
        }
        if (CameraShaker.Instance.RestPositionOffset.y > upJam)
        {
            CameraShaker.Instance.RestPositionOffset = new Vector3(CameraShaker.Instance.RestPositionOffset.x, upJam, CameraShaker.Instance.RestPositionOffset.z);
        }
        else if (CameraShaker.Instance.RestPositionOffset.y < downJam)
        {
            CameraShaker.Instance.RestPositionOffset = new Vector3(CameraShaker.Instance.RestPositionOffset.x, downJam, CameraShaker.Instance.RestPositionOffset.z);
        }
    }

    /*public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            this.transform.localPosition = new Vector3(target.transform.position.x*x, target.transform.position.y*y, -10f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos; 
    }*/
}



