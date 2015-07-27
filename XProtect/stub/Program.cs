﻿using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Resources;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
public class Form1 : Form
{
    private Label label1;
    private TextBox txtLocation;
    private Label label2;
    private TextBox txtPassword;
    private Label label3;
    private CheckBox checkBox1;
    private Button button2;
    private Button button3;
    private ComboBox cboxOverwrite;

    private enum OWType { Ask, Force, None };
    private OWType OverWriteType;
    private TextBox txtLog;
    private bool openFolder = false;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    public Form1()
    {
        InitializeComponent();
    }



    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxOverwrite = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Extract the decrypted file(s) to:";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.White;
            this.txtLocation.Location = new System.Drawing.Point(12, 233);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(284, 21);
            this.txtLocation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(12, 281);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(366, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Overwrite Policy";
            // 
            // cboxOverwrite
            // 
            this.cboxOverwrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxOverwrite.FormattingEnabled = true;
            this.cboxOverwrite.Items.AddRange(new object[] {
            "Ask",
            "Force",
            "None"});
            this.cboxOverwrite.Location = new System.Drawing.Point(12, 327);
            this.cboxOverwrite.Name = "cboxOverwrite";
            this.cboxOverwrite.Size = new System.Drawing.Size(121, 21);
            this.cboxOverwrite.TabIndex = 6;
            this.cboxOverwrite.SelectedIndexChanged += new System.EventHandler(this.cboxOverwrite_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(150, 329);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "When done open folder";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(372, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Browse ...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(366, 201);
            this.txtLog.TabIndex = 10;
            this.txtLog.Text = "XProtector - Portable SelfExtractor\r\n\r\n------------------------------------------" +
    "\r\nProgram started\r\n";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(393, 386);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cboxOverwrite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "XProtector - Portable SelfExtractor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cboxOverwrite.SelectedIndex = 0;
        txtLocation.Text = Directory.GetCurrentDirectory();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        fbd.Description = "Select the folder where you want to extract your decrypted files.";
        fbd.ShowDialog();
        if (fbd.SelectedPath != "")
            txtLocation.Text = fbd.SelectedPath;
    }

    private void cboxOverwrite_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (cboxOverwrite.Text)
        {
            case "Ask":
                OverWriteType = OWType.Ask;
                break;
            case "Force":
                OverWriteType = OWType.Force;
                break;
            case "None":
                OverWriteType = OWType.None;
                break;
        }
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked) openFolder = true;
        else openFolder = false;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists(txtLocation.Text))
        {
            MessageBox.Show("The directory you selected does not exist !");
            return;
        }
        if (txtPassword.Text == "")
        {
            MessageBox.Show("You must enter a password !");
            return;
        }

        BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += bw_DoWork;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        Disable(true);
        bw.RunWorkerAsync();

    }
    public void Disable(bool status)
    {
        button2.Enabled = button3.Enabled = checkBox1.Enabled = txtPassword.Enabled = cboxOverwrite.Enabled = !status;
    }
    void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (openFolder)
        {
            Process.Start("explorer.exe", txtLocation.Text);
        }
        Disable(false);
    }

    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        Log("Decryption process is started...");
        byte[] data = ReadManaged();
        // byte[] data = File.ReadAllBytes(@"C:\Users\MeltingICE\Desktop\ew\Audacity.lnk");
        try
        {
            byte[] decryptedData = Encryption.Decrypt(data, txtPassword.Text);
            FileHandle.FileEx[] files = FileHandle.SplitFiles(decryptedData);
            Log("Successfully decrypted ! Found " + files.Length + " files !");
            int i = 1;
            foreach (FileHandle.FileEx file in files)
            {
                if (OverWriteType == OWType.Ask)
                {
                    if (File.Exists(Path.Combine(txtLocation.Text, file.name)))
                    {
                        DialogResult dialogResult = MessageBox.Show(string.Format("{0} already exists. Do you wish to overwrite ?", file.name), "Information", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Log(string.Format("Extracting {0} ", file.name));
                            File.WriteAllBytes(Path.Combine(txtLocation.Text, file.name), file.data);
                        }
                    }
                    else
                    {
                        Log(string.Format("Extracting {0} ", file.name));
                        File.WriteAllBytes(Path.Combine(txtLocation.Text, file.name), file.data);
                    }
                }
                else if (OverWriteType == OWType.Force)
                {
                    Log(string.Format("Extracting {0} ", file.name));
                    File.WriteAllBytes(Path.Combine(txtLocation.Text, file.name), file.data);
                }
                else if (OverWriteType == OWType.None)
                {
                    if (!File.Exists(Path.Combine(txtLocation.Text, file.name)))
                    {
                        Log(string.Format("Extracting {0} ", file.name));
                        File.WriteAllBytes(Path.Combine(txtLocation.Text, file.name), file.data);
                    }
                }
                i++;
            }
            Log("Done !");
            Log("");
        }
        catch
        {
            Log("- The file(s) could not be decrypted !");
            Log("Maybe wrong password ?");
            Log("");
            Disable(false);
        }
    }
    public void Log(string text)
    {
        Invoke(new MethodInvoker(delegate
        {
            txtLog.Text = txtLog.Text + Environment.NewLine + text;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }));
    }
    public byte[] ReadManaged()
    {
        ResourceManager Manager = new ResourceManager("Encrypted", Assembly.GetExecutingAssembly());
        byte[] bytes = (byte[])Manager.GetObject("encfile");
        return bytes;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        txtPassword.Focus();
    }
}

