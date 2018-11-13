using SFS_FV.Local;
using SFS_FV.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFS_FV
{
    public partial class NewVariable : Form
    {
        Form1 fm1 = new Form1();
        public NewVariable(Form1 Form1)
        {
            InitializeComponent();
            this.fm1 = Form1;
        }
        SQLITE cSQL = new SQLITE();
        private void LoadData(string Tab)
        {

            dt = cSQL.SQL_Table("*", "" + Tab + "", "");
            fm1.dtEdit.Columns.Clear();
            fm1.dtEdit.DataSource = dt;
            for (int i = 0; i < fm1.dtEdit.Columns.Count; i++)
            {
                fm1.dtEdit.Columns[i].Width = 80;
            }
          
            /*
            if (Tab == "TYPE")
            {
                cbType.DataSource = new BindingSource(SQL_List(0, dt), null);
                cbType.SelectedIndex = -1;
            }
            else if (Tab == "CO")
            {
                cbCo.DataSource = new BindingSource(SQL_List(1, dt), null);
                cbCo.SelectedIndex = -1;
            }
            else if (Tab == "MOD")
            {
            }
            else if (Tab == "AREA")
            {

             //   cbArea.DataSource = new BindingSource(SQL_List(1, dt), null);
              //  cbArea.SelectedIndex = -1;
            }
            else if (Tab == "BIT")
            {

                cbBit.DataSource = new BindingSource(SQL_List(1, dt), null);
                cbBit.SelectedIndex = -1;
            }*/
        }
        private void btnAddVari_Click(object sender, EventArgs e)
        {
            G.sourceSQL = G.VariableSQL;
            if (typeVariable == typeVariable2.CycleTime)
            {
                {
                    if (!cSQL.CHECK("*", "CycleTime", "NAME='" + txtNameVari.Text.Trim() + "' "))
                    {
                      
                        DateTime dt = new DateTime();
                        List<Point> pDrawing = new List<Point>();
                        G.ListVariables.Add(new ListVariables(new CycleTime(txtNameNew.Text, G.ListVariables[txtNameVari.SelectedIndex], "0", 0, Convert.ToInt32(numScan_change_V.Value), dt, dt, isCycle.open, false), typeVariable2.CycleTime));
                        List<string> List = new List<string>();
                        List.Add(txtNameNew.Text);
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.ListVariables.Name);
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.cycleTime);
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.tempValue + "");
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.numScan + "");
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.dtBegin + "");
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.dtEnd + "");
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.isCycle.ToString() + "");
                        List.Add(G.ListVariables[G.ListVariables.Count - 1].CycleTime.blStartCycle + "");                     
                        cSQL.Insert("CycleTime", List);
                        LoadData("CycleTime");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập tên khác!");
                    }
                }
            }
            else if (typeVariable == typeVariable2.Global)
            {
                if (!cSQL.CHECK("*", "Global", "NAME='" + txtNameVari.Text.Trim() + "' "))
                {
                    if (!cSQL.CHECK("*", "Global", "AREA='" + cbArea.Text.Trim() + "' AND BIT ='" + txtbit.Text.Trim() + "AND DEVICE ='" + cbDevice.Text.Trim() + "'"))
                    {
                        //dynamic itArea = cbArea.Items[cbArea.SelectedIndex];
                        dynamic itTypeBit = cbTypeBit.Items[cbTypeBit.SelectedIndex];

                        typeBit typeBit = (typeBit)int.Parse(itTypeBit.Value);
                        G.ListVariables.Add(new ListVariables(txtNameVari.Text, G.LisPLC[cbDevice.SelectedIndex], cbArea.Text.Trim(), txtbit.Text.Trim(), txtVal.Text, isBit._using, typeBit, typeVariable2.Global));
                        List<string> List = new List<string>();
                        List.Add(txtNameVari.Text);
                        List.Add(G.LisPLC[cbDevice.SelectedIndex].name);
                        List.Add(cbArea.Text.Trim());
                        List.Add(txtbit.Text.Trim());
                        List.Add(typeBit.ToString());
                        List.Add(txtVal.Text);
                        List.Add(isBit._using.ToString());
                        cSQL.Insert("Global", List);
                        LoadData("Global");
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn Bit khác!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên khác!");
                }
            }
            else if (typeVariable == typeVariable2.Yield)
            {
                if (!cSQL.CHECK("*", "Yield", "NAME='" + txtNameVari.Text.Trim() + "' "))
                {
                    //  cmd.CommandText = " CREATE TABLE Yield (NAME nvachar(50),Yield nvachar(50),ListOK nvachar(50),ListNG nvachar(50));"; //gancau lech cmd
                    // cmd.ExecuteNonQuery();//thuc thi

                    DateTime dt = new DateTime();
                    List<Point> pDrawing = new List<Point>();
                    G.ListVariables.Add(new ListVariables(new Yield(txtNameNew.Text, "100", ListYieldOK, ListYieldNG), typeVariable2.Yield));
                    List<string> List = new List<string>();
                    string ListOKsql="", ListNGsql="";
                    foreach(ListVariables s in ListYieldOK)
                    {
                        ListOKsql += s.Name + ",";
                    }
                    ListOKsql = ListOKsql.Substring(0, ListOKsql.Count() - 1);
                    foreach (ListVariables s in ListYieldNG)
                    {
                        ListNGsql += s.Name + ",";
                    }
                    ListNGsql = ListNGsql.Substring(0, ListNGsql.Count() - 1);
                    List.Add(txtNameNew.Text);
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].Yield.valYield);
                    List.Add(ListOKsql);
                    List.Add(ListNGsql);
                  
                    cSQL.Insert("Yield", List);
                    LoadData("Yield");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên khác!");
                }
                   }
            else if (typeVariable == typeVariable2.LostTime)
            {
                if (!cSQL.CHECK("*", "LostTime", "NAME='" + txtNameVari.Text.Trim() + "' "))
                {

                    DateTime dt = new DateTime();
                    List<Point> pDrawing = new List<Point>();
                    //(new LostTime(txtNameNew.Text, G.ListVariables[txtNameVari.SelectedIndex], "0", 0, Convert.ToInt32(numScan_change_V.Value), dt, dt, isLost.open, false), typeVariable.LosTime)
                    G.ListVariables.Add(new ListVariables(new LostTime(txtNameNew.Text, G.ListVariables[txtNameVari.SelectedIndex], "0", 0, Convert.ToInt32(numScan_change_V.Value), dt, dt, isLost.open, false), typeVariable2.LostTime));
                    List<string> List = new List<string>();
                    List.Add(txtNameNew.Text);
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.ListVariables.Name);
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.LostTimes);
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.tempValue + "");
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.timeMax + "");
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.dtBegin + "");
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.dtEnd + "");
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.isLost.ToString() + "");
                    List.Add(G.ListVariables[G.ListVariables.Count - 1].LostTime.blStart + "");
                    cSQL.Insert("LostTime", List);
                    LoadData("LostTime");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên khác!");
                }
            }
        }

        private void NewVariable_Load(object sender, EventArgs e)
        {
           // txtCalculator.SelectionStart += txtCalculator.SelectionLength;
            this.Location = new Point(G.pForm1.X + 10, G.pForm1.Y + 90);
            cbTypeBit.Items.Clear();
            cbTypeBit.DisplayMember = "Text";
            cbTypeBit.ValueMember = "Value";
            cbTypeBit.Items.Add(new { Text = "ints", Value = "0" });
            cbTypeBit.Items.Add(new { Text = "strings", Value = "1" });
           cbDevice.Items.Clear();
           cbDevice.DisplayMember = "Text";
           cbDevice.ValueMember = "Value";
            for (int i = 0; i < G.LisPLC.Count(); i++)
            {
               cbDevice.Items.Add(new { Text = G.LisPLC[i].name, Value = i + "" });
            }
            cbDevice.SelectedIndex = -1;
        }
        DataTable dt;
        List<string> LisDevice;
        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LisDevice = new List<string>();
            dt = new DataTable();
            G.sourceSQL = G.defautSQL;
            dt = cSQL.SQL_Table("AREA", "AREA", "MOD='"+G.LisPLC[cbDevice.SelectedIndex].Mod+"'");
            LisDevice= cSQL.SQL_List(0, dt);

            cbArea.Items.Clear();
            cbArea.DisplayMember = "Text";
            cbArea.ValueMember = "Value";
            foreach (string s in LisDevice)
            {
                cbArea.Items.Add(new { Text = s, Value = 0 + "" });
            }
          //  G.sourceSQL = G.defautSQL;
            G.sourceSQL = G.VariableSQL;
        }

        private void NewVariable_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void NewVariable_Shown(object sender, EventArgs e)
        {
            cbType.DataSource = Enum.GetValues(typeof(typeVariable2));
            txtNameVari.Items.Clear();
            foreach (ListVariables ListVariables in G.ListVariables)
            {
                if(ListVariables.Name!=null)
                txtNameVari.Items.Add(ListVariables.Name);
            }
            txtNameVari.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            }
        List<ListVariables> ListYieldOK = new List<ListVariables>();
        List<ListVariables> ListYieldNG = new List<ListVariables>();
        private void btnNGplus_Click(object sender, EventArgs e)
        {
            ListYieldNG.Add(G.ListVariables[txtNameVari.SelectedIndex]);
            listNG.Items.Add(txtNameVari.Text);
            //txtCalculator.Text += btnNGplus.Text;
        }

        private void btnOKplus_Click(object sender, EventArgs e)
        {
            ListYieldOK.Add(G.ListVariables[txtNameVari.SelectedIndex]);
            listOK.Items.Add(txtNameVari.Text);
        }
        typeVariable2 typeVariable;
        
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeVariable=(typeVariable2)Enum.Parse(typeof(typeVariable2),cbType.Text);
           if(typeVariable==typeVariable2.Global)
            {
                listNG.Enabled = false;
                listOK.Enabled = false;
                
                numScan_change_V.Enabled = false;
                txtNameNew.Enabled = false;
                cbDevice.Enabled = true;
                cbArea.Enabled = true;
                cbTypeBit.Enabled = true;
                txtbit.Enabled = true;
                txtVal.Enabled = true;
                txtNameVari.Enabled = true;
            }
           else if(typeVariable == typeVariable2.CycleTime)
            {
                listNG.Enabled = false;
                listOK.Enabled = false;
              
                numScan_change_V.Enabled = true;
                txtNameNew.Enabled = true;
                cbDevice.Enabled = false;
                cbArea.Enabled = false;
                cbTypeBit.Enabled = false;
                txtbit.Enabled = false;
                txtVal.Enabled = false;
                txtNameVari.Enabled = true;
              //  txtNameVari.DataSource = G.ListVariables[].Name;
            }
            else if (typeVariable == typeVariable2.LostTime)
            {
                listNG.Enabled = false;
                listOK.Enabled = false;
               
                numScan_change_V.Enabled = true;
                txtNameNew.Enabled = true;
                cbDevice.Enabled = false;
                cbArea.Enabled = false;
                cbTypeBit.Enabled = false;
                txtbit.Enabled = false;
                txtVal.Enabled = false;
                txtNameVari.Enabled = true;
                //  txtNameVari.DataSource = G.ListVariables[].Name;
            }
            else if (typeVariable == typeVariable2.Yield)
            {
                listNG.Enabled = true;
                listOK.Enabled = true;
               
                numScan_change_V.Enabled = true;
                txtNameNew.Enabled = true;
                cbDevice.Enabled = false;
                cbArea.Enabled = false;
                cbTypeBit.Enabled = false;
                txtbit.Enabled = false;
                txtVal.Enabled = false;
                txtNameVari.Enabled = true;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void btnNGsub_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOKsub_Click(object sender, EventArgs e)
        {
          
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.sourceSQL = G.VariableSQL;
        }

        private void txtNameVari_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            //txtCalculator.Text += txtNameVari.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void txtNameNew_TextChanged(object sender, EventArgs e)
        {
           
           
        }
    }
}
