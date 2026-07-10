using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] speedMax;
    PlayerInput playerInput;
    [SerializeField] float groundNormalYMin = 0.7f;
    bool isGrounded;
    [SerializeField] float groundDamping = 8f;
    [SerializeField] float airDamping = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb.sleepThreshold = -1;
    }

    // Update is called once per frame
    void Update()
    {
        var cameraDir = playerInput.camera.transform.forward;
        var cameraRight = playerInput.camera.transform.right;

        var moveVec3D =
            cameraDir.y = 0;
        cameraDir = cameraDir.normalized;

        if (playerInput.actions["Jump"].WasPressedThisFrame()
          && isGrounded)
        {
            Vector3 jumpVec = new Vector3(0, jumpSpeed, 0);
            rb.AddForce(jumpVec, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        // 減衰を地上と空中で変える
        if (isGrounded)
        {
            rb.linearDamping = groundDamping;
        }
        else
        {
            rb.linearDamping = airDamping;
        }

        // 物理計算中に接地判定を行うため、一旦ここで false にしておく
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y >= groundNormalYMin)
            {
                isGrounded = true;
            }
        }
    }
}
