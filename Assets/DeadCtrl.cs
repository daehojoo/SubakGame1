using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeadCtrl : MonoBehaviour
{
    public bool timeGone = false;
    public bool gameOver = false;
    public Rigidbody2D rb;
    public Image Image;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Image = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Image>();
    }
    public void Update()
    {
        if (rb.gravityScale >= 0.5f)
            StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        timeGone = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone") && timeGone)
        { 
            gameOver = true;
            Image.gameObject.SetActive(true);
            
        }
    }








}
