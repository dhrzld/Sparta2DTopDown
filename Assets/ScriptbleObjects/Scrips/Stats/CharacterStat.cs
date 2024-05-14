using UnityEngine;

public enum StatsChamgeType
{
     Add,  //0
     muitiple, //1
     Override //2
}

// 데이터 폴더처럼 사용할수 있게 만들어주는 Attribute
[System.Serializable]
public class CharacterStat
{
    public StatsChamgeType statChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}