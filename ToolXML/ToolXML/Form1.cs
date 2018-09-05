using System;
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

namespace ToolXML
{
	public partial class Form1 : Form
	{
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
			dt2.Columns.Add("node");
			dt2.Columns.Add("long");

			
			foreach (DataGridViewRow DataGVRow in dataGridView1.Rows)
			{
				DataRow dataRow1 = dt2.NewRow();
				// Add's only the columns that you want
				if (DataGVRow.Cells["node1"].Value != null || DataGVRow.Cells["node1"].Value == "0")
				{
					dataRow1["node"] = DataGVRow.Cells["node1"].Value;
					dataRow1["long"] = DataGVRow.Cells["long1"].Value;
					dataRow1["time"] = DataGVRow.Cells["time"].Value;
					dt2.Rows.Add(dataRow1); //dt.Columns.Add();
				}

				DataRow dataRow2 = dt2.NewRow();
				if (DataGVRow.Cells["node2"].Value != null || DataGVRow.Cells["node2"].Value == "0")
				{
					dataRow2["node"] = DataGVRow.Cells["node2"].Value;
					dataRow2["long"] = DataGVRow.Cells["long2"].Value;
					dataRow2["time"] = DataGVRow.Cells["time"].Value;
					dt2.Rows.Add(dataRow2); //dt.Columns.Add();
				}

				DataRow dataRow3 = dt2.NewRow();
				if (DataGVRow.Cells["node3"].Value != null || DataGVRow.Cells["node3"].Value == "0")
				{	
					dataRow3["node"] = DataGVRow.Cells["node3"].Value;
					dataRow3["long"] = DataGVRow.Cells["long3"].Value;
					dataRow3["time"] = DataGVRow.Cells["time"].Value;
					dt2.Rows.Add(dataRow3); //dt.Columns.Add();
				}

				//dt.Rows.Add(dataRow); //dt.Columns.Add();
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
		

		private void button2_Click(object sender, EventArgs e)
		{
			
			if (dataGridView1.Rows.Count == 0)
			{
				DataGridViewRow row = new DataGridViewRow();
				dataGridView1.Rows.Add(row);

				this.dataGridView1.Rows[0].Cells["time"].Value = "0";
				this.dataGridView1.Rows[0].Cells["stt"].Value = "1";
			}
			else if (dataGridView1.Rows.Count > 0)
			{
					if (
						dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["node1"].Value == null ||
						dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long1"].Value == null
					)
					{
						MessageBox.Show("Check Again Cell Values!!!");
					}
					else if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long1"].Value == null)
							
						{
							this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long1"].Value = "0";
						}
				else if (
						dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long2"].Value == null
						)
				{
					this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long2"].Value = "0";
				}
				else if (
					dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long3"].Value == null
					)
				{
					this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["long3"].Value = "0";
				}
				else if (
							dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value != null ||
							
							dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value != null
						)
						{
						dataGridView1.Rows.Insert(dataGridView1.Rows.Count);
						int stt = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["stt"].Value.ToString());
						int time = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value.ToString());
						int longInt1 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long1"].Value.ToString());
						int longInt2 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long2"].Value.ToString());
						int longInt3 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long3"].Value.ToString());
						this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
						if (longInt1 >= longInt2 && longInt1 > longInt3)
						{
							this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt1);
						}
						else if (longInt2 > longInt1 && longInt2 >= longInt3)
						{
							this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt2);
						}
						else if (longInt3 >= longInt1 && longInt3 > longInt2)
						{
							this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt3);
						}
						else if (longInt1 == longInt2 && longInt2 == longInt3)
						{
							this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt1);
						}
						else
						{
							MessageBox.Show("Check cell long");
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
			dataGridView1.Columns.Add("stt", "STT");
			dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns[0].ReadOnly = true;
			dataGridView1.Columns.Add("time", "Time");
			dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns[1].ReadOnly = true;
			dataGridView1.Columns.Add("node1", "Node1");
			dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns.Add("node2", "Node2");
			dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns.Add("node3", "Node3");
			dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns.Add("long1", "Long1");
			dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns.Add("long2", "Long2");
			dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns.Add("long3", "Long3");
			dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.KeyPreview = true;
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
