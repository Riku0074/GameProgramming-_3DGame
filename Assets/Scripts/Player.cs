using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] speedMax;
    PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        var cameraDir = playerInput.camera.transform.forward;
        var cameraRight = playerInput.camera.transform.right;

        var moveVec3D =
            cameraDir.y = 0;
        cameraDir = cameraDir.normalized;
    }
}
