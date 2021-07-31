using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderS
{
    public struct Weapon
    {
        public string Name;
        public int Mod;
        public string Damage;
        public string Crit;
        public string Type;
        public string Dist;
        public Weapon (string n, int m, string d, string c, string t, string dst)
        {
            Name = n; Mod = m; Damage = d; Crit = c; Type = t; Dist = dst;
        }
    }
    public struct Abilities
    {
        //STR, DEX, CON, INT, WIS, CHA
        public int[] Base;
        public int[] Mods;
        public Abilities (int[] _base, int[] _mods)
        {
            Base = _base;
            Mods = _mods;
        }
    }
    public struct Attacks
    {
        public int InitiativeBase;
        public int MeleeBase;
        public int DistanceBase;
        public Attacks (int i, int m, int d)
        {
            InitiativeBase = i;
            MeleeBase = m;
            DistanceBase = d;
        }
    }
    public struct Throws
    {
        public int FortitudeBase;
        public int ReflexBase;
        public int WillBase;
        public Throws(int f, int r, int w)
        {
            FortitudeBase = f;
            ReflexBase = r;
            WillBase = w;
        }
    }
    public struct ArmorClass
    {
        public int[] Mods;
        public ArmorClass(int[] mods)
        {
            Mods = mods;
        }
    }
    public class Player
    {
        public string Name;
        public string Race;
        public string Class;
        public int Exp;
        public int Level;
        public int HP;
        public int Speed;

        public Abilities Ability;
        public Attacks Attack;
        public Throws Throw;
        public Weapon Weapon1;
        public Weapon Weapon2;
        public ArmorClass AC;
        
        public string SpecsSpells;
        public string Gear;
        public Player() 
        {
            Clear();
        }
        private void Clear()
        {
            Name = "-";
            Race = "-";
            Class = "-";
            Exp = 0;
            Level = 0;
            HP = 0;
            Speed = 0;
            Ability = new Abilities(new int[6] { 0, 0, 0, 0, 0, 0 }, new int[6] { 0, 0, 0, 0, 0, 0 });
            Attack = new Attacks(0, 0, 0);
            Throw = new Throws(0, 0, 0);
            Weapon1 = new Weapon("-", 0, "-", "-", "-", "-");
            Weapon2 = new Weapon("-", 0, "-", "-", "-", "-");
            AC = new ArmorClass(new int[3] { 0, 0, 0});
            SpecsSpells = "-";
            Gear = "-";
        }
        public void InitializeMainInfo(string name, string race, string cls, int exp, int lvl, int hp, int spd)
        {
            Name = name;
            Race = race;
            Class = cls;
            Exp = exp;
            Level = lvl;
            HP = hp;
            Speed = spd;
        }
        public void InitializeAbilities(Abilities ab)
        {
            Ability = ab;
        }
        public void InitializeAttacks(Attacks at)
        {
            Attack = at;
        }
        public void InitializeThrows(Throws thr)
        {
            Throw = thr;
        }
        public void InitilizeWeapon(Weapon w1, Weapon w2)
        {
            Weapon1 = w1;
            Weapon2 = w2;
        }
        public void InitilizeArmorClass(ArmorClass ac)
        {
            AC = ac;
        }
        public void InitilizeSpecsGear(string spec, string gear)
        {
            SpecsSpells = spec;
            Gear = gear;
        }
        public int ComputeInitiative()
        {
            return Attack.InitiativeBase + Ability.Mods[1];
        }
        public int ComputeMelee()
        {
            return Attack.MeleeBase + Ability.Mods[0];
        }
        public int ComputeDistance()
        {
            return Attack.DistanceBase + Ability.Mods[1];
        }
        public int ComputeFortitude()
        {
            return Throw.FortitudeBase + Ability.Mods[2];
        }
        public int ComputeReflex()
        {
            return Throw.ReflexBase + Ability.Mods[1];
        }
        public int ComputeWill()
        {
            return Throw.WillBase + Ability.Mods[4];
        }
        public int ComputeArmorClass()
        {
                int res = 0;
            for (int i = 0; i < AC.Mods.Length; i++) res += AC.Mods[i];
            return res + Ability.Mods[1] + 10;
        }

    }
}
