using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    #region Properties

    public string Name { get; }
    public string Job { get; }
    public int Level { get; private set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Critical { get; set; }
    public int Gold { get; set; }

    #endregion

    public Character(string name, string job, int level, int atk, int def, int hp, int critical, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Critical = critical;
        Gold = gold;
    }
}
