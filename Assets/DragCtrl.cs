using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    CircleCollider2D collider;
    Rigidbody2D rb;
    public BoxCollider2D boxCollider; // 드래그 가능한 범위를 지정하는 콜라이더

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        boxCollider = GameObject.Find("MouseCtrlZone").GetComponent<BoxCollider2D>();
        collider = GetComponent<CircleCollider2D>();
        canMove = false;
        dragging = false;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치에서 Collider2D가 오버랩하는지 체크
            //if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
                dragging = true; // 드래그 시작
            }
            //else
            //{
            //    canMove = false;
            //}
        }

        if (dragging)
        {
            if (boxCollider != null)
            {
                // BoxCollider의 경계 계산
                Bounds bounds = boxCollider.bounds;

                // 새로운 위치 계산
                float clampedX = Mathf.Clamp(mousePos.x, bounds.min.x, bounds.max.x);
                float clampedY = mousePos.y;

                // Y값이 범위를 벗어나면 제한
                if (mousePos.y < bounds.min.y)
                {
                    clampedY = bounds.min.y;
                }
                else if (mousePos.y > bounds.max.y)
                {
                    clampedY = bounds.max.y;
                }

                this.transform.position = new Vector2(clampedX, clampedY); // 범위 내에서 드래그
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
            rb.gravityScale = 0.5f;
            GameManager.Instance.isObjectThere = false;
            this.GetComponent<DragAndDrop>().enabled = false;
        }
    }
}
