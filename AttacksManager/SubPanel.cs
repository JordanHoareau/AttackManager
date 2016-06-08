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
    class SubPanel : Panel
    {
        public SubPanel() { }
        public SubPanel(int ID)
        {
            
                switch (ID)
                {
                    // CASE : BASIC DAMAGE
                    case 0:
                        Label lb = new Label();
                        lb.Text = "Basic Damage";
                        lb.Location = new Point(100, 100);
                        lb.Name = "lb";
                        lb.Parent = this;
                        this.Controls.Add(lb);
                        System.Console.Out.WriteLine("yo");
                        break;

                    // CASE : BUFFS
                    case 1:
                        System.Console.Out.WriteLine("yop");
                        break;

                    // CASE : POISON
                    case 2:
                        System.Console.Out.WriteLine("yopp");
                        break;

                    // CASE : BLINK
                    case 3:
                        System.Console.Out.WriteLine("yoppp");
                        break;
                }
        }
    }
}
