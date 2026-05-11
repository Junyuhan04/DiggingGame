using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [Header("Move Setting")]
    public float dragSpeed = 0.01f;

    [Header("Dig System")]
    public DigSystem digSystem;

    private Vector2 lastMousePos;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        DragMove();
    }

    void DragMove()
    {
        // 마우스 없으면 종료
        if (Mouse.current == null)
            return;

        // 좌클릭 시작
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            lastMousePos = Mouse.current.position.ReadValue();
        }

        // 좌클릭 드래그 중
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 currentMousePos = Mouse.current.position.ReadValue();

            Vector2 delta = currentMousePos - lastMousePos;

            // 마우스 위로 → 카메라 아래로
            cam.transform.position -= new Vector3(0, delta.y * dragSpeed, 0);

            // 카메라 제한
            Vector3 pos = cam.transform.position;

            // 위 제한
            pos.y = Mathf.Min(pos.y, 0);

            // 아래 제한
            float minY = -(digSystem.currentDepth * 4);

            pos.y = Mathf.Max(pos.y, minY);

            cam.transform.position = pos;

            lastMousePos = currentMousePos;
        }
    }
}