using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PathfinderS
{
    public partial class mainForm : Form
    {
        Player MainPlayer = new Player();
        string SavedFileName;
     
        public mainForm()
        {
            InitializeComponent();

            //Set null values
            FillFormFromObject();

            //Set filters for file dialog
            openFileDialog.Filter = "JSON-files(*.json)|*.json|All files(*.*)|*.*";
            saveFileDialog.Filter = "JSON-files(*.json)|*.json|All files(*.*)|*.*";
        }

        void FillFormFromObject ()
        {
            //Set Main info
            textBoxName.Text = MainPlayer.Name;
            textBoxRace.Text = MainPlayer.Race;
            textBoxClassC.Text = MainPlayer.Class;
            textBoxExp.Text = MainPlayer.Exp.ToString();
            textBoxLevel.Text = MainPlayer.Level.ToString();
            textBoxHP.Text = MainPlayer.HP.ToString();
            textBoxSpeed.Text = MainPlayer.Speed.ToString();

            //Set Mods
            textBoxAb1.Text = MainPlayer.Ability.Base[0].ToString();
            textBoxAb2.Text = MainPlayer.Ability.Base[1].ToString();
            textBoxAb3.Text = MainPlayer.Ability.Base[2].ToString();
            textBoxAb4.Text = MainPlayer.Ability.Base[3].ToString();
            textBoxAb5.Text = MainPlayer.Ability.Base[4].ToString();
            textBoxAb6.Text = MainPlayer.Ability.Base[5].ToString();
            textBoxAb7.Text = MainPlayer.Ability.Mods[0].ToString();
            textBoxAb8.Text = MainPlayer.Ability.Mods[1].ToString();
            textBoxAb9.Text = MainPlayer.Ability.Mods[2].ToString();
            textBoxAb10.Text = MainPlayer.Ability.Mods[3].ToString();
            textBoxAb11.Text = MainPlayer.Ability.Mods[4].ToString();
            textBoxAb12.Text = MainPlayer.Ability.Mods[5].ToString();

            //Set Attacks group
            textBoxINI1.Text = MainPlayer.Attack.InitiativeBase.ToString();
            textBoxINI2.Text = MainPlayer.Ability.Mods[1].ToString();
            textBoxINItotal.Text = MainPlayer.ComputeInitiative().ToString();

            textBoxMEL1.Text = MainPlayer.Attack.MeleeBase.ToString();
            textBoxMEL2.Text = MainPlayer.Ability.Mods[0].ToString();
            textBoxMELtotal.Text = MainPlayer.ComputeMelee().ToString();

            textBoxDIST1.Text = MainPlayer.Attack.DistanceBase.ToString();
            textBoxDIST2.Text = MainPlayer.Ability.Mods[1].ToString();
            textBoxDISTtotal.Text = MainPlayer.ComputeDistance().ToString();

            //Set Throws group
            textBoxFOR1.Text = MainPlayer.Throw.FortitudeBase.ToString();
            textBoxFOR2.Text = MainPlayer.Ability.Mods[2].ToString();
            textBoxFORtotal.Text = MainPlayer.ComputeFortitude().ToString();

            textBoxREF1.Text = MainPlayer.Throw.ReflexBase.ToString();
            textBoxREF2.Text = MainPlayer.Ability.Mods[1].ToString();
            textBoxREFtotal.Text = MainPlayer.ComputeReflex().ToString();

            textBoxWILL1.Text = MainPlayer.Throw.WillBase.ToString();
            textBoxWILL2.Text = MainPlayer.Ability.Mods[4].ToString();
            textBoxWILLtotal.Text = MainPlayer.ComputeWill().ToString();

            //Set Weapons group
            textBoxWeapon1.Text = MainPlayer.Weapon1.Name;
            textBoxWeaponMod1.Text = MainPlayer.Weapon1.Mod.ToString();
            textBoxWeaponDmg1.Text = MainPlayer.Weapon1.Damage;
            textBoxWeaponCrit1.Text = MainPlayer.Weapon1.Crit;
            textBoxWeaponType1.Text = MainPlayer.Weapon1.Type;
            textBoxWeaponDist1.Text = MainPlayer.Weapon1.Dist;

            textBoxWeapon2.Text = MainPlayer.Weapon2.Name;
            textBoxWeaponMod2.Text = MainPlayer.Weapon2.Mod.ToString();
            textBoxWeaponDmg2.Text = MainPlayer.Weapon2.Damage;
            textBoxWeaponCrit2.Text = MainPlayer.Weapon2.Crit;
            textBoxWeaponType2.Text = MainPlayer.Weapon2.Type;
            textBoxWeaponDist2.Text = MainPlayer.Weapon2.Dist;

            //Set Armor Class group
            textBoxAC1.Text = MainPlayer.AC.Mods[0].ToString();
            textBoxAC2.Text = MainPlayer.AC.Mods[1].ToString();
            textBoxAC3.Text = MainPlayer.AC.Mods[2].ToString();
            textBoxAC4.Text = MainPlayer.AC.Mods[3].ToString();
            textBoxACtotal.Text = MainPlayer.ComputeArmorClass().ToString();

            //Set Specs
            richTextBoxSpecs.Text = MainPlayer.SpecsSpells;
            richTextBoxGear.Text = MainPlayer.Gear;
        }

        void ReadFormToObject()
        {
            //Get Main info
            string TxtName = textBoxName.Text;
            string TxtClass = textBoxClassC.Text;
            string TxtRace = textBoxRace.Text;
            int TxtExp = CheckCorrectInt(textBoxExp.Text);
            int TxtLvl = CheckCorrectInt(textBoxLevel.Text);
            int TxtHP = CheckCorrectInt(textBoxHP.Text);
            int TxtSpeed = CheckCorrectInt(textBoxSpeed.Text);
            MainPlayer.InitializeMainInfo(TxtName, TxtClass, TxtRace, TxtExp, TxtLvl, TxtHP, TxtSpeed);

            //Get Mods
            int TxtAb1 = CheckCorrectInt(textBoxAb1.Text);
            int TxtAb2 = CheckCorrectInt(textBoxAb2.Text);
            int TxtAb3 = CheckCorrectInt(textBoxAb3.Text);
            int TxtAb4 = CheckCorrectInt(textBoxAb4.Text);
            int TxtAb5 = CheckCorrectInt(textBoxAb5.Text);
            int TxtAb6 = CheckCorrectInt(textBoxAb6.Text);
            int TxtAb7 = CheckCorrectInt(textBoxAb7.Text);
            int TxtAb8 = CheckCorrectInt(textBoxAb8.Text);
            int TxtAb9 = CheckCorrectInt(textBoxAb9.Text);
            int TxtAb10 = CheckCorrectInt(textBoxAb10.Text);
            int TxtAb11 = CheckCorrectInt(textBoxAb11.Text);
            int TxtAb12 = CheckCorrectInt(textBoxAb12.Text);
            MainPlayer.InitializeAbilities(new Abilities(new int[6] { TxtAb1, TxtAb2, TxtAb3, TxtAb4, TxtAb5, TxtAb6 }, new int[6] { TxtAb7, TxtAb8, TxtAb9, TxtAb10, TxtAb11, TxtAb12 }));

            //Get Attacks group
            int TxtIniBase = CheckCorrectInt(textBoxINI1.Text);
            int TxtMeleeBase = CheckCorrectInt(textBoxMEL1.Text);
            int TxtDistBase = CheckCorrectInt(textBoxDIST1.Text);
            MainPlayer.InitializeAttacks(new Attacks(TxtIniBase, TxtMeleeBase, TxtDistBase));

            //Get Throws group
            int TxtForBase = CheckCorrectInt(textBoxFOR1.Text);
            int TxtRefBase = CheckCorrectInt(textBoxREF1.Text);
            int TxtWillBase = CheckCorrectInt(textBoxWILL1.Text);
            MainPlayer.InitializeThrows(new Throws(TxtForBase, TxtRefBase, TxtWillBase));

            //Get Weapons group
            string TxtWpn1Name = textBoxWeapon1.Text;
            int TxtWpn1Mod = CheckCorrectInt(textBoxWeaponMod1.Text);
            string TxtWpn1Dmg = textBoxWeaponDmg1.Text;
            string TxtWpn1Crit = textBoxWeaponCrit1.Text;
            string TxtWpn1Type = textBoxWeaponType1.Text;
            string TxtWpn1Dist = textBoxWeaponDist1.Text;

            string TxtWpn2Name = textBoxWeapon2.Text;
            int TxtWpn2Mod = CheckCorrectInt(textBoxWeaponMod1.Text);
            string TxtWpn2Dmg = textBoxWeaponDmg2.Text;
            string TxtWpn2Crit = textBoxWeaponCrit2.Text;
            string TxtWpn2Type = textBoxWeaponType2.Text;
            string TxtWpn2Dist = textBoxWeaponDist2.Text;
            MainPlayer.InitilizeWeapon(new Weapon(TxtWpn1Name, TxtWpn1Mod, TxtWpn1Dmg, TxtWpn1Crit, TxtWpn1Type, TxtWpn1Dist), new Weapon(TxtWpn2Name, TxtWpn2Mod, TxtWpn2Dmg, TxtWpn2Crit, TxtWpn2Type, TxtWpn2Dist));

            //Get Armor class group
            int TxtAC1 = CheckCorrectInt(textBoxAC1.Text);
            int TxtAC2 = CheckCorrectInt(textBoxAC2.Text);
            int TxtAC3 = CheckCorrectInt(textBoxAC3.Text);
            int TxtAC4 = CheckCorrectInt(textBoxAC4.Text);
            MainPlayer.InitilizeArmorClass(new ArmorClass(new int[4] { TxtAC1, TxtAC2, TxtAC3, TxtAC4 }));

            //Get Specs
            string TxtSpecs = richTextBoxSpecs.Text;
            string TxtGear = richTextBoxGear.Text;
            MainPlayer.InitilizeSpecsGear(TxtSpecs, TxtGear);
        }

        void NewItem_Click(object sender, EventArgs e)
        {
            MainPlayer = new Player();
            FillFormFromObject();
        }

        void OpenItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string FileName = openFileDialog.FileName;
            string FileText = System.IO.File.ReadAllText(FileName);

            MainPlayer = JsonConvert.DeserializeObject<Player>(FileText);

            FillFormFromObject();

            SavedFileName = FileName;
        }

        void SaveAsItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string FileName = saveFileDialog.FileName;

            ReadFormToObject();

            string JsonString = JsonConvert.SerializeObject(MainPlayer);
            System.IO.File.WriteAllText(FileName, JsonString);

            SavedFileName = FileName;
        }

        void SaveItem_Click(object sender, EventArgs e)
        {
            if (SavedFileName.Length > 0)
            {
                ReadFormToObject();

                string JsonString = JsonConvert.SerializeObject(MainPlayer);
                System.IO.File.WriteAllText(SavedFileName, JsonString);
            }
        }

        int CheckCorrectInt(string str)
        {
            if (str.Length > 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!(Char.IsDigit(str[i]) || str[i] == '-' || str[i] == '+')) return 0; 
                }
            }
            return Convert.ToInt32(str);
        }
    }
}
