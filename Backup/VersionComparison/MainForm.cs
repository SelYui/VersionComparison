using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace VersionComparison
{
    public partial class MainForm : Form
    {
        #region Глобальные переменные
        public int schetOpen1;
        public int schetOpen2;
        public string directoryPath1;
        public string directoryPath2;
        public string FilePath1;
        public string FilePath2;
        public string FilePath;
        public string SelectPath1;
        public string SelectPath2;
        public string SelectPath;
        public int schet, schet1, schet2;
        public int cpr, pvv, buk, hex;
        #endregion


        public MainForm()
        {
            InitializeComponent();
            /*schetOpen1 = 0;
            schetOpen2 = 0;
            butCompare.Enabled = false;*/
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*schetOpen1 = 0;
            schetOpen2 = 0;
            butCompare.Enabled = false;*/
        }

        private void butOpenDirectory1_Click(object sender, EventArgs e)
        {
            butOpenDirectory1.Cursor = Cursors.WaitCursor;
            //Очистка поля treeView
            treeDirectory1.Nodes.Clear();
            //Считываем путь к каталогу
            directoryPath1 = fldDirectoryPath1.Text;

            //Проверка указанного пути
            bool isExist = Directory.Exists(directoryPath1);
            if (!isExist)
            {
                //Если путь не найден высвечивается сообщение об ошибке
                MessageBox.Show("Выбранного каталога не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                schetOpen1 = 0;
            }
            else//Если путь существует
            {
                //Создаем корневой узел
                TreeNode nodeDrive = new TreeNode(directoryPath1);
                //Добавляем корневой узел к дереву просмотра
                treeDirectory1.Nodes.Add(nodeDrive);
                //Развертываем корневой узел
                nodeDrive.Expand();

                //Считываем дерево каталогов
                AddDirectories(nodeDrive);
                //schetOpen1 = schetOpen1 + 1;
            }
            /*if (schetOpen1 == 1)
                butCompare.Enabled = true;*/
            butOpenDirectory1.Cursor = Cursors.Default;
        }

        private void butOpenDirectory2_Click(object sender, EventArgs e)
        {
            butOpenDirectory2.Cursor = Cursors.WaitCursor;
            treeDirectory2.Nodes.Clear();

            directoryPath2 = fldDirectoryPath2.Text;

            bool isExist = Directory.Exists(directoryPath2);
            if (!isExist)
            {
                MessageBox.Show("Выбранного каталога не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                schetOpen2 = 0;
            }
            else
            {
                TreeNode nodeDrive = new TreeNode(directoryPath2);
                treeDirectory2.Nodes.Add(nodeDrive);
                nodeDrive.Expand();

                AddDirectories(nodeDrive);
                //schetOpen2 = schetOpen2 + 1;
            }
            /*if (schetOpen1 > 1 && schetOpen2 > 1)
                butCompare.Enabled = true;*/
            butOpenDirectory2.Cursor = Cursors.Default;
        }

        private void fldDirectoryPath1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //нажатие на клавише Enter равносильно нажатию на кнопку Открыть
            if (e.KeyChar == '\r')
            {
                butOpenDirectory1.PerformClick();
            }
        }

        private void fldDirectoryPath2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                butOpenDirectory2.PerformClick();
            }
        }

        //при наведении на TreeView оно становится активным
        //private void treeDirectory1_MouseEnter(object sender, EventArgs e)
        //{
        //    treeDirectory1.Focus();
        //}
        //private void treeDirectory2_MouseEnter(object sender, EventArgs e)
        //{
        //    treeDirectory2.Focus();
        //}

        private void butSelectDirectory1_Click(object sender, EventArgs e)
        {
            butSelectDirectory1.Cursor = Cursors.WaitCursor;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            //Запоминаем последний выбранный путь
            if (fldDirectoryPath1.Text == "")
                dlg.SelectedPath = fldDirectoryPath2.Text;
            else
                dlg.SelectedPath = fldDirectoryPath1.Text;

            //Диалоговое окно для выбора файла
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldDirectoryPath1.Text = dlg.SelectedPath;
                butOpenDirectory1.PerformClick();
            }
            butSelectDirectory1.Cursor = Cursors.Default;
        }

        private void butSelectDirectory2_Click(object sender, EventArgs e)
        {
            butSelectDirectory2.Cursor = Cursors.WaitCursor;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (fldDirectoryPath2.Text == "")
                dlg.SelectedPath = fldDirectoryPath1.Text;
            else
                dlg.SelectedPath = fldDirectoryPath2.Text;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldDirectoryPath2.Text = dlg.SelectedPath;
                butOpenDirectory2.PerformClick();
            }
            butSelectDirectory2.Cursor = Cursors.Default;
        }

        private void butCompare_Click(object sender, EventArgs e)
        {
            butCompare.Cursor = Cursors.WaitCursor;//курсор в виде пеcочных часов
            butCompare.Enabled = false;//кнопка не доступна для нажатия
            butOpenDirectory1.PerformClick();//нажимаются кнопки открыть
            butOpenDirectory2.PerformClick();
            //Не выбраны каталоги
            if (fldDirectoryPath1.Text == "" || fldDirectoryPath2.Text == "")
            {
                MessageBox.Show("Каталог не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Выбранные каталоги одинаковы
            else
            {
                //обнуление выделений
                schet = 0;//счетчик
                WhiteColor(treeDirectory1.Nodes);//обнуление цвета
                WhiteColor(treeDirectory2.Nodes);
                TreeComparison(treeDirectory1.Nodes, treeDirectory2.Nodes);//сравнение
                TreeComparisonContents(treeDirectory1.Nodes);//Выделение похожих по названию, но разных по содержанию узлов
                TreeComparison(treeDirectory2.Nodes, treeDirectory1.Nodes);
                TreeComparisonContents(treeDirectory2.Nodes);
                schet = 0; schet1 = 0; schet2 = 0;//счетчики одинаковых файлов
                TreeFileComparison(treeDirectory1.Nodes, treeDirectory2.Nodes);//Сравнение содержимого файлов
                schet1 = schet;
                schet = 0;
                TreeFileComparison(treeDirectory2.Nodes, treeDirectory1.Nodes);
                schet2 = schet;
                
                schet = 0;
                SchetGreenFile(treeDirectory1.Nodes);
                lblGreen.Text = schet.ToString();
                schet = 0;
                SchetFile(treeDirectory1.Nodes);
                lblGreen.Text = lblGreen.Text + " из " + schet.ToString();
                
                TreeComparisonContents(treeDirectory1.Nodes);
                TreeComparisonContents(treeDirectory2.Nodes);
                cpr = 0; pvv = 0; buk = 0; hex = 0;
                if (fldDirectoryPath1.Text == fldDirectoryPath2.Text)
                {
                    MessageBox.Show("Выбранные пути к каталогу одинаковы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                // в зависимости от результата сравнения папки hex выводим итог
                {
                    if (FileHexGreen(treeDirectory1.Nodes) == true)
                    {
                        
                        MessageBox.Show("Сравнение завершено. Версии идентичны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Сравнение завершено. Версии не идентичны", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }           
                }
            }
            butCompare.Enabled = true;
            butCompare.Cursor = Cursors.Default;
        }

        private void FileComparison_Click(object sender, EventArgs e)
        {
            try 
            {
                if (SelectPath1 == null || SelectPath2 == null)
                    MessageBox.Show("Выберите файлы для сравнения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Запуск программы WinMerge с заданными параметрами
                    SelectPath = SelectPath1 + " " + SelectPath2;
                    Process.Start(@"C:\Program Files\WinMerge\WinMergeU.exe", SelectPath);
                }
            }
            catch(Win32Exception) 
            {
                MessageBox.Show("Объекта C:\\Program Files\\WinMerge\\WinMergeU.exe не существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
//*************************************************************************************************
        //Заполняем дерево
        void AddDirectories(TreeNode node)
        {
            //Для текущего узла node получаем полный путь к корню дерева
            string strPath = node.FullPath;
            //Создаем объект текущего каталога
            DirectoryInfo dirInfo = new DirectoryInfo(strPath);
            //Объявляем ссылку на массив подкаталогов текущего каталога
            DirectoryInfo[] arrayDirInfo;

            try
            {
                //Пытаемся получить список подкаталогов
                arrayDirInfo = dirInfo.GetDirectories();
            }
            catch
            {
                //Подкаталогов нет выходим из рекурсии
                return;
            }
            //Добавляем прочитанные подкаталоги как узлы в дерево просмотра
            foreach (DirectoryInfo dir in arrayDirInfo)
            {
                //Условие что выбранный каталог не .svn
                if (string.Compare(dir.Name, ".svn", true) != 0)
                {
                    //Создаем новый узел с именем подкаталога
                    TreeNode nodeDir = new TreeNode(dir.Name);
                    //Добавляем его как дочерний к текущему узлу
                    node.Nodes.Add(nodeDir);
                    //Делаем дочерний узел текущим и спускаемся рекурсивно ниже
                    AddDirectories(nodeDir);
                }
            }
            foreach (var d in dirInfo.GetFiles())
            {
                //Региональные параметры языка
                CultureInfo ci = new CultureInfo("en-US");
                //Сравниваем с расширением .m96 и не включаем их в дерево
                bool resultM96 = d.Name.EndsWith(".m96", true, ci);
                bool resultLST = d.Name.EndsWith(".lst", true, ci);
                if (resultM96 == false && resultLST == false)
                    node.Nodes.Add(d.Name);//Добавляем к поткаталогу имена файлов, содержащихся в не
            }
            //node.ExpandAll();
        }

        //Сброс цвета
        private void WhiteColor(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.ForeColor = Color.Black;
                WhiteColor(node.Nodes);
            }
        }

        #region Сравнение текста в узлах
        void TreeComparison(TreeNodeCollection nodes1, TreeNodeCollection nodes2)
        {
            foreach (TreeNode node2 in nodes2)
            {
                TreeComparison2(nodes1, node2);
                TreeComparison(nodes1, node2.Nodes);
            }
        }
        void TreeComparison2(TreeNodeCollection nodes1, TreeNode node2)
        {
            foreach (TreeNode node1 in nodes1)
            {
                //string.Compare(string1, string2, true) == 0 - сравнение двух строк без учета регистра
                if (node1.Parent != null && string.Compare(node1.Parent.Text, ".svn", true) == 0)
                    break;
                if (string.Compare(node2.Text, node1.Text, true) == 0 && string.Compare(node2.Text, ".svn", true) != 0)
                {
                    //schet = schet + 1;//не помню зачем?
                    node1.ForeColor = Color.Green;
                    break;
                }

                if (node1.Parent != null && node1.ForeColor != Color.Green && string.Compare(node1.Text, ".svn", true) != 0)
                    node1.ForeColor = Color.Red;

                TreeComparison2(node1.Nodes, node2);
            }
        }
        #endregion

        //Выделение похожих по названию, но разных по содержанию узлов (ораньжевый цвет)
        void TreeComparisonContents(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Parent != null && node.Parent.ForeColor != Color.Red && (node.ForeColor == Color.Red || node.ForeColor == Color.Orange))
                {
                    node.Parent.ForeColor = Color.Orange;
                    if (node.Parent.Parent != null && node.Parent.ForeColor != Color.Red)
                    {
                        node.Parent.Parent.ForeColor = Color.Orange;
                        if (node.Parent.Parent.Parent != null && node.Parent.ForeColor != Color.Red)
                            node.Parent.Parent.Parent.ForeColor = Color.Orange;
                    }
                    
                }
                TreeComparisonContents(node.Nodes);
            }
        }

        #region Cравнение файлов
        private void TreeFileComparison(TreeNodeCollection nodes1, TreeNodeCollection nodes2)
        {
            foreach (TreeNode node2 in nodes2)
            {
                TreeFileComparison2(nodes1, node2);
                TreeFileComparison(nodes1, node2.Nodes);
            }
        }

        private void TreeFileComparison2(TreeNodeCollection nodes1, TreeNode node2)
        {
            foreach (TreeNode node1 in nodes1)
            {
                if (node1.Parent != null && node2.Parent != null && node1.Parent.Parent != null && node2.Parent.Parent != null && node1.Parent.Parent.Parent != null && node2.Parent.Parent.Parent != null
                    && (string.Compare(node1.Parent.Text, ".svn", true) == 0 && string.Compare(node2.Parent.Text, ".svn", true) == 0 || string.Compare(node1.Parent.Parent.Text, ".svn", true) == 0 && string.Compare(node2.Parent.Parent.Text, ".svn", true) == 0 || string.Compare(node1.Parent.Parent.Parent.Text, ".svn", true) == 0 && string.Compare(node2.Parent.Parent.Parent.Text, ".svn", true) == 0))
                    break;
                else if (string.Compare(node1.Text, ".svn", true) != 0 && string.Compare(node2.Text, ".svn", true) != 0 && node1.Parent != null && node2.Parent != null)
                {
                    if (string.Compare(node1.Text, node2.Text, true) == 0)
                    {
                        if (node1.Parent.Parent == null && node2.Parent.Parent == null)
                        { SearchFile(node1, node2); }
                        else if (node1.Parent != null && node2.Parent != null && node1.Parent.Parent != null && node2.Parent.Parent != null && node1.Parent.Parent.Parent != null && node2.Parent.Parent.Parent != null && string.Compare(node1.Parent.Parent.Parent.Text, node2.Parent.Parent.Parent.Text, true) == 0 && string.Compare(node1.Parent.Text, node2.Parent.Text, true) == 0)
                        { SearchFile(node1, node2); }
                        else if (node1.Parent.Parent != null && node2.Parent.Parent != null && node1.Parent != null && node2.Parent != null && string.Compare(node1.Parent.Parent.Text, node2.Parent.Parent.Text, true) == 0 && string.Compare(node1.Parent.Text, node2.Parent.Text, true) == 0)
                        { SearchFile(node1, node2); }
                        else if (node1.Parent != null && node2.Parent != null && node1.Parent.Parent != null && node2.Parent.Parent != null && node1.Parent.Parent.Parent == null && node2.Parent.Parent.Parent == null && string.Compare(node1.Parent.Text, node2.Parent.Text, true) == 0)
                        { SearchFile(node1, node2); }
                        //else if (node1.Parent.Parent.Parent == null && node2.Parent.Parent.Parent == null)
                        //{ SearchFile(node1, node2); }
                    }
                }
                TreeFileComparison2(node1.Nodes, node2);
            }
        }
        #endregion

        //Поиск файлов в TreeView
        private void SearchFile(TreeNode node1, TreeNode node2)
        {
            char s;
            if (string.Compare(node1.Text, "makefile", true) == 0)
            {
                //сравнение файлов
                /*TreeFilePath(node1);
                FilePath1 = FilePath;
                TreeFilePath(node2);
                FilePath2 = FilePath;*/
                FilePath1 = node1.FullPath;
                FilePath2 = node2.FullPath;
                if (TreeFileCompare(FilePath1, FilePath2) == true)
                    {
                        node1.ForeColor = Color.Green;
                        schet = schet + 1;
                    }
                else
                node1.ForeColor = Color.Orange;
            }
            else
            {
                for (int i = 0; i < node1.Text.Length - 1; i++)
                {
                    s = node1.Text[i];
                    if (s == '.')//Если выбранный элемент файл
                    {
                        //сравнение файлов
                        /*TreeFilePath(node1);
                        FilePath1 = FilePath;*/
                        FilePath1 = node1.FullPath;
                        /*TreeFilePath(node2);
                        FilePath2 = FilePath;*/
                        FilePath2 = node2.FullPath;
                        if (TreeFileCompare(FilePath1, FilePath2) == true)
                        {
                            node1.ForeColor = Color.Green;
                            schet = schet + 1;
                            break;
                        }
                        else
                            node1.ForeColor = Color.Orange;
                    }
                }
            }                            
        }

        //Путь к файлу для сравнения (наверняка есть способ получше)
        private void TreeFilePath(TreeNode node)
        {
            FilePath = node.Text;
            if (node.Parent != null)
            {
                FilePath = node.Parent.Text + "\\" + FilePath;
                if (node.Parent.Parent != null)
                {
                    FilePath = node.Parent.Parent.Text + "\\" + FilePath;
                    if (node.Parent.Parent.Parent != null)
                    {
                        FilePath = node.Parent.Parent.Parent.Text + "\\" + FilePath;
                        if (node.Parent.Parent.Parent.Parent != null)
                        {
                            FilePath = node.Parent.Parent.Parent.Parent.Text + "\\" + FilePath;
                            if (node.Parent.Parent.Parent.Parent.Parent != null)
                            {
                                FilePath = node.Parent.Parent.Parent.Parent.Parent.Text + "\\" + FilePath;
                            }
                        }
                    }
                }
            }
        }

		//Сравнение текста в файлах
        private bool TreeFileCompare(string FilePath1, string FilePath2)
        {
            try
            {
                string content1 = File.ReadAllText(FilePath1);
                string content2 = File.ReadAllText(FilePath2);
                if (string.Compare(content1, content2, true) == 0)
                    //if (content1 == content2)
                    return true;
                else
                    return false;
            }
            catch (UnauthorizedAccessException) // устранение ошибки ввода-вывода
            {
                return true;
            }
            //string content1 = File.ReadAllText(FilePath1);
            //string content2 = File.ReadAllText(FilePath2);
            //if (string.Compare(content1, content2, true) == 0)
            ////if (content1 == content2)
            //    return true;
            //else
            //    return false;
        }

        #region Подсчет количества совпадающих файлов
        private void SchetFile(TreeNodeCollection nodes)
        {
            char s;

            foreach (TreeNode node in nodes)
            {
                if (node.Parent != null && string.Compare(node.Parent.Text, ".svn", true) == 0)
                    break;
                if (string.Compare(node.Text, ".svn", true) != 0)
                {
                    if (string.Compare(node.Text, "makefile", true) == 0)
                        schet = schet + 1;
                    else
                    {
                        for (int i = 0; i < node.Text.Length - 1; i++)
                        {
                            s = node.Text[i];
                            if (s == '.')//Если выбранный элемент файл
                            {
                                schet = schet + 1;
                            }
                        }
                    }
                }
                SchetFile(node.Nodes);
            }
        }

        //Подсчет количества одинаковых файлов
        private void SchetGreenFile(TreeNodeCollection nodes)
        {
            char s;
            //Поиск одинаковых файлов
            foreach (TreeNode node in nodes)
            {
                if (node.Parent != null && string.Compare(node.Parent.Text, ".svn", true) == 0)
                    break;
                if (string.Compare(node.Text, ".svn", true) != 0)
                {
                    if (string.Compare(node.Text, "makefile", true) == 0 && node.ForeColor == Color.Green)
                        schet = schet + 1;
                    if (node.ForeColor == Color.Green)
                    {
                        for (int i = 0; i < node.Text.Length - 1; i++)
                        {
                            s = node.Text[i];
                            if (s == '.')//Если выбранный элемент файл
                            {
                                schet = schet + 1;
                            }
                        }
                    }
                }
                SchetGreenFile(node.Nodes);
            }
        }
        #endregion

        #region Ищем путь выбранных пользователем файлов
        private void treeDirectory1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectPath1 = e.Node.FullPath;
            /*if (e.Node.Parent != null)
            {
                SelectPath1 = e.Node.Parent.Text + "\\" + SelectPath1;
                if (e.Node.Parent.Parent != null)
                {
                    SelectPath1 = e.Node.Parent.Parent.Text + "\\" + SelectPath1;
                    if (e.Node.Parent.Parent.Parent != null)
                    {
                        SelectPath1 = e.Node.Parent.Parent.Parent.Text + "\\" + SelectPath1;
                        if (e.Node.Parent.Parent.Parent.Parent != null)
                        {
                            SelectPath1 = e.Node.Parent.Parent.Parent.Parent.Text + "\\" + SelectPath1;
                            if (e.Node.Parent.Parent.Parent.Parent.Parent != null)
                            {
                                SelectPath1 = e.Node.Parent.Parent.Parent.Parent.Parent.Text + "\\" + SelectPath1;
                            }
                        }
                    }
                }
            }*/
        }
        private void treeDirectory2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectPath2 = e.Node.FullPath;
            /*if (e.Node.Parent != null)
            {
                SelectPath2 = e.Node.Parent.Text + "\\" + SelectPath2;
                if (e.Node.Parent.Parent != null)
                {
                    SelectPath2 = e.Node.Parent.Parent.Text + "\\" + SelectPath2;
                    if (e.Node.Parent.Parent.Parent != null)
                    {
                        SelectPath2 = e.Node.Parent.Parent.Parent.Text + "\\" + SelectPath2;
                        if (e.Node.Parent.Parent.Parent.Parent != null)
                        {
                            SelectPath2 = e.Node.Parent.Parent.Parent.Parent.Text + "\\" + SelectPath2;
                            if (e.Node.Parent.Parent.Parent.Parent.Parent != null)
                            {
                                SelectPath2 = e.Node.Parent.Parent.Parent.Parent.Parent.Text + "\\" + SelectPath2;
                            }
                        }
                    }
                }
            }*/
        }
        #endregion

        //вывод об идентичности версий
        private bool FileHexGreen(TreeNodeCollection nodes)
        {            
            foreach (TreeNode node in nodes)
            {
                //если сравниваются версии БВУ
                if (node.Parent != null && string.Compare(node.Text, "hex", true) == 0 && node.ForeColor == Color.Green
                    && string.Compare(node.Parent.Text, "pvv", true) == 0)
                { pvv++; break; }
                if (node.Parent != null && string.Compare(node.Text, "hex", true) == 0 && node.ForeColor == Color.Green
                    && string.Compare(node.Parent.Text, "cpr", true) == 0)
                { cpr++; break; }
                //если не БВУ
                if (string.Compare(node.Text, "hex", true) == 0 && node.ForeColor == Color.Green)
                { buk++; break; }
                if (string.Compare(node.Text, "hex", true) == 0)
                { hex++; break; }//для теста

                FileHexGreen(node.Nodes);
            }
            //смотрим и в ПВВ и в ЦПР hex зеленые?
            if (pvv > 0 && cpr > 0)
                return true;
            else if (buk > 0)
                return true;
            else
                return false;
        }
    }
}


