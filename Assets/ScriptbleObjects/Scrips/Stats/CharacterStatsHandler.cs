using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    //기본스텟 추가스텟을 계산해서 최종 스텟을 계산하는 로직이 있다
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
        // 지금은 기본능력치만 적용 앞으로느 능력치가 강화기능이 생김
        CurrentStat.statChangeType = baseStat.statChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed =baseStat.speed;
    }
}