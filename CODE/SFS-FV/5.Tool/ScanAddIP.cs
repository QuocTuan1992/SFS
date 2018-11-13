using NetUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFS_FV
{
    public partial class ScanAddIP : Form
    {
        private IPScanner _scanner;
        public ScanAddIP()
        {
            
            InitializeComponent();
            _scanner = new IPScanner(64, 2, false, 1500, 32, false, 32);

            _scanner.OnAliveHostFound += new IPScanner.AliveHostFoundDelegate(_scanner_OnAliveHostFound);

            _scanner.OnStartScan += new IPScanner.ScanStateChangeDelegate(_scanner_OnStartScan);
            _scanner.OnStopScan += new IPScanner.ScanStateChangeDelegate(_scanner_OnStopScan);
            _scanner.OnRestartScan += new IPScanner.ScanStateChangeDelegate(_scanner_OnRestartScan);
            _scanner.OnScanProgressUpdate += new IPScanner.ScanProgressUpdateDelegate(_scanner_OnScanProgressUpdate);

        }
        
        private void EnableSettings(bool enable)
        {

            if (enable)
            {
                _prgScanProgress.Text = "Scanner is not running!";
                this.Close();
            }

        }
        private void _scanner_OnStopScan(IPScanner scanner)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnStopScan), scanner);
                return;
            }

            EnableSettings(true);

            AddLogEntry("Scanning has been stopped!");
            AddLogEntry("Hosts found: " + _scanner.AliveHosts.Count);

            _prgScanProgress.Value = 0;
        }
        void host_OnHostNameAvailable(IPScanHostState host)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanHostState.HostNameAvailableDelegate(host_OnHostNameAvailable), host);
                return;
            }

            ListViewItem item = FindListViewItem(host);
            if (item != null)
                item.SubItems[4].Text = host.HostName;
        }
        private ListViewItem FindListViewItem(IPScanHostState host)
        {
            foreach (ListViewItem item in _lvAliveHosts.Items)
            {
                if (item.Tag == host)
                    return item;
            }

            return null;
        }
        private void _scanner_OnStartScan(IPScanner scanner)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnStartScan), scanner);
                return;
            }

            foreach (ListViewItem item in _lvAliveHosts.Items)
            {
                ((IPScanHostState)item.Tag).OnStateChange -= host_OnStateChange;
                ((IPScanHostState)item.Tag).OnHostNameAvailable -= host_OnHostNameAvailable;
            }

            _lvAliveHosts.Items.Clear();
            lbLog.Items.Clear();

            //	_btnAddHost.Enabled = _btnTrace.Enabled = false;

            AddLogEntry("Scanning has been started!");

            _prgScanProgress.Value = 0;

            EnableSettings(false);
        }
        private void AddLogEntry(string message)
        {
            lbLog.Items.Add(DateTime.Now.ToString("[HH:mm:ss]: ") + message);
            lbLog.TopIndex = lbLog.Items.Count - lbLog.Height / lbLog.ItemHeight;
        }
        void _scanner_OnRestartScan(IPScanner scanner)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanStateChangeDelegate(_scanner_OnRestartScan), scanner);
                return;
            }

            AddLogEntry("Scan pass has been finished!");
            AddLogEntry("Hosts found: " + _scanner.AliveHosts.Count);
            AddLogEntry("Restarting Scan!");

            _prgScanProgress.Value = 0;
        }
        void _scanner_OnScanProgressUpdate(IPScanner scanner, IPAddress currentAddress, ulong progress, ulong total)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanner.ScanProgressUpdateDelegate(_scanner_OnScanProgressUpdate), scanner, currentAddress, progress, total);
                return;
            }

            int prog = (int)((100 * progress) / total);
            _prgScanProgress.Value = prog;
            _prgScanProgress.Text = prog.ToString() + "%" + " [" + currentAddress.ToString() + "]";
        }
        private void host_OnStateChange(IPScanHostState host, IPScanHostState.State oldState)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanHostState.StateChangeDelegate(host_OnStateChange), host, oldState);
                return;
            }

            if (!host.IsTesting())
            {
                ListViewItem item = FindListViewItem(host);
                if (item != null)
                {
                    if (host.IsAlive())
                    {
                        item.ImageIndex = (int)host.QualityCategory;
                        item.SubItems[2].Text = host.AvgResponseTime.ToString("F02") + " ms";
                        item.SubItems[3].Text = ((float)(host.LossCount) / host.PingsCount).ToString("P");
                    }
                    else
                    {
                        AddLogEntry("Host [" + host.Address.ToString() + "] died.");

                        host.OnStateChange -= host_OnStateChange;
                        host.OnHostNameAvailable -= host_OnHostNameAvailable;

                        item.BackColor = Color.IndianRed;

                        System.Windows.Forms.Timer removeTimer = new System.Windows.Forms.Timer();
                        removeTimer.Tag = item;
                        removeTimer.Interval = 2000;
                        removeTimer.Tick += new EventHandler(removeTimer_Tick);

                        removeTimer.Enabled = true;
                    }
                }
            }
        }
        void removeTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;

            timer.Stop();
            timer.Tick -= newTimer_Tick;

            ListViewItem item = (ListViewItem)timer.Tag;
            _lvAliveHosts.Items.Remove(item);
           
        }
        void newTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;

            timer.Stop();
            timer.Tick -= newTimer_Tick;

            ListViewItem item = (ListViewItem)timer.Tag;
            item.BackColor = Color.White;
        }
        private void _scanner_OnAliveHostFound(IPScanner scanner, IPScanHostState host)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new IPScanner.AliveHostFoundDelegate(_scanner_OnAliveHostFound), scanner, host);
                return;
            }

            ListViewItem item = new ListViewItem();
            item.Tag = host;

            item.BackColor = Color.GreenYellow;
            item.SubItems.Add(host.Address.ToString());
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            G.ListIp.Add(host.Address.ToString());
            G.ListIp.Distinct().ToList();
            _lvAliveHosts.Items.Add(item);
            _lvAliveHosts.Sort();

            host.OnHostNameAvailable += new IPScanHostState.HostNameAvailableDelegate(host_OnHostNameAvailable);
            host.OnStateChange += new IPScanHostState.StateChangeDelegate(host_OnStateChange);

            if (!host.IsTesting())
            {
                item.ImageIndex = (int)host.QualityCategory;
                item.SubItems[2].Text = host.AvgResponseTime.ToString("F02") + " ms";
                item.SubItems[3].Text = ((float)(host.LossCount) / host.PingsCount).ToString("P");
                item.SubItems[4].Text = host.HostName;
            }

            AddLogEntry("Host [" + host.Address.ToString() + "] is alive.");

            System.Windows.Forms.Timer newTimer = new System.Windows.Forms.Timer();
            newTimer.Tag = item;
            newTimer.Interval = 2000;
            newTimer.Tick += new EventHandler(newTimer_Tick);

            newTimer.Enabled = true;
        }
        private void ScanAddIP_Load(object sender, EventArgs e)
        {

        }

      

        private void _lvAliveHosts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bntScan_Click(object sender, EventArgs e)
        {
            if (!_scanner.Active)
            {
                G.ListIp.Clear();
                G.portIP = ":"+txtPortIp.Text;
                try
                {
                    _scanner.Start(
                        new IPScanRange(IPAddress.Parse(_tbRangeStart.Text), IPAddress.Parse(_tbRangeEnd.Text)));
                }
                catch (FormatException)
                {
                    MessageBox.Show(this, "Cannot parse IP range or subnetmask!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                _scanner.Stop(false);
        }

        private void ScanAddIP_Load_1(object sender, EventArgs e)
        {

        }
     //   Form1 fm1 = new Form1();
      
        private void ScanAddIP_Load_2(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(G.pForm1.X +10, G.pForm1.Y  + G.pNewDevice.Y+80);
            string[] addIp = G.AddIPLoacal.Split('.');
            _tbRangeStart.Text = addIp[0] + "." + addIp[1] + "." + addIp[2] + ".0";
            _tbRangeEnd.Text = addIp[0] + "." + addIp[1] + "." + addIp[2] + ".255";
            if (!_scanner.Active)
            {
                G.ListIp.Clear();
                G.portIP = ":" + txtPortIp.Text;
                try
                {
                    _scanner.Start(
                        new IPScanRange(IPAddress.Parse(_tbRangeStart.Text), IPAddress.Parse(_tbRangeEnd.Text)));
                }
                catch (FormatException)
                {
                    MessageBox.Show(this, "Cannot parse IP range or subnetmask!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                _scanner.Stop(false);
           // bntScan.Enabled = true;
           
        }

        private void ScanAddIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
