using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : TopDownController
{
    private Camera Camera;

    protected override void Awake()
    {
        base.Awake();
        Camera = Camera.main; //메인카메라에 태그가 붙어있는 카메라를 가저온다
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        //실제 움직이는 여기서 하는것이 아니라 PlayerMovement에서 한다
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = Camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }
}
