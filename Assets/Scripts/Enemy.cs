using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    public Collider playerCollider { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = playerCollider.bounds.center - rb.position;

        bool isSeenPlayer = true;
        if (Physics.Raycast(rb.position, direction.normalized,
            out var hitInfo))
        {
            if (hitInfo.collider != playerCollider)
            {
                // プレイヤー以外の障害物に当たった場合は見えない1
                isSeenPlayer = false;
            }
        }
    }
}
