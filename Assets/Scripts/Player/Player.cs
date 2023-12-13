using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Character player;
    //public static StoreManager storeManager;
    //public static InventoryManager inventoryManager;
    //public static DungeonManager dungeonManager;

    #region Field

    // 아이템 장착 정보 유지용 리스트
    private List<int> equippedItems = new List<int>();
    // 상점용 구매 아이템 리스트
    private List<int> boughtItems = new List<int>();
    // 상점용 판매 아이템 리스트
    private List<int> soldItems = new List<int>();
    // 아이템을 판매할 때 판매된 아이템을 저장할 리스트
    private List<int> soldItemsIndexes = new List<int>();

    // 기존의 items 배열 대신 List<Items>를 사용
    private List<Items> items = new List<Items>();

    // 기존의 상점용 아이템 배열 storeItems 대신 리스트 사용
    private List<StoreItems> storeItems = new List<StoreItems>();

    private ItemEquip itemEquip;
    public TextMeshProUGUI jobTxt;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI lvTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI attackTxt;
    public TextMeshProUGUI defenseTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI criticalTxt;

    #endregion

    #region Init
    // 캐릭터, 인벤토리 아이템, 상점 아이템 정보
    private void Start()
    {
        GameDataSetting();
        //storeManager = new StoreManager(player);
        //inventoryManager = new InventoryManager();
        //dungeonManager = new DungeonManager(player);
        //DisplayGameIntro();
        DisplayMyInfo();
        panelStats();
    }

    private void GameDataSetting()
    {
        // 캐릭터 정보 세팅(이름, 직업, 레벨, 공격력, 방어력, 체력, 치명타, 돈)
        player = new Character("루루", "서포터", 1, 47, 26, 595, 20, 15000);

        // 여긴 아이템 1 = 인덱스 0번!!!!!
        // 기본 보유 중인 아이템 정보 세팅(배열 -> 리스트로 변경)
        items.Add(new Items("존야의 모래시계", "zhonya", "방어력", 45, "띵 - ", 1500));
        items.Add(new Items("구인수의 격노검", "guinsoo", "공격력", 30, "AD룰루 필수템", 1600));
        //items.Add(new Items("몰락한 왕의 검", "공격력", 40, "체력 비례 데미지", 1600));
        //items.Add(new Items("부서진 여왕의 왕관", "체력", 250, "챔피언 보호 효과", 1400));
        
        // 상점용 아이템 정보 세팅(배열 -> 리스트로 변경) 
        storeItems.Add(new StoreItems("스태틱의 단검", "statikk", "치명타", 20, "찌릿찌릿", 1500));
        storeItems.Add(new StoreItems("강철심장", "heartsteel", "체력", 800, "깡!", 1600));
        //storeItems.Add(new StoreItems("가고일 돌갑옷", "방어력", 60, "룰루로 이걸 왜 삼", 1600));
    }
    #endregion


    // 상태보기 화면
    private void DisplayMyInfo()
    {
        jobTxt.text = player.Job;
        nameTxt.text = player.Name;
        lvTxt.text = "Lv " + player.Level;
        goldTxt.text = player.Gold.ToString("N0");
    }

    private void panelStats()
    {
        attackTxt.text = "공격력 : " + player.Atk;
        defenseTxt.text = "방어력 : " + player.Def;
        hpTxt.text = "체력 : " + player.Hp;
        criticalTxt.text = "치명타 : " + player.Critical;
    }

    public List<Items> GetPlayerItems()
    {
        return items;
    }

    public List<StoreItems> GetStoreItems()
    {
        return storeItems;
    }

    public List<int> GetEquippedItems()
    {
        return equippedItems;
    }

    public List<int> GetBoughtItems()
    {
        return boughtItems;
    }

    // 장착으로 얻은 능력치를 표시하는 메소드
    public void DisplayCharacterStatus(int itemNum)
    {
        // 장착한 아이템이 하나도 없다면
        if (equippedItems.Count == 0)
        {
            Debug.Log("장착한 아이템이 없습니다");
        }
        // 장착한 아이템이 하나 이상 존재한다면
        else
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusHp = 0;
            int bonusCrit = 0;

            // 아이템 인덱스로 실제 아이템을 가져옴
            Items equippedItem = items[itemNum];
            Debug.Log(equippedItem.ItemName);

            // 아이템으로 얻은 능력치를 계산
            if (equippedItem.AbilityName == "공격력")
            {
                bonusAtk += equippedItem.AbilityValue;
                player.Atk += bonusAtk;
            }
            else if (equippedItem.AbilityName == "방어력")
            {
                bonusDef += equippedItem.AbilityValue;
                player.Def += bonusDef;
            }
            else if (equippedItem.AbilityName == "체력")
            {
                bonusHp += equippedItem.AbilityValue;
                player.Hp += bonusHp;
            }
            else if (equippedItem.AbilityName == "치명타")
            {
                bonusCrit += equippedItem.AbilityValue;
                player.Critical += bonusCrit;
            }
            Debug.Log($"{bonusDef}만큼 능력치 증가");
            Debug.Log($"현재 총 방어력은 {player.Def}");
            panelStats();
        }
    }

    // 장착 해제로 잃은 능력치를 표시하는 메소드
    public void UnEquipCharacterStatus(int itemNum)
    {
        int bonusAtk = 0;
        int bonusDef = 0;
        int bonusHp = 0;
        int bonusCrit = 0;

        // 아이템 인덱스로 실제 아이템을 가져옴
        Items equippedItem = items[itemNum];
        Debug.Log(equippedItem.ItemName);

        // 아이템으로 얻은 능력치를 계산
        if (equippedItem.AbilityName == "공격력")
        {
            bonusAtk += equippedItem.AbilityValue;
            player.Atk -= bonusAtk;
        }
        else if (equippedItem.AbilityName == "방어력")
        {
            bonusDef += equippedItem.AbilityValue;
            player.Def -= bonusDef;
        }
        else if (equippedItem.AbilityName == "체력")
        {
            bonusHp += equippedItem.AbilityValue;
            player.Hp -= bonusHp;
        }
        else if (equippedItem.AbilityName == "치명타")
        {
            bonusCrit += equippedItem.AbilityValue;
            player.Critical -= bonusCrit;
        }
        panelStats();
    }
}
