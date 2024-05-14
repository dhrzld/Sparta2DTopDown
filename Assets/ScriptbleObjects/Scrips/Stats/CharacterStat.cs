using UnityEngine;

public enum StatsChamgeType
{
     Add,  //0
     muitiple, //1
     Override //2
}

// ������ ����ó�� ����Ҽ� �ְ� ������ִ� Attribute
[System.Serializable]
public class CharacterStat
{
    public StatsChamgeType statChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}