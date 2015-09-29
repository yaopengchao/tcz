// Excel2007ReadWrite created by Zeljko Svedic. This source code is free to use, modify and 
// incorporate in your software products. This code is not owned by GemBoxSoftware.com or is
// related in any way to GemBox.Spreadsheet Free/Professional .NET component.

using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
using Model;
using BLL;
using LoginFrame;

namespace Excel2007ReadWrite
{
    class ExcelRW
    {
        private static UserService userService = new UserService();

        public static void DeleteDirectoryContents(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);

            foreach (FileInfo currFile in di.GetFiles())
                currFile.Delete();

            foreach (DirectoryInfo currDir in di.GetDirectories())
                currDir.Delete(true);
        }

        public static void UnzipFile(string zipFileName, string targetDirectory)
        {
            (new FastZip()).ExtractZip(zipFileName, targetDirectory, null);
        }

        public static void ZipDirectory(string sourceDirectory, string zipFileName)
        {
            (new FastZip()).CreateZip(zipFileName, sourceDirectory, true, null);
        }

        public static ArrayList ReadStringTable(Stream input)
        {
            ArrayList stringTable = new ArrayList();

            using (XmlTextReader reader = new XmlTextReader(input))
            {
                for (reader.MoveToContent(); reader.Read();)
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "t")
                        stringTable.Add(reader.ReadElementString());
            }

            return stringTable;
        }

        public static void ReadWorksheet(Stream input, ArrayList stringTable, DataTable data, int classid,string user_type)
        {
            using (XmlTextReader reader = new XmlTextReader(input))
            {
                DataRow dr = null;
                int colIndex = 0;
                string type;
                int val;

                for (reader.MoveToContent(); reader.Read();)
                    if (reader.NodeType == XmlNodeType.Element)
                        switch (reader.Name)
                        {
                            case "row":
                                dr = data.NewRow();

                               

                                data.Rows.Add(dr);

                                colIndex = 0;
                                break;

                            case "c":

                                type = reader.GetAttribute("t");
                                reader.Read();
                                val = int.Parse(reader.ReadElementString());

                                if (type == "s")
                                    dr[colIndex] = stringTable[val];
                                else
                                    dr[colIndex] = val;

                                colIndex++;
                                //Console.WriteLine("hello");

                                if (colIndex==3)
                                {
                                    if (user_type== Constant.RoleStudent)
                                    {
                                        //加入数据库中
                                        if (addUser(dr, classid))
                                        {
                                            dr[3] = "导入成功";
                                        }
                                        else
                                        {
                                            dr[3] = "导入失败";
                                        }
                                    }
                                }
                                break;
                        }
            }

        }

        private static bool addUser(DataRow dr,int classid)
        {
            int result = 0;
            int userId = Convert.ToInt32("0");
            User user = new User();
            user.LoginId = (string)dr[0];
            user.UserName = (string)dr[1];
            user.UserType = "3";
            user.Pwd = (string)dr[2];
            DateTime dt = DateTime.Now;
            if (userId > 0)            //修改
            {
                user.UserId = userId;
                result = userService.updateUser(user);
            }
            else
            {
                user.CreateDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
                result = userService.addUser(user, classid);
            }

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ArrayList CreateStringTables(DataTable data, out Hashtable lookupTable)
        {
            ArrayList stringTable = new ArrayList();
            lookupTable = new Hashtable();

            foreach (DataRow row in data.Rows)
                foreach (DataColumn column in data.Columns)
                    if (column.DataType == typeof(string))
                    {
                        string val = (string)row[column];

                        if (!lookupTable.Contains(val))
                        {
                            lookupTable.Add(val, stringTable.Count);
                            stringTable.Add(val);
                        }
                    }

            return stringTable;
        }

        public static void WriteStringTable(Stream output, ArrayList stringTable)
        {
            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.UTF8))
            {
                writer.WriteStartDocument(true);

                writer.WriteStartElement("sst");
                writer.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                writer.WriteAttributeString("count", stringTable.Count.ToString());
                writer.WriteAttributeString("uniqueCount", stringTable.Count.ToString());

                foreach (string str in stringTable)
                {
                    writer.WriteStartElement("si");
                    writer.WriteElementString("t", str);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        public static string RowColumnToPosition(int row, int column)
        {
            return ExcelRW.ColumnIndexToName(column) + ExcelRW.RowIndexToName(row);
        }

        public static string ColumnIndexToName(int columnIndex)
        {
            char second = (char)(((int)'A') + columnIndex % 26);

            columnIndex /= 26;

            if (columnIndex == 0)
                return second.ToString();
            else
                return ((char)(((int)'A') - 1 + columnIndex)).ToString() + second.ToString();
        }

        public static string RowIndexToName(int rowIndex)
        {
            return (rowIndex + 1).ToString();
        }

        public static void WriteWorksheet(Stream output, DataTable data, Hashtable lookupTable)
        {
            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.UTF8))
            {
                writer.WriteStartDocument(true);

                writer.WriteStartElement("worksheet");
                writer.WriteAttributeString("xmlns", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                writer.WriteAttributeString("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

                writer.WriteStartElement("dimension");
                string lastCell = ExcelRW.RowColumnToPosition(data.Rows.Count - 1, data.Columns.Count - 1);
                writer.WriteAttributeString("ref", "A1:" + lastCell);
                writer.WriteEndElement();

                writer.WriteStartElement("sheetViews");
                writer.WriteStartElement("sheetView");
                writer.WriteAttributeString("tabSelected", "1");
                writer.WriteAttributeString("workbookViewId", "0");
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("sheetFormatPr");
                writer.WriteAttributeString("defaultRowHeight", "15");
                writer.WriteEndElement();

                writer.WriteStartElement("sheetData");
                ExcelRW.WriteWorksheetData(writer, data, lookupTable);
                writer.WriteEndElement();

                writer.WriteStartElement("pageMargins");
                writer.WriteAttributeString("left", "0.7");
                writer.WriteAttributeString("right", "0.7");
                writer.WriteAttributeString("top", "0.75");
                writer.WriteAttributeString("bottom", "0.75");
                writer.WriteAttributeString("header", "0.3");
                writer.WriteAttributeString("footer", "0.3");
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }

        public static void WriteWorksheetData(XmlTextWriter writer, DataTable data, Hashtable lookupTable)
        {
            int rowsCount = data.Rows.Count;
            int columnsCount = data.Columns.Count;
            string relPos;

            for (int row = 0; row < rowsCount; row++)
            {
                writer.WriteStartElement("row");
                relPos = ExcelRW.RowIndexToName(row);
                writer.WriteAttributeString("r", relPos);
                writer.WriteAttributeString("spans", "1:" + columnsCount.ToString());

                for (int column = 0; column < columnsCount; column++)
                {
                    object val = data.Rows[row][column];

                    writer.WriteStartElement("c");
                    relPos = ExcelRW.RowColumnToPosition(row, column);
                    writer.WriteAttributeString("r", relPos);

                    if (val.GetType() == typeof(string))
                    {
                        writer.WriteAttributeString("t", "s");
                        val = lookupTable[val];
                    }

                    writer.WriteElementString("v", val.ToString());

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}
