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
		bool[] defaultboolarray = new bool[20];
		bool[] templeboolarray = new bool[20];
		bool[] furnaceboolarray = new bool[20];
		bool[] treeboolarray = new bool[20];
		bool[] waterfallboolarray = new bool[20];
		bool[] pierboolarray = new bool[20];
		bool[] stoneboolarray = new bool[20];
		bool[] pagodaboolarray = new bool[20];
		//BF это не battlefield, как бы печально это не было, хех, bruteforce (ох уж эти флешбеки с ЕГЭ)
		//На этом месте илья смотрел на мой код. Привет илья. Иди нахуй
		//массив копирует оригинальный если на текущей попытке перебора используется эта кнопка, чтобы прибавить все ативные кнопки и понять сколько фонарей загорит в итоге, если очередь не за этой конпкой-массив забит нулями.
		Byte[] BFtemplearray = new Byte[20];
		Byte[] BFfurnacearray = new Byte[20];
		Byte[] BFtreearray = new Byte[20];
		Byte[] BFwaterfallarray = new Byte[20];
		Byte[] BFpierarray = new Byte[20];
		Byte[] BFstonearray = new Byte[20];
		Byte[] BFpagodaarray = new Byte[20];
		int[] Bruteforce = new int[20];
		Byte[] Lampname = new byte[7];
		
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
		private void Form1_Load(object sender, EventArgs e)
		{
			ToolTip clear = new ToolTip();
			clear.SetToolTip(button1, "Начать перебор комбинации кнопок, которые включат наибольшее количество фонарей");
			clear.SetToolTip(button2, "Очистить текущие значения выбранной кнопки");
			clear.SetToolTip(button3, "Очистить все значения для всех кнопок");

		}
		private void CheckBoxes_CheckedChanged(Object sender, EventArgs e)
		{
			switch (comboBox1.Text)
			{
				case "Горит изначально":
					for (byte index = 0; index <= 19; index++)
					{
						defaultboolarray[index] = checkboxarray[index].Checked;
						if (checkboxarray[index].Checked == true)
						{
							checkboxarray[index].BackColor = Color.Orange;
						}
						else
						{
							checkboxarray[index].BackColor = SystemColors.Control;
						}
					}
					break;
				case "Храм":
					for (byte index = 0; index <= 19; index++)
					{
						templeboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Печь":
					for (byte index = 0; index <= 19; index++)
					{
						furnaceboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Дерево":
					for (byte index = 0; index <= 19; index++)
					{
						treeboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Водопад":
					for (byte index = 0; index <= 19; index++)
					{
						waterfallboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Пирс":
					for (byte index = 0; index <= 19; index++)
					{
						pierboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Камень":
					for (byte index = 0; index <= 19; index++)
					{
						stoneboolarray[index] = checkboxarray[index].Checked;
					}
					break;
				case "Пагода":
					for (byte index = 0; index <= 19; index++)
					{
						pagodaboolarray[index] = checkboxarray[index].Checked;
					}
					break;
			}
		}
		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (CheckBox box in checkboxarray)
			{
				if (box != null)
				{
					box.CheckedChanged -= new EventHandler(CheckBoxes_CheckedChanged);
				}
			}
			for (byte index = 0; index <= 19; index++)
			{ 
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
					case "Печь":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = furnaceboolarray[index];
						break;
					case "Дерево":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = treeboolarray[index];
						break;
					case "Водопад":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = waterfallboolarray[index];
						break;
					case "Пирс":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = pierboolarray[index];
						break;
					case "Камень":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = stoneboolarray[index];
						break;
					case "Пагода":
						checkboxarray[index].Checked = false;
						checkboxarray[index].Checked = pagodaboolarray[index];
						break;
				}
			}
			foreach (CheckBox box in checkboxarray)
			{
				if (box != null)
				{
					box.CheckedChanged += new EventHandler(CheckBoxes_CheckedChanged);
				}
			}
		}
		//Func<Boolean, char> convert = x => x==false? '0':'1';
		private void Button1_Click(object sender, EventArgs e)
		{
			byte lampon=0;
			string buttontopress="";
			bool exit = false;
			bool next= false;
			int emptycheck = 0;
			Func<Boolean, int> convert = x => x == false ? (0) : (1);
			byte i0 = 0;
			byte i1 = 0;
			byte i2 = 0;
			byte i3 = 0;
			byte i4 = 0;
			byte i5 = 0;
			byte i6 = 0;
			byte i7 = 0;
			for (byte index = 0; index <= 19; index++)
			{
				emptycheck += convert(defaultboolarray[index]) + convert(templeboolarray[index]) + convert(furnaceboolarray[index]) + convert(treeboolarray[index]) + convert(waterfallboolarray[index]) + convert(pierboolarray[index]) + convert(stoneboolarray[index]) + convert(pagodaboolarray[index]);
			}
			if (emptycheck == 0)
			{
				labelresult.Text = "Все элементы пусты";
				exit = true;
			}
			for (i0 = 20; i0 > 0; i0--)
			{
				if (exit == true)
				{
					break;
					
				}
				for (i1 = 0; i1 <= 1; i1++)
				{
					if (i1 == 1)
					{
						for (byte index = 0; index <= 19; index++)
						{
							BFtemplearray[index] = (Byte) convert(templeboolarray[index]);
						}
						Lampname[0] = 1;
					}
					else
					{
						for (byte index = 0; index <= 19; index++)
						{
							BFtemplearray[index] = 0;
						}
						Lampname[0] = 0;
					}
					for (i2= 0; i2 <= 1; i2++)
					{
						if (i2 == 1)
						{
							for (byte index = 0; index <= 19; index++)
							{
								BFfurnacearray[index] = (Byte)convert(furnaceboolarray[index]);
							}
							Lampname[1] = 2;
						}
						else
						{
							for (byte index = 0; index <= 19; index++)
							{
								BFfurnacearray[index] = 0;
							}
							Lampname[1] = 0;
						}
						for (i3 = 0; i3 <= 1; i3++)
						{
							if (i3 == 1)
							{
								for (byte index = 0; index <= 19; index++)
								{
									BFtreearray[index] = (Byte)convert(treeboolarray[index]);
								}
								Lampname[2] = 3;
							}
							else
							{
								for (byte index = 0; index <= 19; index++)
								{
									BFtreearray[index] = 0;
								}
								Lampname[2] = 0;
							}
							for ( i4 = 0; i4 <= 1; i4++)
							{
								if (i4 == 1)
								{
									for (byte index = 0; index <= 19; index++)
									{
										BFwaterfallarray[index] = (Byte)convert(waterfallboolarray[index]);
									}
									Lampname[3] = 4;
								}
								else
								{
									for (byte index = 0; index <= 19; index++)
									{
										BFwaterfallarray[index] = 0;
									}
									Lampname[3] = 0;
								}
								for (i5 = 0; i5 <= 1; i5++)
								{
									if (i5 == 1)
									{
										for (byte index = 0; index <= 19; index++)
										{
											BFpierarray[index] = (Byte)convert(pierboolarray[index]);
										}
										Lampname[4] = 5;
									}
									else
									{
										for (byte index = 0; index <= 19; index++)
										{
											BFpierarray[index] = 0;
										}
										Lampname[4] = 0;
									}
									for (i6 = 0; i6 <= 1; i6++)
									{
										if (i6 == 1)
										{
											for (byte index = 0; index <= 19; index++)
											{
												BFstonearray[index] = (Byte)convert(stoneboolarray[index]);
											}
											Lampname[5] = 6;
										}
										else
										{
											for (byte index = 0; index <= 19; index++)
											{
												BFstonearray[index] = 0;
											}
											Lampname[5] = 0;
										}
										for (i7 = 0; i7 <= 1; i7++)
										{
											if (i7 == 1)
											{
												for (byte index = 0; index <= 19; index++)
												{
													BFpagodaarray[index] = (Byte)convert(pagodaboolarray[index]);
												}
												Lampname[6] = 7;
											}
											else
											{
												for (byte index = 0; index <= 19; index++)
												{
													BFpagodaarray[index] = 0;
												}
												Lampname[6] = 0;
											}
											for (byte index = 0; index <= 19; index++)
											{
												Bruteforce[index] = convert(defaultboolarray[index]) + BFtemplearray[index] + BFfurnacearray[index] + BFtreearray[index] + BFwaterfallarray[index] + BFpierarray[index] + BFstonearray[index] + BFpagodaarray[index];
												if (Bruteforce[index] % 2 == 0)
												{
													Bruteforce[index] = 0;
												}
												else
												{
													Bruteforce[index] = 1;
												}
												lampon += (byte)Bruteforce[index];
											}
											if (lampon == i0)
											{
												buttontopress += "Комбинация для " + lampon + " фонарей найдена:\n\n";

												for (byte index = 0; index <= 6; index++)
												{
													switch (Lampname[index])
													{
														case 1:
															buttontopress += "Храм\n";
															break;
														case 2:
															buttontopress += "Печь\n";
															break;
														case 3:
															buttontopress += "Дерево\n";
															break;
														case 4:
															buttontopress += "Водопад\n";
															break;
														case 5:
															buttontopress += "Пирс\n";
															break;
														case 6:
															buttontopress += "Камень\n";
															break;
														case 7:
															buttontopress += "Пагода\n";
															break;
													}
												}
												labelresult.Text = buttontopress;
												i1 = 1;
												i2 = 1;
												i3 = 1;
												i4 = 1;
												i5 = 1;
												i6 = 1;
												i7 = 1;
												lampon = 0;
												exit = true;
											}
											if (i0 < 15 && lampon != i0 && next == false)
											{
												DialogResult dialog = MessageBox.Show("Комбинации с 15 или более рабочими фонарями не найдена, менее 15 включенных фонарей смысла не имеют.\nПоказать следующие комбинации которые будут найдены?", "Продолжать перебор?", MessageBoxButtons.YesNo);
												if (dialog == DialogResult.No)
												{
													i1 = 1;
													i2 = 1;
													i3 = 1;
													i4 = 1;
													i5 = 1;
													i6 = 1;
													i7 = 1;
													exit = true;
												}
												else if (dialog == DialogResult.Yes)
												{
													next = true;
												}
											}
											if (lampon != i0)
											{
												lampon = 0;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if (exit == false)
			{
				labelresult.Text = "Подбор окончен\nКомбинация не найдена\n\nПерепроверьте правильность заполнения результатов работы кнопок";
			}
		}
		private void Button2_Click(object sender, EventArgs e)
		{
			for (byte index = 0; index <= 19; index++)
			{
				checkboxarray[index].Checked = false;
				switch (comboBox1.Text)
				{
					case "Горит изначально":
							defaultboolarray[index] = false;
						break;
					case "Храм":
							templeboolarray[index] = false;
						break;
					case "Печь":
							furnaceboolarray[index] = false;
						break;
					case "Дерево":
							treeboolarray[index] = false;
						break;
					case "Водопад":
							waterfallboolarray[index] = false;
						break;
					case "Пирс":
							pierboolarray[index] = false;
						break;
					case "Камень":
							stoneboolarray[index] = false;
						break;
					case "Пагода":
							pagodaboolarray[index] = false;
						break;
				}
			}
		}
		private void Button3_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Вы уверены что хотите стереть все данные о всех кнопках?","Осторожно", MessageBoxButtons.YesNo);
			if (dialog == DialogResult.Yes)
			{
				for (byte index = 0; index <= 19; index++)
				{
					checkboxarray[index].Checked = false;
					checkboxarray[index].BackColor = SystemColors.Control;
					defaultboolarray[index] = false;
					templeboolarray[index] = false;
					furnaceboolarray[index] = false;
					treeboolarray[index] = false;
					waterfallboolarray[index] = false;
					pierboolarray[index] = false;
					stoneboolarray[index] = false;
					pagodaboolarray[index] = false;
				}
			}
		}

		private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
		{
			MessageBox.Show("Donov Roman\nVetrov Vladimir\nThanks to DICE and all Battlefield 4 developers\nApril 2019", "About");
			e.Cancel = true;
		}
	}
}
