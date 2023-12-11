using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    #region Properties
    public string ItemName { get; }
    public string AbilityName { get; }
    public int AbilityValue { get; }
    public string ItemInfo { get; }
    public int Gold { get; }
    public bool IsEquipped { get; private set; } // �������� �����Ǿ������� ��Ÿ���� �Ӽ�

    #endregion

    public Items(string itemname, string abilityname, int abilityvalue, string iteminfo, int gold)
    {
        ItemName = itemname;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
        Gold = gold;
        IsEquipped = false; // ������ �ʱ� ���·� �������� �ʾ����� ��Ÿ��
    }
}
