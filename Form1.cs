using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DICE_LA_ALPHA
{
	public partial class Form1 : Form
	{
		CheckBox[] checkboxarray = new CheckBox[20];
		bool[] controlboolarray = new bool[20];
		bool[] defaultboolarray = new bool[20];
		bool[] templeboolarray = new bool[20];
		char[] defaultchararray = new char[20];
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            checkboxarray[0] = checkBox1;
            checkboxarray[1] = checkBox2;
            checkboxarray[2] = checkBox3;
            checkboxarray[3] = checkBox4;
            checkboxarray[4] = checkBox5;
            checkboxarray[5] = checkBox6;
            checkboxarray[6] = checkBox7;
            checkboxarray[7] = checkBox8;
            checkboxarray[8] = checkBox9;
            checkboxarray[9] = checkBox10;
            checkboxarray[10] = checkBox11;
            checkboxarray[11] = checkBox12;
            checkboxarray[12] = checkBox13;
            checkboxarray[13] = checkBox14;
            checkboxarray[14] = checkBox15;
            checkboxarray[15] = checkBox16;
            checkboxarray[16] = checkBox17;
            checkboxarray[17] = checkBox18;
            checkboxarray[18] = checkBox19;
            checkboxarray[19] = checkBox20;

			foreach (CheckBox box in checkboxarray) {
                box.CheckedChanged +=new EventHandler(CheckBoxes_CheckedChanged);
            }
		}

        private void CheckBoxes_CheckedChanged(Object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			for (byte index = 0; index <= 19; index++)
			{
				switch (comboBox1.Text)
				{
					case "Горит изначально":
						defaultboolarray[index] = checkboxarray[index].Checked;
						listBox1.Items.Add("ГИ "+defaultboolarray[index]);
						break;
					case "Храм":
						templeboolarray[index] = checkboxarray[index].Checked;
						listBox1.Items.Add("ХР " + defaultboolarray[index]);
						break;
				}
			}

		}

		//Func<Boolean, char> convert = x => x==false? '0':'1';
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			for (byte index = 0; index <= 19; index++) { 
				switch (comboBox1.Text)
				{
					case "Горит изначально":
						if (checkboxarray[index] != null)
						{
							checkboxarray[index].Checked = false;
							checkboxarray[index].Checked = defaultboolarray[index];
						}
						break;
					case "Храм":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = templeboolarray[index];
						break;
				}
			}
		}
	}
}
