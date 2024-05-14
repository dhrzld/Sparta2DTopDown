using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    //�⺻���� �߰������� ����ؼ� ���� ������ ����ϴ� ������ �ִ�
    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }

    public List<CharacterStat> statsModiFiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        // ������ �⺻�ɷ�ġ�� ���� �����δ� �ɷ�ġ�� ��ȭ����� ����
        CurrentStat.statChangeType = baseStat.statChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed =baseStat.speed;
    }
}