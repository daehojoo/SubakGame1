using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    CircleCollider2D collider;
    Rigidbody2D rb;
    public BoxCollider2D boxCollider; // �巡�� ������ ������ �����ϴ� �ݶ��̴�

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
            // ���콺 Ŭ�� ��ġ���� Collider2D�� �������ϴ��� üũ
            //if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
                dragging = true; // �巡�� ����
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
                // BoxCollider�� ��� ���
                Bounds bounds = boxCollider.bounds;

                // ���ο� ��ġ ���
                float clampedX = Mathf.Clamp(mousePos.x, bounds.min.x, bounds.max.x);
                float clampedY = mousePos.y;

                // Y���� ������ ����� ����
                if (mousePos.y < bounds.min.y)
                {
                    clampedY = bounds.min.y;
                }
                else if (mousePos.y > bounds.max.y)
                {
                    clampedY = bounds.max.y;
                }

                this.transform.position = new Vector2(clampedX, clampedY); // ���� ������ �巡��
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
