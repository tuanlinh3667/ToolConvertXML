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
			dt2.Columns.Add("note");
			dt2.Columns.Add("long");

			
			foreach (DataGridViewRow DataGVRow in dataGridView1.Rows)
			{
				DataRow dataRow1 = dt2.NewRow();
				// Add's only the columns that you want
				if (DataGVRow.Cells["note1"].Value != null || DataGVRow.Cells["note1"].Value == "0")
				{
					dataRow1["time"] = DataGVRow.Cells["time"].Value;
					dataRow1["note"] = DataGVRow.Cells["note1"].Value;
					dataRow1["long"] = DataGVRow.Cells["long1"].Value;
					dt2.Rows.Add(dataRow1); //dt.Columns.Add();
				}

				DataRow dataRow2 = dt2.NewRow();
				if (DataGVRow.Cells["note2"].Value != null || DataGVRow.Cells["note2"].Value == "0")
				{
					dataRow2["time"] = DataGVRow.Cells["time"].Value;
					dataRow2["note"] = DataGVRow.Cells["note2"].Value;
					dataRow2["long"] = DataGVRow.Cells["long2"].Value;
					dt2.Rows.Add(dataRow2); //dt.Columns.Add();
				}

				DataRow dataRow3 = dt2.NewRow();
				if (DataGVRow.Cells["note3"].Value != null || DataGVRow.Cells["note3"].Value == "0")
				{
					dataRow3["time"] = DataGVRow.Cells["time"].Value;
					dataRow3["note"] = DataGVRow.Cells["note3"].Value;
					dataRow3["long"] = DataGVRow.Cells["long3"].Value;
					dt2.Rows.Add(dataRow3); //dt.Columns.Add();
				}

				//dt.Rows.Add(dataRow); //dt.Columns.Add();
			}
			DataSet ds = new DataSet();
			ds.Tables.Add(dt1);
			ds.Tables.Add(dt2);
			//Finally the save part:
			XmlWriter xmlWriter = XmlWriter.Create("Sample.xml");
			xmlWriter.Close();
			XmlTextWriter xmlSave = new XmlTextWriter("Sample.xml", Encoding.UTF8);
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
				dataGridView1.Rows.Insert(dataGridView1.Rows.Count);
				if (dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value != null ||
					dataGridView1.Rows[dataGridView1.Rows.Count -2].Cells["long1"].Value != null ||
					dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long2"].Value != null ||
					dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long3"].Value != null ||
					dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["stt"].Value != null
					)
				{
					int stt = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["stt"].Value.ToString());
					int time = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["time"].Value.ToString());
					int longInt1 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count -2].Cells["long1"].Value.ToString());
					int longInt2 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long2"].Value.ToString());
					int longInt3 = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["long3"].Value.ToString());
					this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stt"].Value = Convert.ToString(stt += 1);
					if (longInt1 > longInt2 && longInt1 > longInt3)
					{
						this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt1);
					}
					else if (longInt2 > longInt1 && longInt2 > longInt3)
					{
						this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt2);
					}
					else if (longInt3 > longInt1 && longInt3 > longInt2)
					{
						this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["time"].Value = Convert.ToString(time + longInt3);
					}
					else
					{
						MessageBox.Show("check cell long");
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
			dataGridView1.Columns.Add("time", "Time");
			dataGridView1.Columns.Add("note1", "Note1");
			dataGridView1.Columns.Add("note2", "Note2");
			dataGridView1.Columns.Add("note3", "Note3");
			dataGridView1.Columns.Add("long1", "Long1");
			dataGridView1.Columns.Add("long2", "Long2");
			dataGridView1.Columns.Add("long3", "Long3");
		}
	}
}
