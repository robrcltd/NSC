// File: UI/MainForm.cs
using System;
using System.Windows.Forms;
using MyNetworkTool.Models;    // So it can see NetworkProfile
using MyNetworkTool.Services;  // So it can see NetworkManager

namespace MyNetworkTool.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // This is triggered when the user clicks the button
        private void btnApply_Click(object sender, EventArgs e)
        {
            // 1. Pull the selected values from your WinForms UI controls
            string selectedAdapter = comboBoxAdapters.SelectedItem?.ToString();
            NetworkProfile selectedProfile = listBoxProfiles.SelectedItem as NetworkProfile;

            // 2. Run the logic
            if (string.IsNullOrEmpty(selectedAdapter) || selectedProfile == null)
            {
                MessageBox.Show("Please select both an adapter and a profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success;
            if (selectedProfile.IsDHCP)
            {
                success = NetworkManager.SetDHCP(selectedAdapter);
            }
            else
            {
                success = NetworkManager.SetStaticIP(
                    selectedAdapter, 
                    selectedProfile.IPAddress, 
                    selectedProfile.SubnetMask, 
                    selectedProfile.Gateway
                );
            }

            // 3. Show the result to the user
            if (success)
            {
                MessageBox.Show($"Successfully applied '{selectedProfile.ProfileName}'!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to apply settings. Double-check your administrator privileges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
