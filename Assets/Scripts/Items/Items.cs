using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    #region Properties
    public string ItemName { get; }
    public string FileName { get; }
    public string AbilityName { get; }
    public int AbilityValue { get; }
    public string ItemInfo { get; }
    public int Gold { get; }
    public bool IsEquipped { get; set; } // �������� �����Ǿ������� ��Ÿ���� �Ӽ�

    #endregion

    public Items(string itemname, string filename, string abilityname, int abilityvalue, string iteminfo, int gold)
    {
        ItemName = itemname;
        FileName = filename;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
        Gold = gold;
        IsEquipped = false; // ������ �ʱ� ���·� �������� �ʾ����� ��Ÿ��
    }

    public void EquipItem()
    {
        IsEquipped = true;
    }

    public void UnequipItem()
    {
        IsEquipped = false;
    }
}
