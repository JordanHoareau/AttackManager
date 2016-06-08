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
    public partial class Form1 : Form
    {
        private List<EffectPanel> effectPanelList;
        private int effectsPanelsNumber ;
        public Form1()
        {
            effectPanelList = new List<EffectPanel>();
            effectsPanelsNumber = 0;
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in tabPage1.Controls)
            {
                System.Diagnostics.Debug.WriteLine(item.Name);
                if (item.Name.Equals("e"+effectsPanelsNumber))
                {
                    tabPage1.Controls.Remove(item);
                    effectsPanelsNumber--;
                    break; //important step

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int EffectOffset = 100 + 200 * ++effectsPanelsNumber;
            int MarginOffset = 28;

            // Création d'un GroupBox pour un effet
            EffectPanel effectPanel = new EffectPanel("Effet " + effectsPanelsNumber, EffectOffset);
            effectPanel.Parent = tabPage1;
            effectPanel.MinimumSize = new Size(450, 200);
            effectPanel.Location = new System.Drawing.Point(MarginOffset, EffectOffset);
            effectPanel.Text = "Effect "+effectsPanelsNumber.ToString();
            effectPanel.Name = "e" + effectsPanelsNumber;
            effectPanel.Size = new System.Drawing.Size(77, 21); 

            tabPage1.Controls.Add(effectPanel);
            effectPanelList.Add(effectPanel);
        }
    }
}
