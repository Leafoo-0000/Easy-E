using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EasyEv3.Models;
using MySql.Data.MySqlClient;
using QRCoder;

namespace EasyEv3
{
    public partial class ShowAddParticipantPanel : UserControl
    {
        public event Action OnParticipantSaved;

        private int? editingParticipantId = null;

        public ShowAddParticipantPanel()
        {
            InitializeComponent();

            // Make QR text box read-only
            txtQRCode.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveParticipant();
        }

        private void SaveParticipant()
        {
            string name = txtUsername.Text.Trim();
            string email = txtEmailAdress.Text.Trim();
            string qrCode = txtQRCode.Text.Trim(); // capture QR text

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter both Name and Email.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(qrCode))
            {
                MessageBox.Show("Please generate a QR code before saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query;

                    if (editingParticipantId.HasValue) // Editing
                    {
                        query = @"UPDATE participants
                          SET name = @name, email = @email, qr_code = @qr
                          WHERE id = @id";
                    }
                    else // Adding
                    {
                        query = @"INSERT INTO participants (name, email, qr_code) 
                          VALUES (@name, @email, @qr)";
                    }

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@qr", qrCode);

                        if (editingParticipantId.HasValue)
                            cmd.Parameters.AddWithValue("@id", editingParticipantId.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Participant saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields
                txtUsername.Clear();
                txtEmailAdress.Clear();
                txtQRCode.Clear();
                picQRCode.Image = null;
                editingParticipantId = null;

                OnParticipantSaved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving participant: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadParticipantForEditing(Participant participant)
        {
            if (participant == null) return;

            editingParticipantId = participant.Id;
            txtUsername.Text = participant.Name;
            txtEmailAdress.Text = participant.Email;
            txtQRCode.Text = participant.QRCode;

            if (!string.IsNullOrEmpty(participant.QRCode))
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrData = qrGenerator.CreateQrCode(participant.QRCode, QRCodeGenerator.ECCLevel.Q))
                using (QRCode qrCode = new QRCode(qrData))
                {
                    picQRCode.Image = qrCode.GetGraphic(5);
                }
            }
        }

        private void btnQRgen_Click(object sender, EventArgs e)
        {
            // If QR already exists, confirm overwrite
            if (!string.IsNullOrEmpty(txtQRCode.Text))
            {
                var result = MessageBox.Show(
                    "A QR code already exists. Do you want to generate a new one?",
                    "Confirm QR Overwrite",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return; // cancel generation
            }

            string qrText = $"{txtUsername.Text.Trim()}|{txtEmailAdress.Text.Trim()}|{DateTime.Now.Ticks}";
            txtQRCode.Text = qrText;

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrData))
            {
                picQRCode.Image = qrCode.GetGraphic(5);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtEmailAdress_TextChanged(object sender, EventArgs e) { }
        private void txtQRCode_TextChanged(object sender, EventArgs e) { }
        private void picQRCode_Click(object sender, EventArgs e) { }
    }
}
