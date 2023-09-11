using System;
using UnityEngine;

public class UnitychanManager : MonoBehaviour
{
    [SerializeField]
    private UnitychanController controller;
    [SerializeField]
    private new UnitychanAnimation animation;
    [SerializeField]
    private new UnitychanAudio audio;
    [SerializeField]
    private new CameraManager camera;
    [SerializeField]
    private float walkSpeed, runSpeed;
    private float speed;


    private void Update()
    {
        Move();
        Camera();
        Jump();
    }



    private void Move()
    {
        float x = controller.GetMove().x;
        float y = controller.GetMove().y;

        if (Math.Abs(x) < 0.2f && Math.Abs(y) < 0.2f)
        {
            animation.SetIsWalk(false);
            animation.SetIsRun(false);
            return;
        }
        else if (Math.Abs(x) < 0.5f && Math.Abs(y) < 0.5f)
        {
            speed = walkSpeed;
            animation.SetIsWalk(true);
            animation.SetIsRun(false);
        }
        else
        {
            speed = runSpeed;
            animation.SetIsWalk(false);
            animation.SetIsRun(true);
        }
        
        // カメラの向きを考慮し、移動量を計算
        double vector = Math.Sqrt(x * x + y * y);
        double vertical = x / vector;
        double horizontal = y / vector;
        double root = Math.PI * camera.transform.eulerAngles.y / 180f;
        double moveX = vertical * Math.Cos(root) + horizontal * Math.Sin(root);
        double moveY = -vertical * Math.Sin(root) + horizontal * Math.Cos(root);
        moveX = moveX * speed * Time.deltaTime;
        moveY = moveY * speed * Time.deltaTime;
        var translation = new Vector3((float)moveX, 0f, (float)moveY);

        // 移動処理
        transform.position += translation;

        if (translation.magnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(translation);

        camera.PositionTracking(translation);
    }

    private void Camera()
    {
        var point = transform.position;
        point.y = 1f;
        var angle = new Vector3(-controller.GetCamera().x * Time.deltaTime, controller.GetCamera().y * Time.deltaTime, 0f);
        
        // カメラ回転移動
        camera.RotateAround(point, angle);
    }

    private void Jump()
    {
        if (controller.GetJump())
        {
            animation.JumpTrigger();
            audio.PlayJumpVoice();
        }
    }
}
