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
    public bool IsEquipped { get; private set; } // 아이템이 장착되었는지를 나타내는 속성

    #endregion

    public Items(string itemname, string abilityname, int abilityvalue, string iteminfo, int gold)
    {
        ItemName = itemname;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
        Gold = gold;
        IsEquipped = false; // 아이템 초기 상태로 장착되지 않았음을 나타냄
    }
}
