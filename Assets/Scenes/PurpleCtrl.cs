using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCtrl : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        { 
            var abc = collision.gameObject.GetComponent<CombineCtrl>();
            if (abc.level == this.gameObject.GetComponent<CombineCtrl>().level)
            {
                int scoreToAdd = (4 * 100); // Calculate score to add
                GameManager.Instance.AddScore(scoreToAdd); // Update score in GameManager
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        
        }
    }









}
