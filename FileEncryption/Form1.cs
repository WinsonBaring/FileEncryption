using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to encrypt";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    ProcessFile(filePath);

                    MessageBox.Show($"✅ File Encrypted!\n\nOverwritten: {filePath}", "Success");
                }
            }
        }

        private void Decrypt(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to decrypt";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    ProcessFile(filePath);

                    MessageBox.Show($"✅ File Decrypted!\n\nOverwritten: {filePath}", "Success");
                }
            }
        }

        private void ProcessFile(string filePath)
        {
            byte[] key = Encoding.UTF8.GetBytes("winsongwapo");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            int keyLength = key.Length;

            for (int i = 0; i < fileBytes.Length; i++)
            {
                fileBytes[i] ^= key[i % keyLength];
            }

            File.WriteAllBytes(filePath, fileBytes);
        }
    }
}
