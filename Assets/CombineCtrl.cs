using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum ����: CombineCtrl Ŭ���� �ܺο� ��ġ
public enum ObjectLevel
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
    Level7
}

public class CombineCtrl : MonoBehaviour
{
    public ObjectLevel level; // Enum ���
    public GameObject[] levelPrefabs; // ������ ������ �迭
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public bool isMerge;
    public GameObject effect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            CombineCtrl other = collision.gameObject.GetComponent<CombineCtrl>();
            if (level == other.level && !isMerge && !other.isMerge && level < ObjectLevel.Level7)
            {
                float meX = transform.position.x;
                float meY = transform.position.y;
                float otherX = other.transform.position.x;
                float otherY = other.transform.position.y;

                if (meY < otherY || (meY == otherY && meX > otherX))
                {
                    other.Hide(transform.position);
                    LevelUp();
                }
            }
        }
    }

    public void Hide(Vector3 targetPos)
    {
        isMerge = true;
        rb.simulated = false;
        circleCollider.enabled = false;
        StartCoroutine(HideRoutine(targetPos));
    }

    IEnumerator HideRoutine(Vector3 targetPos)
    {
        yield return null;
        isMerge = false;
        Destroy(gameObject);
    }

    void LevelUp()
    {
        isMerge = true;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        StartCoroutine(LevelUpRoutine());
    }

    IEnumerator LevelUpRoutine()
    {
        yield return new WaitForSeconds(0.001f);
        level++;

        // ���� ������Ʈ�� ���ο� ���������� ����
        if (level <= ObjectLevel.Level7)
        {
            var effect1 =Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effect1, 0.3f);
            int scoreToAdd = ((int)level + 1) * 100; // Calculate score to add
            GameManager.Instance.AddScore(scoreToAdd); // Update score in GameManager

            GameObject newObject = Instantiate(levelPrefabs[(int)level], transform.position, Quaternion.identity);
            newObject.GetComponent<DragAndDrop>().enabled = false;
            
            Destroy(gameObject);
        }

        isMerge = false;
    }
}
