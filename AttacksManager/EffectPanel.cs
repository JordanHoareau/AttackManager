
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttacksManager
{
    class EffectPanel : GroupBox
    {
        // Effect Names
        private string[] EffectsTypeStr;
        // RadioButtons
        private RadioButton[] EffectType;

        // Panel d'affichage des champs de l'effet
        private Panel SubEffectPanel;
        private Panel ScrollablePanel;
        private int NumberOfDamage;
        private int NumberOfBuff;
        public EffectPanel() { }

        public EffectPanel(string title, int verticalOffset)
        {
            this.Text = title;
            // Liste des types d'effets (string)
            EffectsTypeStr = new string[4];
            EffectsTypeStr[0] = "Basic Damage";
            EffectsTypeStr[1] = "Buffs";
            EffectsTypeStr[2] = "Poison";
            EffectsTypeStr[3] = "Blink";

            // Instantiation des boutons radio: effets
            EffectType = new RadioButton[4];
            for (int i = 0; i < EffectsTypeStr.Length; i++)
            {
                EffectType[i] = new RadioButton();
                EffectType[i].Parent = this;
                EffectType[i].Text = EffectsTypeStr[i];
                EffectType[i].Name = EffectsTypeStr[i].Replace(" ", "");
                EffectType[i].Tag = i;
                EffectType[i].Location = new Point(10 + i * 120, 20);
                EffectType[i].CheckedChanged += new EventHandler(EffectsButton_CheckedChanged);
                this.Controls.Add(EffectType[i]);
            }

            // Création du sous-panneau
            SubEffectPanel = new Panel();
            SubEffectPanel.Location = new Point(10, 50);
            SubEffectPanel.Parent = this;
            SubEffectPanel.AutoScroll = true;
            SubEffectPanel.Size = new Size(2000, 2000);
            SubEffectPanel.Name = "sub";
            this.Controls.Add(SubEffectPanel);



        }

        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        /********************************************************************/
        // EVENT HANDLER : SELECTION D'UN EFFET
        /********************************************************************/
        private void EffectsButton_CheckedChanged(Object sender,
                                         EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton.Checked)
            {
                SubEffectPanel.Controls.Clear();
                int radioButtonTag = (int)radioButton.Tag;
                switch (radioButtonTag)
                {
                    /****************************************************************/
                    // CASE : BASIC DAMAGE
                    /****************************************************************/
                    case 0:
                        /************************/
                        /*        LABELS        */
                        /************************/
                        // BASE DAMAGE - LABEL
                        Label BaseDamage = new Label();
                        BaseDamage.Text = "Base Damage";
                        BaseDamage.Location = new Point(16, 10);
                        BaseDamage.Name = "BaseD";
                        BaseDamage.Size = new Size(80, 13);
                        BaseDamage.Parent = this;
                        SubEffectPanel.Controls.Add(BaseDamage);
                    
                        // RADIUS - LABEL
                        Label BaseDamageRadiusm = new Label();
                        BaseDamageRadiusm.Text = "Radius Min";
                        BaseDamageRadiusm.Location = new Point(16, 40);
                        BaseDamageRadiusm.Name = "rdm";
                        BaseDamageRadiusm.Size = new Size(80, 13);
                        BaseDamageRadiusm.Parent = this;
                        SubEffectPanel.Controls.Add(BaseDamageRadiusm);

                        Label BaseDamageRadiusM = new Label();
                        BaseDamageRadiusM.Text = "Radius Max";
                        BaseDamageRadiusM.Location = new Point(16, 61);
                        BaseDamageRadiusM.Name = "rdm";
                        BaseDamageRadiusM.Size = new Size(80, 13);
                        BaseDamageRadiusM.Parent = this;
                        SubEffectPanel.Controls.Add(BaseDamageRadiusM);

                        /*********************************************/
                        /*        FIRST BASE DAMAGE AND RADII        */
                        /*********************************************/

                        // FIRST BASE DAMAGE - NUMERICUPDOWN
                        NumericUpDown Damage = new NumericUpDown();
                        Damage.Location = new Point(100, 8);
                        Damage.Size = new Size(40, 20);
                        Damage.Name = "BaseDamage1";
                        Damage.Parent = this;
                        SubEffectPanel.Controls.Add(Damage);

                        // FIRST MIN RADIUS - NUMERICUPDOWN
                        NumericUpDown RadiusMin = new NumericUpDown();
                        RadiusMin.Location = new Point(100, 38);
                        RadiusMin.Size = new Size(40, 15);
                        RadiusMin.Name = "RadiusMin1";
                        RadiusMin.Parent = this;
                        SubEffectPanel.Controls.Add(RadiusMin);

                        // FIRST MAX RADIUS - NUMERICUPDOWN
                        NumericUpDown RadiusMax = new NumericUpDown();
                        RadiusMax.Location = new Point(100, 58);
                        RadiusMax.Size = new Size(40, 20);
                        RadiusMax.Name = "RadiusMax1";
                        RadiusMax.Parent = this;
                        SubEffectPanel.Controls.Add(RadiusMax);

                        // NUMBER OF DAMAGE UPDATE ACCORDING TO INITIALIZATION                        
                        NumberOfDamage = 1;

                        /*********************************************/
                        /*                DAMAGE NUMBER              */
                        /*********************************************/
                        // Damage Occurences - LABEL
                        Label lbDamageOccur = new Label();
                        lbDamageOccur.Text = "DamageNb";
                        lbDamageOccur.Location = new Point(16, 91);
                        lbDamageOccur.Name = "lbDO";
                        lbDamageOccur.Size = new Size(80, 13);
                        lbDamageOccur.Parent = this;
                        SubEffectPanel.Controls.Add(lbDamageOccur);

                        NumericUpDown DmgNumber = new NumericUpDown();
                        DmgNumber.Minimum = 1;
                        DmgNumber.Location = new Point(100, 88);
                        DmgNumber.Size = new Size(40, 15);
                        DmgNumber.Name = "DmgNumber";
                        DmgNumber.Value = 1;
                        DmgNumber.Parent = this;
                        DmgNumber.ValueChanged += new EventHandler(DmgNumber_ValueChanged);
                        SubEffectPanel.Controls.Add(DmgNumber);

                        // LifeSteal - COMBOBOX
                        CheckBox LifeStealCheckBox = new CheckBox();
                        LifeStealCheckBox.Text = "Lifesteal";
                        LifeStealCheckBox.Location = new Point(16, 110);
                        LifeStealCheckBox.Text = "Lifesteal";
                        LifeStealCheckBox.Size = new Size(80, 20);
                        LifeStealCheckBox.Parent = this;
                        SubEffectPanel.Controls.Add(LifeStealCheckBox);


                        break;


                    /********************************************************************/
                    /********************************************************************/
                    /********************************************************************/

                    /****************************************************************/
                    // CASE : BUFFS
                    /****************************************************************/
                    case 1:
                        /************************/
                        /*       LABELS         */
                        /************************/

                        // BUFFDAMAGE - LABEL
                        Label Buff_DamageValue = new Label();
                        Buff_DamageValue.Text = "Damage";
                        Buff_DamageValue.Location = new Point(16, 10);
                        Buff_DamageValue.Name = "";
                        Buff_DamageValue.Size = new Size(80, 13);
                        Buff_DamageValue.Parent = this;
                        SubEffectPanel.Controls.Add(Buff_DamageValue);

                        // STATMODIFIER - LABEL
                        Label Buff_StatModifierValue = new Label();
                        Buff_StatModifierValue.Text = "Stat Modifier";
                        Buff_StatModifierValue.Location = new Point(16, 40);
                        Buff_StatModifierValue.Name = "";
                        Buff_StatModifierValue.Size = new Size(80, 13);
                        Buff_StatModifierValue.Parent = this;
                        SubEffectPanel.Controls.Add(Buff_StatModifierValue);
                        // RADIUS - LABEL
                        Label Label_RadiusMin = new Label();
                        Label_RadiusMin.Text = "Radius Min";
                        Label_RadiusMin.Location = new Point(16, 70);
                        Label_RadiusMin.Name = "rdm";
                        Label_RadiusMin.Size = new Size(80, 13);
                        Label_RadiusMin.Parent = this;
                        SubEffectPanel.Controls.Add(Label_RadiusMin);

                        Label Label_RadiusMax = new Label();
                        Label_RadiusMax.Text = "Radius Max";
                        Label_RadiusMax.Location = new Point(16, 91);
                        Label_RadiusMax.Name = "rdm";
                        Label_RadiusMax.Size = new Size(80, 13);
                        Label_RadiusMax.Parent = this;
                        SubEffectPanel.Controls.Add(Label_RadiusMax);

                        /*********************************************/
                        /*        FIRST BASE VALUES AND RADII        */
                        /*********************************************/
                        // FIRST BASE Value - NUMERICUPDOWN
                        NumericUpDown Value = new NumericUpDown();
                        Value.Location = new Point(100, 8);
                        Value.Size = new Size(40, 20);
                        Value.Name = "BaseValue1";
                        Value.Parent = this;
                        SubEffectPanel.Controls.Add(Value);

                        // FIRST BASE STAT MODIFIER - NUMERICUPDOWN
                        NumericUpDown StatModifier = new NumericUpDown();
                        StatModifier.Location = new Point(100, 38);
                        StatModifier.Size = new Size(40, 20);
                        StatModifier.Name = "BaseStatModifier1";
                        StatModifier.Parent = this;
                        SubEffectPanel.Controls.Add(StatModifier);

                        // FIRST MIN RADIUS - NUMERICUPDOWN
                        NumericUpDown BuffRadiusMin = new NumericUpDown();
                        BuffRadiusMin.Location = new Point(100, 68);
                        BuffRadiusMin.Size = new Size(40, 15);
                        BuffRadiusMin.Name = "BuffRadiusMin1";
                        BuffRadiusMin.Parent = this;
                        SubEffectPanel.Controls.Add(BuffRadiusMin);

                        // FIRST MAX RADIUS - NUMERICUPDOWN
                        NumericUpDown BuffRadiusMax = new NumericUpDown();
                        BuffRadiusMax.Location = new Point(100, 88);
                        BuffRadiusMax.Size = new Size(40, 20);
                        BuffRadiusMax.Name = "BuffRadiusMax1";
                        BuffRadiusMax.Parent = this;
                        SubEffectPanel.Controls.Add(BuffRadiusMax);

                        // NUMBER OF DAMAGE UPDATE ACCORDING TO INITIALIZATION                        
                        NumberOfBuff = 1;
                        break;

                    // CASE : POISON
                    case 2:
                        Label lbPoisonValue = new Label();
                        lbPoisonValue.Text = "Poison Values";
                        lbPoisonValue.Location = new Point(16, 10);
                        lbPoisonValue.Name = "lbD";
                        lbPoisonValue.Size = new Size(80, 13);
                        lbPoisonValue.Parent = this;
                        SubEffectPanel.Controls.Add(lbPoisonValue);
                        break;



                    // CASE : BLINK
                    case 3:
                        Label lbBlinkValue = new Label();
                        lbBlinkValue.Text = "Blink Values";
                        lbBlinkValue.Location = new Point(16, 10);
                        lbBlinkValue.Name = "lbD";
                        lbBlinkValue.Size = new Size(80, 13);
                        lbBlinkValue.Parent = this;
                        SubEffectPanel.Controls.Add(lbBlinkValue);
                        break;
                }
                this.Controls.Add(SubEffectPanel);
            }

        }


        /********************************************************************/
        /********************************************************************/
        /********************************************************************/

        /********************************************************************/
        // EVENT HANDLER : CHANGEMENT DU NOMBRE D'OCCURRENCES
        /********************************************************************/
        private void DmgNumber_ValueChanged(Object sender,
                                             EventArgs e)
        {
            // Récupération du NUD et définition du nombre de NUD à créer.
            NumericUpDown NUD = sender as NumericUpDown;
            int ToCreate = (int) NUD.Value - NumberOfDamage;

            // Modification à faire : ajout de NumericUpDown
            if (ToCreate > 0)
            {
                while (NumberOfDamage != NUD.Value)
                {
                    // Création Du NUD - BASE DAMAGE
                    NumericUpDown Damage = new NumericUpDown();
                    Damage.Location = new Point(100 + 50 * NumberOfDamage, 8);
                    Damage.Size = new Size(40, 20);
                    Damage.Parent = this;

                    // Création du NUD - Min RADIUS
                    NumericUpDown RadiusMin = new NumericUpDown();
                    RadiusMin.Location = new Point(100 + 50 * NumberOfDamage, 38);
                    RadiusMin.Size = new Size(40, 20);
                    RadiusMin.Parent = this;

                    // Création du NUD - MAX RADIUS
                    NumericUpDown RadiusMax = new NumericUpDown();
                    RadiusMax.Location = new Point(100 + 50 * NumberOfDamage, 58);
                    RadiusMax.Size = new Size(40, 20);
                    RadiusMax.Parent = this;

                    // Incrémentation du compteur d'occurrences
                    NumberOfDamage++;
                    Damage.Name = "BaseDamage" + NumberOfDamage;
                    RadiusMin.Name = "RadiusMin" + NumberOfDamage;
                    RadiusMax.Name = "RadiusMax"+NumberOfDamage;

                    // Ajout dans le Controls de SubEffectPanel
                    SubEffectPanel.Controls.Add(Damage);
                    SubEffectPanel.Controls.Add(RadiusMin);
                    SubEffectPanel.Controls.Add(RadiusMax);
                }
            }

            // Modification à faire : suppresison de NumericUpDown
            else if (ToCreate < 0)
            {
                while (NumberOfDamage != NUD.Value)
                {
                    // Création de la liste des NUD à supprimer
                    List<NumericUpDown> ToBeDeleted = new List<NumericUpDown>();
                    foreach(NumericUpDown item in SubEffectPanel.Controls.OfType<NumericUpDown>())
                    {
                        if (item.Name != null && item.Name.Equals("BaseDamage" + NumberOfDamage))
                        {
                            ToBeDeleted.Add(item);
                        } 
                        if (item.Name != null && item.Name.Equals("RadiusMin" + NumberOfDamage))
                        {
                            ToBeDeleted.Add(item);
                        } 
                        if (item.Name != null && item.Name.Equals("RadiusMax" + NumberOfDamage))
                        {
                            ToBeDeleted.Add(item);
                        }
                    }
                    // Suppression des éléments référencés dans ToBeDeleted
                    foreach(NumericUpDown item in ToBeDeleted){
                        SubEffectPanel.Controls.Remove(item);
                        item.Dispose();
                        // Suppression du nombre de dommage sur un seul type de NUD supprimé
                        if(item.Name != null && item.Name.Contains("BaseDamage")) NumberOfDamage--;
                    }
               
                }
            }
        }

    }

}