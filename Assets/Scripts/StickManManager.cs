using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class StickManManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem blood;
    private Animator StickManAnimator;
    private void Start()
    {
        StickManAnimator = GetComponent<Animator>();
        StickManAnimator.SetBool("run",true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red") && other.transform.parent.childCount > 0)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }

        switch (other.tag)
        {
            case "red":
                if (other.transform.parent.childCount > 0)
                {
                    if(other.gameObject.tag == "blue") {
                        Destroy(other.gameObject);
                        Destroy(gameObject);
                    }
                    
                }

                break;

            case "jump":

                //transform.DOJump(transform.position, 1f, 1, 1f).SetEase(Ease.Flash).OnComplete(PlayerManager.PlayerManagerInstance.FormatStickMan);

                break;
            case "obstacle":

                if (other.transform.parent.childCount > 0)
                {
                    Destroy(gameObject);
                    Instantiate(blood, transform.position, Quaternion.identity);
                }
                if (GameController.Instance.IsDied()) { UI_Controller.OnDefeat?.Invoke(); }
                break;
               
        }
        
      
        
    }
}

