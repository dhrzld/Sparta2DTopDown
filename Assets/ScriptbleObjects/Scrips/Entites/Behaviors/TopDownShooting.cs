using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    void Start()
    {
        controller.OnAttackEvent += OnShoot;

        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        if (rangedAttackSO == null) return;

        float projectilAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfprojectilesPerShot =rangedAttackSO.number0fProjectilesPerShot;

        float minAngle = -(numberOfprojectilesPerShot / 2f) * projectilAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;
        for (int i = 0; i < numberOfprojectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilAngleSpace;
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackSO, angle);
        }
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        Debug.Log("Fire");
        GameObject obj = Instantiate(testPrefab);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController > ();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);
    }
    
    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}