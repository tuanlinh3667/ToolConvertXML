﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ToolXML
{
	public partial class Form1 : Form
	{
		IEnumerable<XElement> eMeasure;
		IEnumerable<XElement> eNotes;
		IEnumerable<XElement> chord;
		public string longNote;
		public string pitchNote;
		public string rowNote;
		public string timeNote;
		public string tempo;
		public int note;
		public double _long;
		public Form1()
		{
			InitializeComponent();
		}

		public void button1_Click(object sender, EventArgs e)
		{
			DataTable dt1 = new DataTable();
			dt1.TableName = "temp";
			dt1.Columns.Add("tempo");
			DataRow dataRow = dt1.NewRow();
			dataRow["tempo"] = textBox1.Text;
			dt1.Rows.Add(dataRow);

			DataTable dt2 = new DataTable();
			dt2.TableName = "pos";
			dt2.Columns.Add("time");
			dt2.Columns.Add("note");
			dt2.Columns.Add("row");
			dt2.Columns.Add("long");


			foreach (DataGridViewRow DataGVRow in dataGridView1.Rows)
			{
				DataRow dataRow1 = dt2.NewRow();
				// Add's only the columns that you want
				if (DataGVRow.Cells["note"].Value != null || DataGVRow.Cells["note"].Value == "0")
				{
					dataRow1["note"] = DataGVRow.Cells["note"].Value;
					dataRow1["long"] = DataGVRow.Cells["_long"].Value;
					dataRow1["row"] = DataGVRow.Cells["stt"].Value;
					dataRow1["time"] = DataGVRow.Cells["time"].Value;
					dt2.Rows.Add(dataRow1); //dt.Columns.Add();
				}
			}
			DataSet ds = new DataSet();
			ds.Tables.Add(dt1);
			ds.Tables.Add(dt2);
			//Finally the save part:
			XmlWriter xmlWriter = XmlWriter.Create("IdolAudio.xml");
			xmlWriter.Close();
			XmlTextWriter xmlSave = new XmlTextWriter("IdolAudio.xml", Encoding.UTF8);
			xmlSave.WriteStartDocument();
			xmlSave.Formatting = Formatting.Indented;
			xmlSave.WriteStartElement("music");
			ds.DataSetName = "game";
			ds.WriteXml(xmlSave);
			xmlSave.WriteEndElement();
			xmlSave.Close();
			if (textBox1.Text.Length == 0 ||
				textBox1.Text == "0"
				)
			{
				MessageBox.Show("Please Enter Tempo");
			}
			else
			{

				MessageBox.Show("Export Data To XML Succeedfull");
			}

		}

		public string GetString(XElement element)
		{
			return element.ToString().Replace("<" + element.Name + ">", "").Replace("</" + element.Name + ">", "");
		}
		public double CompareLong(string divisions)
		{
			if (divisions == "2")
			{
				_long = 4;
			}
			else if (divisions == "4")
			{
				_long = 2;
			}
			else if (divisions == "8")
			{
				_long = 1;
			}
			else if (divisions == "16")
			{
				_long = 0.5;
			}
			else if (divisions == "24")
			{
				_long = 0.25;
			}

			return _long;
		}

		public int CompareNote(string node)
		{
			if (node == "0")
			{
				note = 0;
			}
			else if (node == "A1")
			{
				note = 1;
			}
			else if (node == "A1#")
			{
				note = 2;
			}
			else if (node == "A1")
			{
				note = 3;
			}
			else if (node == "A1")
			{
				note = 4;
			}
			else if (node == "C1#")
			{
				note = 5;
			}
			else if (node == "D1")
			{
				note = 6;
			}
			else if (node == "D1#")
			{
				note = 7;
			}
			else if (node == "E1")
			{
				note = 8;
			}
			else if (node == "F1")
			{
				note = 9;
			}
			else if (node == "F1#")
			{
				note = 10;
			}
			else if (node == "G1")
			{
				note = 11;
			}
			else if (node == "G1#")
			{
				note = 12;
			}
			else if (node == "A2")
			{
				note = 13;
			}
			else if (node == "A2#")
			{
				note = 14;
			}
			else if (node == "B2")
			{
				note = 15;
			}
			else if (node == "C2")
			{
				note = 16;
			}
			else if (node == "C2#")
			{
				note = 17;
			}
			else if (node == "D2")
			{
				note = 18;
			}
			else if (node == "D2#")
			{
				note = 19;
			}
			else if (node == "E2")
			{
				note = 20;
			}
			else if (node == "F2")
			{
				note = 21;
			}
			else if (node == "F2#")
			{
				note = 22;
			}
			else if (node == "G2")
			{
				note = 23;
			}
			else if (node == "G2#")
			{
				note = 24;
			}
			else if (node == "A3")
			{
				note = 25;
			}

			else if (node == "A3#")
			{
				note = 26;
			}
			else if (node == "B3")
			{
				note = 27;
			}
			else if (node == "C3")
			{
				note = 28;
			}
			else if (node == "C3#")
			{
				note = 29;
			}
			else if (node == "D3")
			{
				note = 30;
			}
			else if (node == "d3#")
			{
				note = 31;
			}
			else if (node == "E3")
			{
				note = 32;
			}
			else if (node == "F3")
			{
				note = 33;
			}
			else if (node == "F3#")
			{
				note = 34;
			}
			else if (node == "G3")
			{
				note = 35;
			}
			else if (node == "G3#")
			{
				note = 36;
			}
			else if (node == "A4")
			{
				note = 37;
			}
			else if (node == "A4#")
			{
				note = 38;
			}
			else if (node == "B4")
			{
				note = 39;
			}
			else if (node == "C4")
			{
				note = 40;
			}
			else if (node == "C4#")
			{
				note = 41;
			}
			else if (node == "D4")
			{
				note = 42;
			}
			else if (node == "D4#")
			{
				note = 43;
			}
			else if (node == "E4")
			{
				note = 44;
			}
			else if (node == "F4")
			{
				note = 45;
			}
			else if (node == "F4#")
			{
				note = 46;
			}
			else if (node == "G4")
			{
				note = 47;
			}
			else if (node == "G4#")
			{
				note = 48;
			}
			else if (node == "C5")
			{
				note = 49;
			}
			else if (node == "C5#")
			{
				note = 50;
			}
			else if (node == "D5")
			{
				note = 51;
			}
			else if (node == "D5#")
			{
				note = 52;
			}
			return note;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string xmlFilePath = openFileDialog.FileName;
				XmlDocument doc = new XmlDocument();
				dataGridView1.Columns.Add("stt", "STT");
				dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[0].ReadOnly = true;

				dataGridView1.Columns.Add("time", "Time");
				dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[1].ReadOnly = true;

				dataGridView1.Columns.Add("node", "Node");
				dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[2].ReadOnly = true;

				dataGridView1.Columns.Add("note", "Note");
				dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[3].ReadOnly = true;

				dataGridView1.Columns.Add("divisions", "Divisions");
				dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[4].ReadOnly = true;

				dataGridView1.Columns.Add("_long", "Long");
				dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dataGridView1.Columns[5].ReadOnly = true;
				doc.Load(xmlFilePath);
				XmlNodeList n = doc.GetElementsByTagName("note");
				for (int j = 0; j < n.Count; j++)
				{
					textBox1.Text = Convert.ToString(n.Count);
				}

				XmlNodeList elemList = doc.GetElementsByTagName("measure");
				for (int i = 0; i < elemList.Count; i++)
				{
					
						//Trường hợp 1
						if 
						(
							elemList[i].FirstChild.FirstChild != null &&
							elemList[i].FirstChild.FirstChild.Name == "divisions"
						)
						{
							if (dataGridView1.Rows.Count == 0)
							{
							
								XmlNodeList notes = elemList[i].SelectNodes("note");
								for (int j = 0; j < notes.Count; j++)
								{
								
									if (notes[j].FirstChild.Name == "rest")
									{
										DataGridViewRow row = new DataGridViewRow();
										dataGridView1.Rows.Add(row);
										this.dataGridView1.Rows[0].Cells["node"].Value = "0";
										this.dataGridView1.Rows[0].Cells["note"].Value = "0";

										this.dataGridView1.Rows[0].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
										string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
										this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
										this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
										this.dataGridView1.Rows[0].Cells["time"].Value = "0";
									
									}
									else if (notes[j].FirstChild.Name == "pitch")
									{
										if (notes[j].FirstChild.FirstChild.NextSibling.Name == "alter")
										{
											DataGridViewRow row = new DataGridViewRow();
											dataGridView1.Rows.Add(row);
											this.dataGridView1.Rows[0].Cells["node"].Value = 
												notes[j].FirstChild.FirstChild.InnerText + 
												Convert.ToString( Convert.ToInt32(notes[j].FirstChild.LastChild.InnerText) - 2)+ "#";
											string node = this.dataGridView1.Rows[0].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[0].Cells["note"].Value = Convert.ToString(CompareNote(node));

											this.dataGridView1.Rows[0].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
											string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
											this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
											this.dataGridView1.Rows[0].Cells["time"].Value = "0";
										}
										else if (notes[j].FirstChild.FirstChild.NextSibling.Name != "alter")
										{
											DataGridViewRow row = new DataGridViewRow();
											dataGridView1.Rows.Add(row);
											this.dataGridView1.Rows[0].Cells["node"].Value = 
												notes[j].FirstChild.FirstChild.InnerText + 
												Convert.ToString(Convert.ToInt32(notes[j].FirstChild.LastChild.InnerText) - 2);
											string node = this.dataGridView1.Rows[0].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[0].Cells["note"].Value = Convert.ToString(CompareNote(node));

											this.dataGridView1.Rows[0].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
											string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
											this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
											this.dataGridView1.Rows[0].Cells["time"].Value = "0";
										
										}
									
									}
									else
									{
										MessageBox.Show("Error!!! Please call Dev to fix bug!!!");

									}
								}
							}
							else if (dataGridView1.Rows.Count > 0)
							{
								if (
									dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value == null ||
									dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["_long"].Value == null
								)
								{
									MessageBox.Show("Check Again Cell Values!!!");
								}

								else if (
									dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value != null ||
									dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value != null ||
									dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value != null
									)
								{
									//textBox1.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value.ToString();
									//Get value of column stt, time, _long in row before current row in run,
									int stt = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value.ToString());
									double time = double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value.ToString());
									double _long = double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value.ToString());
								
									XmlNodeList notes2 = elemList[i].SelectNodes("note");
									for (int j = 0; j < notes2.Count; j++)
									{
										if (notes2[j].FirstChild.Name == "rest")
										{
											dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value = "0";
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = "0";

											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
											string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
										
										}
										else if (notes2[j].FirstChild.Name == "pitch")
										{
											if (notes2[j].FirstChild.FirstChild.NextSibling.Name == "alter")
											{
												dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value =
													notes2[j].FirstChild.FirstChild.InnerText +
													Convert.ToString(Convert.ToInt32(notes2[j].FirstChild.LastChild.InnerText) - 2) + "#";
												string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = Convert.ToString(CompareNote(node));

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
												string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
											}
											else if (notes2[j].FirstChild.FirstChild.NextSibling.Name != "alter")
											{
												dataGridView1.Rows.Insert(dataGridView1.Rows.Count);
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value = 
													notes2[j].FirstChild.FirstChild.InnerText + 
													Convert.ToString(Convert.ToInt32(notes2[j].FirstChild.LastChild.InnerText) - 2);
												string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = CompareNote(node);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
												string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
											}
										
										
										}
										else if (notes2[j].FirstChild.Name == "chord")
										{
											if (notes2[j].FirstChild.NextSibling.Name == "pitch" &&
												notes2[j].FirstChild.NextSibling.FirstChild.NextSibling.Name == "alter")
											{
												dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value = 
													notes2[j].FirstChild.NextSibling.FirstChild.InnerText + 
													Convert.ToString(Convert.ToInt32(notes2[j].FirstChild.NextSibling.LastChild.InnerText) - 2)  + "#";
												string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = Convert.ToString(CompareNote(node));

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value;

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
												string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
											}
											else if (
												notes2[j].FirstChild.NextSibling.Name == "pitch" &&
												notes2[j].FirstChild.NextSibling.FirstChild.NextSibling.Name != "alter")
											{
												dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value = 
													notes2[j].FirstChild.NextSibling.FirstChild.InnerText + 
													Convert.ToString(Convert.ToInt32(notes2[j].FirstChild.NextSibling.LastChild.InnerText) - 2);
												string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = CompareNote(node);

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value;

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = elemList[i].FirstChild.FirstChild.InnerText;
												string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

												this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
											}
										
										
										}
										else
										{
											MessageBox.Show("Error!!! Please call Dev to fix bug!!!");

										}
									}
							}

						}
						
						}
						//Trường hợp 2
						else if 
						(
							elemList[i].FirstChild != null ||
							elemList[i].FirstChild.Name == "note"
						)
						{
							if (dataGridView1.Rows.Count == 0)
						{

							XmlNodeList notes = elemList[i].SelectNodes("note");
							for (int j = 0; j < notes.Count; j++)
							{

								if (notes[j].FirstChild.Name == "rest")
								{
									DataGridViewRow row = new DataGridViewRow();
									dataGridView1.Rows.Add(row);
									this.dataGridView1.Rows[0].Cells["node"].Value = "0";
									this.dataGridView1.Rows[0].Cells["note"].Value = "0";

									this.dataGridView1.Rows[0].Cells["divisions"].Value = "1";
									string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
									this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
									this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
									this.dataGridView1.Rows[0].Cells["time"].Value = "0";
									
								}
								else if (notes[j].FirstChild.Name == "pitch")
								{
									if (notes[j].FirstChild.FirstChild.NextSibling.Name == "alter")
									{
										DataGridViewRow row = new DataGridViewRow();
										dataGridView1.Rows.Add(row);
										this.dataGridView1.Rows[0].Cells["node"].Value = 
											notes[j].FirstChild.FirstChild.InnerText + 
											Convert.ToString(Convert.ToInt32(notes[j].FirstChild.LastChild.InnerText) -2 )+ "#";
										string node = this.dataGridView1.Rows[0].Cells["node"].Value.ToString();
										this.dataGridView1.Rows[0].Cells["note"].Value = Convert.ToString(CompareNote(node));
									
										this.dataGridView1.Rows[0].Cells["divisions"].Value = "1";
										string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
										this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
										this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
										this.dataGridView1.Rows[0].Cells["time"].Value = "0";
									}
									else if (notes[j].FirstChild.FirstChild.NextSibling.Name != "alter")
									{
										DataGridViewRow row = new DataGridViewRow();

										dataGridView1.Rows.Add(row);
										this.dataGridView1.Rows[0].Cells["node"].Value = 
											notes[j].FirstChild.FirstChild.InnerText + 
											Convert.ToString(Convert.ToInt32(notes[j].FirstChild.LastChild.InnerText) - 2);
										string node = this.dataGridView1.Rows[0].Cells["node"].Value.ToString();
										this.dataGridView1.Rows[0].Cells["note"].Value = Convert.ToString(CompareNote(node));

										this.dataGridView1.Rows[0].Cells["divisions"].Value = "1";
										string divisions = this.dataGridView1.Rows[0].Cells["divisions"].Value.ToString();
										this.dataGridView1.Rows[0].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));
										this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
										this.dataGridView1.Rows[0].Cells["time"].Value = "0";
									}
									
									
								}
								else
								{
									MessageBox.Show("Error 1");

								}
							}
						}
							else if (dataGridView1.Rows.Count > 0)
						{
							if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value != null ||
								dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value != null ||
								dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value != null
								)
							{
								//textBox1.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value.ToString();
								//Get value of column stt, time, _long in row before current row in run,
								int stt = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value.ToString());
								double time = double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value.ToString());
								double _long = double.Parse(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value.ToString());

								XmlNodeList notes3 = elemList[i].SelectNodes("note");
								for (int j = 0; j < notes3.Count; j++)
								{
									if (notes3[j].FirstChild.Name == "rest")
									{
										//add row
										dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

										//note
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value = "0";
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = "0";

										//time
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

										//long
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["divisions"].Value;
										string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

										//row
										this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);

									}
									else if (notes3[j].FirstChild.Name == "pitch")
									{
										if (notes3[j].FirstChild.FirstChild.NextSibling.Name == "alter")
										{
											//add row
											dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

											//note
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value =
												notes3[j].FirstChild.FirstChild.InnerText +
												Convert.ToString(Convert.ToInt32(notes3[j].FirstChild.LastChild.InnerText) - 2) + "#";

											string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = Convert.ToString(CompareNote(node));

											//time
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

											//long
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["divisions"].Value;
											string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

											//row
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
										}
										else if (notes3[j].FirstChild.FirstChild.NextSibling.Name != "alter")
										{
											//add row
											dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

											//note
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value =
												notes3[j].FirstChild.FirstChild.InnerText +
												Convert.ToString(Convert.ToInt32(notes3[j].FirstChild.LastChild.InnerText) - 2);
											string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = CompareNote(node);

											//time
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

											//long
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["divisions"].Value;
											string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

											//row
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
										}


									}
									else if (notes3[j].FirstChild.Name == "chord")
									{

										if (notes3[j].FirstChild.NextSibling.Name == "pitch" &&
											notes3[j].FirstChild.NextSibling.FirstChild.NextSibling.Name == "alter"
											)
										{
											//add row
											dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

											//note
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value =
												notes3[j].FirstChild.NextSibling.FirstChild.InnerText +
												Convert.ToString(Convert.ToInt32(notes3[j].FirstChild.NextSibling.LastChild.InnerText) - 2) + "#";
											string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = Convert.ToString(CompareNote(node));

											//time
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + _long);

											//long
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["divisions"].Value;
											string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

											//row
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
										}
										else if
											(
											notes3[j].FirstChild.NextSibling.Name == "pitch" &&
											notes3[j].FirstChild.NextSibling.FirstChild.NextSibling.Name != "alter"
											)
										{
											//add row
											dataGridView1.Rows.Insert(dataGridView1.Rows.Count);

											////note
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value =
												notes3[j].FirstChild.NextSibling.FirstChild.InnerText +
												Convert.ToString(Convert.ToInt32(notes3[j].FirstChild.NextSibling.LastChild.InnerText) - 2);
											string node = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["note"].Value = CompareNote(node);

											//time
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value;

											//long
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value = this.dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["divisions"].Value;
											string divisions = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["divisions"].Value.ToString();
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["_long"].Value = Convert.ToString(CompareLong(divisions));

											//row
											this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
										}
									}

								}

							}
						}
						}
					
				}
				
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		public void button3_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{


		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button2.PerformClick();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
			{
				dataGridView1.Rows.RemoveAt(item.Index);
			}
		}
	}
}
