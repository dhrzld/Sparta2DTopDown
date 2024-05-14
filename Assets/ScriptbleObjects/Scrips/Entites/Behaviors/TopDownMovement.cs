using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatHandler characterStatHandler;

    private Vector2 movementDiretion = Vector2.zero;

    private void Awake()
    {
        // Awake는 주로 내 컴포넌트 안에서 끝나는것

        // controller랑 TopdownMovement랑 같은 게임 오브젝트 안에 있다라고 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>();

    }
    public void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 diretion)
    {
        movementDiretion = diretion;
    }

    private void FixedUpdate()
    {
        //FixedUpdate는 물리 업데이트 관련
        //Rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDiretion);
    }
    private void ApplyMovement(Vector2 diretion)
    {
        diretion = diretion * characterStatHandler.CurrentStat.speed;
        movementRigidbody.velocity = diretion;
    }
}