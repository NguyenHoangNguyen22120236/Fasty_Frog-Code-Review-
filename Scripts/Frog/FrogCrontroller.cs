using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogCrontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    static public bool isOnLeaf = false; // Cờ để kiểm tra nếu con ếch đang trên chiếc lá
    static public Transform currentLeaf; // Biến để lưu trữ chiếc lá hiện tại

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isOnLeaf && currentLeaf != null)
        {
            // Di chuyển con ếch theo chiếc lá
            Vector3 newPosition = transform.position;
            newPosition.x = currentLeaf.position.x;
            rb.MovePosition(newPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf"))
        {
            // Khi con ếch chạm vào chiếc lá
            isOnLeaf = true;
            currentLeaf = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf"))
        {
            // Khi con ếch rời khỏi chiếc lá
            isOnLeaf = false;
            currentLeaf = null;
        }
    }
}
