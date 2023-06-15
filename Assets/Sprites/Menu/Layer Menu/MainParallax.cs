using UnityEngine;

public class MainParallax : MonoBehaviour
{
    public float parallaxSpeed = 0.5f; // Tốc độ parallax, tùy chỉnh theo mong muốn

    private Transform menuContainer;
    private Vector3 previousMousePosition;

    private void Start()
    {
        menuContainer = transform;
        previousMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        Vector3 mouseDelta = Input.mousePosition - previousMousePosition; // Lấy sự thay đổi tọa độ chuột
        Vector3 parallaxAmount = mouseDelta * parallaxSpeed; // Điều chỉnh tốc độ parallax theo hướng của chuột

        menuContainer.position += new Vector3(parallaxAmount.x, parallaxAmount.y, 0f); // Di chuyển theo tọa độ của chuột

        previousMousePosition = Input.mousePosition;
    }
}
