using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SortProgram
{
    public partial class MainWindow : Form
    {
        string htmlName = "";
        string[] types = new string[4] { "C#", "C++", "OpenGL", "HTML" };

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            foreach (string t in types)
            {
                string path = Directory.GetCurrentDirectory() + "\\" + t;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            displayArchive();

        }

        void Initialize()
        {
            updateButton.Hide();
            addButton.Hide();
            messageLabel.Hide();
            pathLabel.Hide();
            DirectoryRadioButton.Hide();
            pathRadioButton.Hide();
            pathTextBox.Hide();
        }

        private void Inchide_Click(object sender, EventArgs e)
        {
            this.Close();
            // Form1.forma1.Close();
        }
 
        void displayArchive()
        {
            projectsTreeView.Nodes.Add("C#");  // 0
            projectsTreeView.Nodes.Add("C++"); // 1
            projectsTreeView.Nodes.Add("OpenGL");// 2
            projectsTreeView.Nodes.Add("HTML");// 3
            string path = Directory.GetCurrentDirectory();
            if (File.Exists(path + "\\Project.txt:"))
            {
                StreamReader file = new StreamReader("Project.txt:");
                while (!file.EndOfStream)
                {
                    string s = file.ReadLine();
                    string[] ss = s.Split('\\');
                    string name = ss[ss.Length - 1];
                    if (s != "\n")
                        ss = s.Split();
                    int nr = int.Parse(ss[0]);
                    projectsTreeView.Nodes[nr].Nodes.Add(name);
                }
                file.Close();
            }
        }
   
// OPEN
        private void openProjectButton_Click(object sender, EventArgs e)
        {
            if (projectsTreeView.SelectedNode.Level == 1)
            {
                string selectedName = projectsTreeView.SelectedNode.ToString().Replace("TreeNode: ", String.Empty);
                int type = identifyType(projectsTreeView.SelectedNode.Parent.ToString().Replace("TreeNode: ", String.Empty));
                OpenExe(selectedName, type);
            }
        }

        void OpenExe(string nume, int tip)
        {
            string path = findPath(nume, tip);
            string exePath = FindExe(path, tip);
            if (exePath != "")
            {
                System.Diagnostics.Process.Start(exePath);
            }
        }

        string FindExe(string path, int tip)
        {
            string name = identifyName(path);
            switch (tip)
            {
                case 0: return path + "\\" + name + "\\bin\\Debug\\" + name + ".exe";
                case 1: return path + "\\Debug\\" + name + ".exe";
                case 2: return path + "\\Debug\\" + name;
                case 3: return path;
                default: return "";
            }
        }

        string identifyName(string path)
        {
            string[] s = path.Split('\\');
            return s[s.Length - 1];
        }

// ADD
        private void addProjectButton_Click(object sender, EventArgs e)
        {
            messageLabel.Show();
            DirectoryRadioButton.Show();
            pathRadioButton.Show();
        }

        private void DirectoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            pathLabel.Hide();
            pathTextBox.Hide();
            updateButton.Text = "Update";
            updateButton.Show();
            addButton.Hide();
        }

        private void pathRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            addButton.Text = "Add";
            addButton.Show();
            pathLabel.Show();
            pathTextBox.Show();
            updateButton.Hide();
        }

        // UpdateButton
        private void updateButton_Click(object sender, EventArgs e)
        {
            string directoryProject = Directory.GetCurrentDirectory() + "\\Project";
            string[] directory = Directory.GetDirectories(directoryProject);
            if (directory.Length == 0)
                MessageBox.Show("Nu exista directoare in Proiecte. Adaugati noi directoare");
            for (int i = 0; i < directory.Length; i++)
            {
                int tip = Type(directory[i]);
                if (tip != -1)
                {
                    addNode(directory[i], tip);
                    moveDirectory(directory[i], tip);
                }
                else
                    MessageBox.Show("Directorul " + directory[i] + " nu contine programe cu extensiile indicate.");
            }
        }

        void addNode(string Calea, int tip)
        {
            if (tip == 3)
                projectsTreeView.Nodes[tip].Nodes.Add(htmlName);
            else
                projectsTreeView.Nodes[tip].Nodes.Add(identifyName(Calea));
        }

        void moveDirectory(string source, int type)
        {
            string Dest = destination(type) + "\\" + identifyName(source);
            Eliminate(source, type);
            if (!Directory.Exists(Dest))
            {
                Directory.Move(source, Dest);
                addPath(Dest, type);
            }
            else
                MessageBox.Show("Directorul " + source + " exista deja.");
        }

        string destination(int type)
        {
            string s = Directory.GetCurrentDirectory();
            switch (type)
            {
                case 0: return s + "\\" + types[0];
                case 1: return s + "\\" + types[1];
                case 2: return s + "\\" + types[2];
                case 3: return s + "\\" + types[3];
                default: return "";
            }
        }

        void addPath(string path, int type)
        {
            string s = Directory.GetCurrentDirectory() + "\\Project.txt:";
            StreamWriter file = File.AppendText(s);
            if (type == 3)
                path = path + "\\" + htmlName;
            file.WriteLine(type.ToString() + " " + path);
            file.Close();

        }

        //addButton
        private void addButton_Click(object sender, EventArgs e)
        {
            if (checkPath(pathTextBox.Text))
            {
                int type = Type(pathTextBox.Text);
                if (type != -1)
                {
                    addNode(pathTextBox.Text, type);
                    DialogResult Aleg = MessageBox.Show("Doriti sa mutati Directorul? (Aceasta actiune nu va influenta negativ activitatea programului)", "Avertizare", MessageBoxButtons.YesNo);
                    if (Aleg == DialogResult.Yes)
                        moveDirectory(pathTextBox.Text, type);
                    else
                        addPath(pathTextBox.Text, type);
                }
                else
                    MessageBox.Show("Director invalid. Incercati cu alta cale.");
                pathTextBox.Text = "";
            }
            else
                MessageBox.Show("Director invalid. Incercati cu alta cale.");
            pathTextBox.Text = "";
        }

        bool checkPath(string path)
        {
            string[] ss = path.Split('\\');
            if (ss[0] == "D:" || ss[0] == ("C:"))
                return true;
            return false;
        }

        int Type(string Calea)
        {
            Calea = identifyPahType(Calea);
            string[] fisiere = Directory.GetFiles(Calea);
            int i = 0, c1 = 0, c2 = 0;
            bool sem = false;
            while (i < fisiere.Length && sem == false)
            {
                string[] ss = fisiere[i].Split('.');
                int n = ss.Length - 1;
                if (ss[n] == "cs")
                { sem = true; return 0; }
                else
                    if (ss[n] == "html")
                {
                    htmlName = fisiere[i];
                    string[] s = htmlName.Split('\\');
                    htmlName = s[s.Length - 1];
                    sem = true;
                    return 3;
                }
                else
                    if (ss[n] == "cpp")
                    c1 = 1;
                if (ss[n] == "dll") // Conditie pentru OpenGL
                    c2 = 2;
                if (c1 == 1 && c2 == 2)
                { sem = true; return 2; }
                else
                    if (c1 == 1)
                { sem = true; return 1; }
                i++;
            }
            return -1;
        }

        string identifyPahType(string path)
        {
            string auxPath = path + "\\" + identifyName(path);
            if (Directory.Exists(auxPath))
                return auxPath; //C# ,C++ ,OpenGL
            else
                return path; //Html
        }

        // DELETE
        private void deleteProjectButton_Click(object sender, EventArgs e)
        {
            if (projectsTreeView.SelectedNode.Level == 1)
            {
                string name = projectsTreeView.SelectedNode.ToString().Replace("TreeNode: ", String.Empty);
                int type = identifyType(projectsTreeView.SelectedNode.Parent.ToString().Replace("TreeNode: ", String.Empty));
                if (type != -1)
                {
                    string path = findPath(name, type);
                    MessageBox.Show(path);
                    if (path != "")
                    {
                        Eliminate(path, type);
                        projectsTreeView.SelectedNode.Remove();
                    }
                }
            }
        }

        int identifyType(string type)
        {
            for (int i = 0; i < 4; i++)
                if (type == types[i])
                    return i;
            return -1;
        }

        string findPath(string name, int type)
        {
            string path = Directory.GetCurrentDirectory();

            if (File.Exists(path + "\\Project.txt:"))
            {
                StreamReader file = new StreamReader("Project.txt:");
                bool sem = false;
                while (!file.EndOfStream && sem == false)
                {
                    string s = file.ReadLine();
                    if (identifyName(s) == name && identifyIndex(s) == type)
                    {
                        file.Close();
                        return s.Replace(type.ToString() + " ", String.Empty);
                    }
                }

            }
            return "";
        }

        int identifyIndex(string Rand)
        {
            string[] ss = Rand.Split();
            return int.Parse(ss[0]);
        }

        void Eliminate(string path, int type)
        {
            string pathDirectory = Directory.GetCurrentDirectory();
            if (File.Exists(pathDirectory + "\\Project.txt:"))
            {
                StreamReader f1 = new StreamReader("Project.txt:");
                StreamWriter f2 = File.AppendText(pathDirectory + "\\temp1.txt");
                if (type == 3)
                    path = path + "\\" + htmlName;
                while (!f1.EndOfStream)
                {
                    string s = f1.ReadLine();
                    if (type.ToString() + " " + path != s)
                        f2.WriteLine(s);
                }
                f1.Close();
                f2.Close();
                File.Delete("Project.txt:");
                File.Move("temp1.txt", "Project.txt:");
            }
        }

        
    }
}