class Encryption
{
    private static readonly byte[] salt = new byte[] { 4, 8, 15, 16, 23, 42, 6, 120 };
    private static readonly int keySize = 256;
    public static byte[] Decrypt(byte[] data, string password)
    {
        byte[] result = null;
        byte[] passwordBytes = Encoding.Default.GetBytes(password);

        using (MemoryStream ms = new MemoryStream())
        {
            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = keySize;
                AES.BlockSize = 128;
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CBC;
                using (CryptoStream cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.Close();
                }
                result = ms.ToArray();
            }
        }

        return result;
    }
}

class FileHandle
{
    public struct FileEx
    {
        public string name;
        public byte[] data;
    }
    public static string GetString(byte[] data)
    {
        return Encoding.Default.GetString(data);
    }
    public static byte[] GetBytes(string data)
    {
        return Encoding.Default.GetBytes(data);
    }
    private static byte[] toBytes(long data, int size)
    {
        byte[] bytes = new byte[size];
        return bytes;
    }
    public static byte[] CombineFiles(FileEx[] data)
    {
        List<byte> result = new List<byte>();

        // Generating the header
        int pos = 0;
        string toAdd = "";
        foreach (FileEx file in data)
        {
            int future = pos + file.data.Length;
            toAdd += string.Format("[|{0}|{1}|{2}|]", file.name, pos, file.data.Length);
            pos = future;
        }
        result.AddRange(GetBytes(toAdd));

        //Adding the header's size
        result.InsertRange(0, BitConverter.GetBytes(result.Count));

        //Adding the file data
        foreach (FileEx file in data)
        {
            result.AddRange(file.data);
        }
        return result.ToArray();

    }
    public static FileEx[] SplitFiles(byte[] data)
    {
        List<FileEx> result = new List<FileEx>();

        // Get the header size
        int headerSize = BitConverter.ToInt32(data, 0);

        // Get the header
        byte[] header = new byte[headerSize];
        Buffer.BlockCopy(data, 4, header, 0, headerSize);
        string headerText = GetString(header);

        // The offset from where the bytes of the first file will start
        int initialOffset = headerSize + 4;

        // For each file create a new fileex item and add it to the result
        foreach (Match match in Regex.Matches(headerText, @"(\[\|)(.*?)(\|\])"))
        {
            MatchCollection matches = Regex.Matches(match.Value, @"(?<=\|)(.*?)(?=\|)");
            FileEx item = new FileEx();
            int start = 0, len = 0;
            for (int i = 0; i < 3; i++)
            {
                string val = matches[i].Value;
                switch (i)
                {
                    case 0:
                        item.name = val;
                        break;
                    case 1:
                        start = int.Parse(val);
                        break;
                    case 2:
                        len = int.Parse(val);
                        break;
                }
            }
            item.data = new byte[len];
            Buffer.BlockCopy(data, initialOffset + start, item.data, 0, len);
            result.Add(item);
        }
        return result.ToArray();
    }
}