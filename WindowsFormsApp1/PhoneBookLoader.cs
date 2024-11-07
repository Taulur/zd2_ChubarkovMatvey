using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    class PhoneBookLoader
    {
        public static void Load(PhoneBook phoneBook, string filename, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            phoneBook.GetList().Clear();
            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(filename);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1]; 
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            int lastRow = (int)lastCell.Row;
  
            for (int i = 0; i < lastRow; i++) 
            {
                string[] split = ObjWorkSheet.Cells[i + 1, 1].Text.ToString().Split(';');
                string name = split[0];
                string phone = split[1];

                Contact contact = new Contact(name,phone);

                phoneBook.AddContact(contact);

            }
            foreach (Contact contact in phoneBook.GetList())
            {
                dataGridView.Rows.Add(contact.Name, contact.Phone);
            }

            ObjWorkBook.Close(false, Type.Missing, Type.Missing);
            ObjWorkExcel.Quit();
            GC.Collect();
        }
        public static void Save(PhoneBook phoneBook, string fileName)
        {
            var lines  = phoneBook.GetList().Select( c=> $"{c.Name};{c.Phone}" );
            File.WriteAllLines(fileName, lines);
        }
    }
}
