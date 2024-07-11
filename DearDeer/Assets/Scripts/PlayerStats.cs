using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 스탯타입 열거체로 정의
public enum StatType
{
    SANITY,
    SELF_DESTRUCTION,
    AGGRESSIVE,
    OBEYING
}

public class PlayerStats : MonoBehaviour
{
    // 각 스탯에 대한 프로퍼티 (읽기 전용, 내부에서만 설정 가능)
    public int Sanity { get; private set; }
    public int SelfDestruction { get; private set; }
    public int Aggressive { get; private set; }
    public int Obeying { get; private set; }

    public void ChangeStats(StatType statType, int amount)
    {
        // statType에 따라 해당 스탯을 amount만큼 변경
        switch (statType)
        {
            case StatType.SANITY:
                Sanity += amount;
                break;
            case StatType.SELF_DESTRUCTION:
                SelfDestruction += amount;
                break;
            case StatType.AGGRESSIVE:
                Aggressive += amount;
                break;
            case StatType.OBEYING:
                Obeying += amount;
                break;
        }
    }
}
