
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace FolderWatcher
{
    public partial class Form1 : Form
    {
        FileSystemWatcher watcher;
        TextBox path, log;
        Button browse, start, stop;

        public Form1()
        {
            InitializeComponent();
            BuildForm();
        }

        void BuildForm()
        {
            Text = "Folder Watcher";
            Size = new Size(650, 480);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "FOLDER WATCHER";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.Location = new Point(25, 20);
            title.AutoSize = true;
            Controls.Add(title);

            path = new TextBox();
            path.SetBounds(25, 80, 390, 30);
            Controls.Add(path);

            browse = new Button();
            browse.Text = "Browse";
            browse.SetBounds(430, 78, 100, 32);
            browse.Click += Browse_Click;
            Controls.Add(browse);

            start = new Button();
            start.Text = "Start Watching";
            start.SetBounds(25, 125, 150, 35);
            start.Click += Start_Click;
            Controls.Add(start);

            stop = new Button();
            stop.Text = "Stop Watching";
            stop.SetBounds(190, 125, 150, 35);
            stop.Enabled = false;
            stop.Click += Stop_Click;
            Controls.Add(stop);

            Label heading = new Label();
            heading.Text = "Activity Log";
            heading.SetBounds(25, 185, 200, 25);
            heading.Font = new Font("Arial", 11, FontStyle.Bold);
            Controls.Add(heading);

            log = new TextBox();
            log.Multiline = true;
            log.ReadOnly = true;
            log.ScrollBars = ScrollBars.Vertical;
            log.SetBounds(25, 215, 570, 200);
            Controls.Add(log);
        }

        void WriteLog(string message)
        {
            string entry = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt")
                           + " - " + message;

            if (InvokeRequired)
            {
                Invoke(new Action(() => WriteLog(message)));
                return;
            }

            log.AppendText(entry + Environment.NewLine);
            File.AppendAllText("FolderLog.txt", entry + Environment.NewLine);
        }

        void Browse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog d = new FolderBrowserDialog())
                if (d.ShowDialog() == DialogResult.OK)
                    path.Text = d.SelectedPath;
        }

        void Start_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(path.Text))
            {
                MessageBox.Show("Select a valid folder!");
                return;
            }

            watcher = new FileSystemWatcher(path.Text);
            watcher.Created += (s, a) => WriteLog("Created: " + a.Name);
            watcher.Deleted += (s, a) => WriteLog("Deleted: " + a.Name);
            watcher.Renamed += (s, a) => WriteLog("Renamed: " + a.Name);

            watcher.EnableRaisingEvents = true;
            start.Enabled = false;
            stop.Enabled = true;

            WriteLog("Watching Started");
        }

        void Stop_Click(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;

            start.Enabled = true;
            stop.Enabled = false;

            WriteLog("Watching Stopped");
        }
    }
}
