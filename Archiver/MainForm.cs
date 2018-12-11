﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Archiver
{
    public partial class MainForm : Form
    {
        public class c_FileToArchive
        {
            public String SelectedFilePath { get; set; }
            public String SelectedFile { get; set; }
        }
        c_FileToArchive pc_FTA = new c_FileToArchive();
        public MainForm()
        {
            InitializeComponent();
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_SelectFile_Click(object sender, EventArgs e)
        {
            label_Status.Text = "";
            button_AddToArchive.Enabled = false;
            button_ExtractFromArchive.Enabled = false;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pc_FTA.SelectedFilePath = openFileDialog1.FileName;
                pc_FTA.SelectedFile = Path.GetFileName(openFileDialog1.FileName);
                textBox1.Text = Path.GetFileName(openFileDialog1.FileName);
                if (Path.GetExtension(pc_FTA.SelectedFilePath) == ".uda")
                {
                    button_ExtractFromArchive.Enabled = true;
                }
                else { button_AddToArchive.Enabled = true; }
            }

        }

        private void button_AddToArchive_Click(object sender, EventArgs e)
        {

            FileStream lfs_ReadFile = new FileStream(pc_FTA.SelectedFilePath, FileMode.Open);
            BinaryReader lbr = new BinaryReader(lfs_ReadFile);
            Byte[] lba_inFA = lbr.ReadBytes((int)lfs_ReadFile.Length);
            lbr.Close();
            lfs_ReadFile.Close();

            List<Byte> list_EncryptFirst = new List<Byte>();
            Byte lb_Byte = 0;
            Int32 li_Count = 1;
            for (int i = 0, j = 1; i < lba_inFA.Length; i++, j++)
            {
                if (j != lba_inFA.Length)
                {

                    if (lba_inFA[i] == lba_inFA[j])
                    {
                        li_Count++;
                    }


                    if (lba_inFA[i] != lba_inFA[j])
                    {
                        lb_Byte = lba_inFA[i];
                        list_EncryptFirst.Add((Byte)li_Count);
                        list_EncryptFirst.Add(lb_Byte);
                        li_Count = 1;
                    }


                    if (li_Count == 255)
                    {
                        lb_Byte = lba_inFA[i];
                        list_EncryptFirst.Add((Byte)li_Count);
                        list_EncryptFirst.Add(lb_Byte);
                        li_Count = 0;
                    }
                }

                else
                {
                    lb_Byte = lba_inFA[i];
                    list_EncryptFirst.Add((Byte)li_Count);
                    list_EncryptFirst.Add(lb_Byte);
                    li_Count = 1;
                }
            }

            List<Byte> list_EncryptTwo = new List<Byte>();
            li_Count = 0;
            Int32 li_MarkFirst = 0;
            Boolean lb_FindMark = false;
            for (int i = 0; i < list_EncryptFirst.Count; i += 2)
            {
                if (list_EncryptFirst[i] == 1)
                {
                    if (lb_FindMark == false)
                    {
                        lb_FindMark = true;
                        li_MarkFirst = i + 1;
                        list_EncryptTwo.Add(00);
                    }

                    li_Count++;
                    if (li_Count == 255)
                    {
                        list_EncryptTwo.Add((Byte)li_Count);
                        for (int x = 0; x < li_Count; x++)
                        {
                            list_EncryptTwo.Add(list_EncryptFirst[li_MarkFirst]);
                            li_MarkFirst += 2;
                        }
                        lb_FindMark = false;
                        li_Count = 0;
                    }
                }
                if (list_EncryptFirst[i] != 1)
                {
                    if (lb_FindMark == true)
                    {
                        list_EncryptTwo.Add((Byte)li_Count);
                        for (int x = 0; x < li_Count; x++)
                        {
                            list_EncryptTwo.Add(list_EncryptFirst[li_MarkFirst]);
                            li_MarkFirst += 2;
                        }
                        lb_FindMark = false;
                        li_Count = 0;
                        i -= 2;
                    }
                    else
                    {
                        list_EncryptTwo.Add(list_EncryptFirst[i]);
                        list_EncryptTwo.Add(list_EncryptFirst[i + 1]);
                    }
                }
                if (i == list_EncryptFirst.Count - 2 & lb_FindMark == true)
                {
                    list_EncryptTwo.Add((Byte)li_Count);
                    for (int x = 0; x < li_Count; x++)
                    {
                        list_EncryptTwo.Add(list_EncryptFirst[li_MarkFirst]);
                        li_MarkFirst += 2;
                    }
                }
            }
            Byte[] lba_Extension = Encoding.Default.GetBytes(Path.GetExtension(pc_FTA.SelectedFile));
            list_EncryptTwo.InsertRange(0, lba_Extension);
            String ls_ArchiveFileName = Path.GetDirectoryName(pc_FTA.SelectedFilePath) + "\\" + Path.GetFileNameWithoutExtension(pc_FTA.SelectedFile) + ".uda";
            FileStream lfs_WriteArchive = new FileStream(ls_ArchiveFileName, FileMode.Create);
            Byte[] ba_Archive = new Byte[list_EncryptTwo.Count];
            list_EncryptTwo.CopyTo(ba_Archive);
            lfs_WriteArchive.Write(ba_Archive, 0, ba_Archive.Length);
            lfs_WriteArchive.Close();
            button_AddToArchive.Enabled = false;
            label_Status.Text = "ВЫПОЛНЕНО";
        }

        private void button_ExtractFromArchive_Click(object sender, EventArgs e)
        {
            FileStream lfs_ReadArchive = new FileStream(pc_FTA.SelectedFilePath, FileMode.Open);
            BinaryReader lbr_ReadArchive = new BinaryReader(lfs_ReadArchive);
            Byte[] ba_Extension = lbr_ReadArchive.ReadBytes(4);
            Byte[] ba_ArchivedFile = lbr_ReadArchive.ReadBytes((int)lfs_ReadArchive.Length);
            lbr_ReadArchive.Close();
            lfs_ReadArchive.Close();
            List<Byte> list_Extract = new List<Byte>();
            int m = 0;
            while (m != ba_ArchivedFile.Length)
            {
                if (ba_ArchivedFile[m] == 00)
                {
                    Int32 j = m + 1;
                    for (int i = 1; i < (int)ba_ArchivedFile[j] + 1; i++)
                    {
                        list_Extract.Add(ba_ArchivedFile[j + i]);
                    }
                    m = m + (int)ba_ArchivedFile[j] + 2;
                }
                else
                {
                    for (int i = 0; i < (int)ba_ArchivedFile[m]; i++)
                    {
                        list_Extract.Add(ba_ArchivedFile[m + 1]);
                    }
                    m += 2;
                }
            }

            String ls_Extension = Encoding.Default.GetString(ba_Extension);
            String ls_ExtractFileName = Path.GetDirectoryName(pc_FTA.SelectedFilePath) + "\\" + Path.GetFileNameWithoutExtension(pc_FTA.SelectedFile) + "extr" + ls_Extension;
            FileStream lfs_WriteArchive = new FileStream(ls_ExtractFileName, FileMode.Create);
            Byte[] ba_Extract = new Byte[list_Extract.Count];
            list_Extract.CopyTo(ba_Extract);
            lfs_WriteArchive.Write(ba_Extract, 0, ba_Extract.Length);
            lfs_WriteArchive.Close();
            button_ExtractFromArchive.Enabled = false;
            label_Status.Text = "ВЫПОЛНЕНО";
        }

    }
}
