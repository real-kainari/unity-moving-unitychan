using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float speed;



    private void Start()
    {
        // カーソルを非表示
        Cursor.visible = false;

        // カーソルを画面中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }



    public void PositionTracking(Vector3 translation)
    {
        transform.position += translation;
    }

    public void RotateAround(Vector3 point, Vector3 angle)
    {
        float angleX = -angle.x * speed;
        float angleY = angle.y * speed;

        if ((transform.position.y < 0.5f && angle.y < 0f) ||
            (transform.position.y > 3.5f && angle.y > 0f))
            angleY = 0f;

        transform.RotateAround(point, Vector3.up, angleX);
        transform.RotateAround(point, transform.right, angleY);
    }
}
