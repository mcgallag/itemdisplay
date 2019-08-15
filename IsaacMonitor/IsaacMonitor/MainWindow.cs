using System;
using System.Windows.Forms;

namespace IsaacMonitor
{
    public partial class MainWindow : Form
    {
        private IsaacMemoryReader isaac;
        public MainWindow()
        {
            InitializeComponent();
            attachButton.Enabled = false;
            searchButton.Enabled = false;
            detachButton.Enabled = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            isaac = new IsaacMemoryReader();
            updateTimer.Interval = 100;
            updateTimer.Start();
        }

        private void AttachButton_Click(object sender, EventArgs e)
        {
        }

        private void DetachButton_Click(object sender, EventArgs e)
        {
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (isaac.HaveBaseAddress)
            {
                isaac.Update();
            }
            else 
                isaac.AoBScanAsync();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!isaac.Attached)
            {
                attachButton.Enabled = true;
                isaac.Attach();
            }
            if (isaac.Attached)
            {
                attachButton.Enabled = false;
                if (!isaac.HaveBaseAddress)
                {
                    searchButton.Enabled = true;
                    isaac.AoBScanAsync();
                }
                if (isaac.HaveBaseAddress)
                {
                    searchButton.Enabled = false;
                    isaac.Update();
                    if (isaac.GameUpdated)
                    {
                        GameInfo game = isaac.GetGame();
                        isaac.WriteToFile();
                        rocksBox.Text = game.Rocks.ToString();
                        tintedBox.Text = game.TintedRocks.ToString();
                        poopsBox.Text = game.Poops.ToString();
                        shopKeepersBox.Text = game.ShopKeeps.ToString();
                        devilsBox.Text = game.DevilDeals.ToString();
                        donationBox.Text = game.Donations.ToString();
                    }
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            isaac.Detach();
        }
    }
}
