using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.SS.Util;
using System.Collections;

 
///------------------------------------------------------------------------------
///Copyright:Copyright (c) 2010,广州精点科技有限公司 All rights reserved.
///描  述：excel文件 操作类
///版本号：1.0.0.1
///作  者：何国威(hegw@kingpointcn.com)
///日  期：2010年9月15日
///修  改：
///原  因：
///------------------------------------------------------------------------------

namespace Common
{
    public class ExcelHelper
    {

        /// <summary>
        /// 描  述：datatable 保存为excel
        /// 作  者：何国威(hegw@kingpointcn.com)
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName">路径</param>
        public static void ExportEasy(DataTable dtSource, string strFilePath)
        {
            try
            {

                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("Sheet1");

                //填充表头
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                foreach (DataColumn column in dtSource.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                }


                //填充内容
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    dataRow = (HSSFRow)sheet.CreateRow(i + 1);
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                    }
                }


                //保存
                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(ms);
                        ms.Flush();
                        ms.Position = 0;
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
                sheet.Dispose();
                workbook.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 描  述：DataTable导出到Excel文件 
        /// 作  者：何国威(hegw@kingpointcn.com)
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表标题</param>
        /// <param name="strFileName">路径</param>
        public static void Export(DataTable dtSource, string strHeaderText, string strFilePath, string sheetname)
        {
            try
            {
                using (MemoryStream ms = Export(dtSource, strHeaderText, sheetname))
                {
                    using (FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 描  述：DataTable导出到Excel的MemoryStream 
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表标题</param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText, string sheetname)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetname);
                //HSSFSheet shtt = workbook.CreateSheet("iuyiu");

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "";
                    //workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = ""; //填加xls文件作者信息
                    si.ApplicationName = ""; //填加xls文件创建程序信息
                    si.LastAuthor = ""; //填加xls文件最后保存者信息
                    si.Comments = ""; //填加xls文件作者信息
                    si.Title = ""; //填加xls文件标题信息
                    si.Subject = "";//填加文件主题信息
                    si.CreateDateTime = DateTime.Now;
                    //workbook.SummaryInformation = si;
                }
                #endregion

                HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽
                int[] arrColWidth = new int[dtSource.Columns.Count];
                foreach (DataColumn item in dtSource.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }



                int rowIndex = 0;

                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = (HSSFSheet)workbook.CreateSheet();
                        }

                        #region 表头及样式
                        {
                            //HSSFRow headerRow = sheet.CreateRow(0);
                            //headerRow.HeightInPoints = 25;
                            //headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            //HSSFCellStyle headStyle = workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            //HSSFFont font = workbook.CreateFont();
                            //font.FontHeightInPoints = 20;
                            //font.Boldweight = 700;
                            //headStyle.SetFont(font);

                            //headerRow.GetCell(0).CellStyle = headStyle;

                            //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                            //headerRow.Dispose();
                        }
                        #endregion


                        #region 列头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);


                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);


                            foreach (DataColumn column in dtSource.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                            }
                            //headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }


                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    sheet.Dispose();
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 描  述：
        /// 作  者：江芳海 (jiangfh@kingpointcn.com)
        /// 时  间：2011年10月26日
        /// 修  改：重写头部样式及列头样式
        /// 原  因：修改样式及生成套表功能
        /// </summary>
        /// 
        /// <param name="dtSources"></param>
        /// <param name="strHeaderTexts"></param>
        /// <param name="sheetnames"></param>
        /// <returns></returns>
        public static MemoryStream ExpendExport(DataTable[] dtSources, string[] strHeaderTexts, string[] sheetnames)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                for (int kk = 0; kk < sheetnames.Length; kk++)
                {
                    HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetnames[kk]);
                    //金额样式
                    HSSFCellStyle moneyStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    HSSFDataFormat format2 = (HSSFDataFormat)workbook.CreateDataFormat();
                    moneyStyle.DataFormat = format2.GetFormat("#,##0");
                    

                    #region 右击文件 属性信息
                    {
                        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                        dsi.Company = "";
                        //workbook.DocumentSummaryInformation = dsi;

                        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                        si.Author = ""; //填加xls文件作者信息
                        si.ApplicationName = ""; //填加xls文件创建程序信息
                        si.LastAuthor = ""; //填加xls文件最后保存者信息
                        si.Comments = ""; //填加xls文件作者信息
                        si.Title = ""; //填加xls文件标题信息
                        si.Subject = "";//填加文件主题信息
                        si.CreateDateTime = DateTime.Now;
                        //workbook.SummaryInformation = si;
                    }
                    #endregion

                    HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                    //取得列宽
                    int[] arrColWidth = new int[dtSources[kk].Columns.Count];
                    foreach (DataColumn item in dtSources[kk].Columns)
                    {
                        arrColWidth[item.Ordinal] = Encoding.GetEncoding(950).GetBytes(item.ColumnName.ToString()).Length;
                    }
                    for (int i = 0; i < dtSources[kk].Rows.Count; i++)
                    {
                        for (int j = 0; j < dtSources[kk].Columns.Count; j++)
                        {
                            int intTemp = Encoding.GetEncoding(950).GetBytes(dtSources[kk].Rows[i][j].ToString()).Length;
                            if (intTemp > arrColWidth[j])
                            {
                                arrColWidth[j] = intTemp;
                            }
                        }
                    }



                    int rowIndex = 0;

                    foreach (DataRow row in dtSources[kk].Rows)
                    {
                        #region 新建表，填充表头，填充列头，样式
                        if (rowIndex == 65535 || rowIndex == 0)
                        {
                            if (rowIndex != 0)
                            {
                                sheet = (HSSFSheet)workbook.CreateSheet();
                            }

                            #region 表头及样式
                            {
                                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                                headerRow.HeightInPoints = 30;
                                
                                headerRow.CreateCell(0).SetCellValue(strHeaderTexts[kk]);
                                HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                HSSFFont font = (HSSFFont)workbook.CreateFont();
                                font.FontHeightInPoints = 20;
                                font.Boldweight = 600;
                                headStyle.SetFont(font);

                                headerRow.GetCell(0).CellStyle = headStyle;

                                sheet.AddMergedRegion(new Region(0, 0, 0, dtSources[kk].Columns.Count - 1));
                                //headerRow.Dispose();
                                rowIndex++;
                            }
                            #endregion


                            #region 列头及样式
                            {
                                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex);
                                headerRow.HeightInPoints =25;

                                HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                                headStyle.Alignment = HorizontalAlignment.CENTER;
                                HSSFFont font = (HSSFFont)workbook.CreateFont();
                                font.FontHeightInPoints = 15;
                                font.Boldweight = 500;
                                headStyle.SetFont(font);
                                headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.GOLD.index;
                                headStyle.FillPattern = FillPatternType.SQUARES;
                                headStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.GOLD.index;
                                headStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                                headStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                                headStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                                headStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;

                                foreach (DataColumn column in dtSources[kk].Columns)
                                {
                                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                    //设置列宽
                                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 7) * 256);

                                }
                                //headerRow.Dispose();
                            }
                            #endregion

                            rowIndex++;
                        }
                        #endregion


                        #region 填充内容
                        HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                        dataRow.HeightInPoints = 20;
                        foreach (DataColumn column in dtSources[kk].Columns)
                        {
                            HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                            string drValue = row[column].ToString();

                            switch (column.DataType.ToString())
                            {
                                case "System.String"://字符串类型
                                    newCell.SetCellValue(drValue);
                                    break;
                                case "System.DateTime"://日期类型
                                    DateTime dateV;
                                    DateTime.TryParse(drValue, out dateV);
                                    newCell.SetCellValue(dateV);

                                    newCell.CellStyle = dateStyle;//格式化显示
                                    break;
                                case "System.Boolean"://布尔型
                                    bool boolV = false;
                                    bool.TryParse(drValue, out boolV);
                                    newCell.SetCellValue(boolV);
                                    break;
                                case "System.Int16"://整型
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(drValue, out intV);
                                    newCell.SetCellValue(intV);
                                    newCell.CellStyle = moneyStyle;//格式化显示
                                    break;
                                case "System.Decimal"://浮点型
                                case "System.Double":
                                    double doubV = 0;
                                    double.TryParse(drValue, out doubV);
                                    newCell.SetCellValue(doubV);
                                    newCell.CellStyle = moneyStyle;//格式化显示
                                    break;
                                case "System.DBNull"://空值处理
                                    newCell.SetCellValue("");
                                    break;
                                default:
                                    newCell.SetCellValue("");
                                    break;
                            }

                        }
                        #endregion

                        rowIndex++;
                    }
                    
                }//end for(int i=0)

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    //sheet.Dispose();
                    workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }

        }

        /// <summary>
        /// 描  述：DataTable导出到Excel的MemoryStream 
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("Sheet1");
                //HSSFSheet shtt = workbook.CreateSheet("iuyiu");

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "#";
                    workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = ""; //填加xls文件作者信息
                    si.ApplicationName = ""; //填加xls文件创建程序信息
                    si.LastAuthor = ""; //填加xls文件最后保存者信息
                    si.Comments = ""; //填加xls文件作者信息
                    si.Title = ""; //填加xls文件标题信息
                    si.Subject = "";//填加文件主题信息
                    si.CreateDateTime = DateTime.Now;
                    workbook.SummaryInformation = si;
                }
                #endregion

                HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽
                int[] arrColWidth = new int[dtSource.Columns.Count];
                foreach (DataColumn item in dtSource.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }



                int rowIndex = 0;
                //常规样式
                HSSFCellStyle cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFFont font1 = (HSSFFont)workbook.CreateFont();
                font1.IsItalic = false;
                cellStyle.SetFont(font1);
                cellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                cellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                cellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                cellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;
                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = (HSSFSheet)workbook.CreateSheet("Sheet1");
                        }




                        #region 列头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);


                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                            headStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                            headStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                            headStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;

                            foreach (DataColumn column in dtSource.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                            }
                            //headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);
                     
                        newCell.CellStyle = cellStyle;
                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }


                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    sheet.Dispose();
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 描  述：导出excel
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表头文文字</param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            try
            {
                // 设置编码和附件格式
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode(strFileName + DateTime.Now.ToString("yyyy-MM-dd_hh-mm"), Encoding.UTF8) + ".xls");

                curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strFileName).GetBuffer());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //curContext.Response.End();
        }


        /// <summary>
        /// 描  述：导出excel
        /// 时  间：2013年12月110日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表头文文字</param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(string  dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            try
            {
                // 设置编码和附件格式
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode(strFileName + DateTime.Now.ToString("yyyy-MM-dd_hh-mm"), Encoding.UTF8) + ".xls");
                curContext.Response.Write(dtSource);
                curContext.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //curContext.Response.End();
        }




        /// <summary>
        /// 描  述：导出excel 不含标题
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(DataTable dtSource, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            try
            {
                //sheet.Name = "sheet1";
                //string outFileName = fileName + ".xlsx";
                //System.Web.HttpResponse httpResponse = System.Web.HttpContext.Current.Response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", outFileName));
                //workbook.Save(httpResponse.OutputStream);
                //workbook.Close();
                //httpResponse.End();

                // 设置编码和附件格式
                curContext.Response.ContentType = "Application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8) + ".xls");
                curContext.Response.BinaryWrite(Export(dtSource).GetBuffer());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //curContext.Response.End();解决报错
        }


        ///// <summary>
        ///// 描  述：读取excel 
        ///// 作  者：何国威(hegw@kingpointcn.com)
        ///// 时  间：2010年9月15日
        ///// 修  改：
        ///// 原  因：
        ///// </summary>
        ///// <param name="strFileName">路径</param>
        ///// <returns></returns>
        //public static DataTable Import(string strFilePath)
        //{
        //    TxtAndExcelJoiner mTxtAndExcelJoiner = new TxtAndExcelJoiner();
        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        HSSFWorkbook hssfworkbook;
        //        using (FileStream file = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
        //        {
        //            hssfworkbook = new HSSFWorkbook();
        //        }

        //        HSSFSheet sheet = hssfworkbook.GetSheetAt(0);

        //        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

        //        HSSFRow headerRow = sheet.GetRow(0);
        //        int cellCount = headerRow.LastCellNum;

        //        for (int j = 0; j < cellCount; j++)
        //        {
        //            HSSFCell cell = headerRow.GetCell(j);
        //            dt.Columns.Add(cell.ToString());
        //        }

        //        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        //        {
        //            HSSFRow row = sheet.GetRow(i);
        //            DataRow dataRow = dt.NewRow();

        //            for (int j = row.FirstCellNum; j < cellCount; j++)
        //            {
        //                if (row.GetCell(j) != null)
        //                    dataRow[j] = row.GetCell(j).ToString();
        //            }

        //            dt.Rows.Add(dataRow);
        //        }
        //        mTxtAndExcelJoiner.DeleteFile(strFilePath);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        //删除文件
        //        mTxtAndExcelJoiner.DeleteFile(strFilePath);
        //        throw ex;
        //    }
        //}



        ///// <summary>
        ///// 描  述：读取多个excel文件 传入ListItem[] 合并第二个表默认去掉标题
        ///// 作  者：何国威(hegw@kingpointcn.com)
        ///// 时  间：2010年9月15日
        ///// 修  改：
        ///// 原  因：
        ///// </summary>
        ///// <param name="myListItemArray1"></param>
        ///// <returns></returns>
        //public static DataTable Import(ListItem[] myListItemArray1)
        //{
        //    TxtAndExcelJoiner mTxtAndExcelJoiner = new TxtAndExcelJoiner();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        HSSFWorkbook hssfworkbook;
        //        int excelCount = 1;
        //        for (int i = 0; i < myListItemArray1.Length; i++)
        //        {
        //            using (FileStream file = new FileStream(myListItemArray1[i].ToString(), FileMode.Open, FileAccess.Read))
        //            {
        //                hssfworkbook = new HSSFWorkbook(file);
        //            }
        //            HSSFSheet sheet = hssfworkbook.GetSheetAt(0);
        //            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

        //            HSSFRow headerRow = sheet.GetRow(0);
        //            int cellCount = headerRow.LastCellNum;

        //            if (excelCount == 1)//第二张excel开始去掉表头
        //            {
        //                for (int j = 0; j < cellCount; j++)
        //                {
        //                    HSSFCell cell = headerRow.GetCell(j);
        //                    dt.Columns.Add(cell.ToString());
        //                }
        //            }
        //            excelCount++;
        //            for (int t = (sheet.FirstRowNum + 1); t <= sheet.LastRowNum; t++)
        //            {
        //                HSSFRow row = sheet.GetRow(t);
        //                DataRow dataRow = dt.NewRow();

        //                for (int j = row.FirstCellNum; j < cellCount; j++)
        //                {
        //                    if (row.GetCell(j) != null)
        //                        dataRow[j] = row.GetCell(j).ToString();
        //                }

        //                dt.Rows.Add(dataRow);
        //            }
        //        }
        //        mTxtAndExcelJoiner.DeleteFile(myListItemArray1);//删除文件
        //        return dt;

        //    }
        //    catch (Exception ex)
        //    {

        //        mTxtAndExcelJoiner.DeleteFile(myListItemArray1);//删除文件
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// 描  述：DataTable导出到Excel的MemoryStream 
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表标题</param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, string sheetname, Hashtable opertypeparameters)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetname);
                //HSSFSheet shtt = workbook.CreateSheet("iuyiu");

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "";
                    //workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = ""; //填加xls文件作者信息
                    si.ApplicationName = ""; //填加xls文件创建程序信息
                    si.LastAuthor = ""; //填加xls文件最后保存者信息
                    si.Comments = ""; //填加xls文件作者信息
                    si.Title = ""; //填加xls文件标题信息
                    si.Subject = "";//填加文件主题信息
                    si.CreateDateTime = DateTime.Now;
                    //workbook.SummaryInformation = si;
                }
                #endregion

                HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽
                int[] arrColWidth = new int[dtSource.Columns.Count];
                foreach (DataColumn item in dtSource.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }



                int rowIndex = 0;

                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = (HSSFSheet)workbook.CreateSheet();
                        }

                        #region 表头及样式
                        {
                            //HSSFRow headerRow = sheet.CreateRow(0);
                            //headerRow.HeightInPoints = 25;
                            //headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            //HSSFCellStyle headStyle = workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            //HSSFFont font = workbook.CreateFont();
                            //font.FontHeightInPoints = 20;
                            //font.Boldweight = 700;
                            //headStyle.SetFont(font);

                            //headerRow.GetCell(0).CellStyle = headStyle;

                            //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                            //headerRow.Dispose();
                        }
                        #endregion


                        #region 列头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);


                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);


                            foreach (DataColumn column in dtSource.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                            }
                            //headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion
                    //常规样式
                    HSSFCellStyle cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                    HSSFFont font1 = (HSSFFont)workbook.CreateFont();
                    font1.IsItalic = false;
                    cellStyle.SetFont(font1);
                    cellStyle.BorderBottom = NPOI.SS.UserModel.CellBorderType.THIN;
                    cellStyle.BorderLeft = NPOI.SS.UserModel.CellBorderType.THIN;
                    cellStyle.BorderRight = NPOI.SS.UserModel.CellBorderType.THIN;
                    cellStyle.BorderTop = NPOI.SS.UserModel.CellBorderType.THIN;

                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);
                        newCell.CellStyle = cellStyle;
                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            case "System.Guid"://Guid
                                newCell.SetCellValue(drValue);
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
                if (opertypeparameters != null && opertypeparameters.Count != 0)
                {

                    foreach (DictionaryEntry each in opertypeparameters)
                    {
                        CellRangeAddressList regions = new CellRangeAddressList(1, 65534, (int)each.Key, (int)each.Key);
                        //DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "itemA", "itemB", "itemC" });
                        DVConstraint constraint = DVConstraint.CreateExplicitListConstraint((string[])each.Value);
                        HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
                        sheet.AddValidationData(dataValidate);
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    sheet.Dispose();
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// 描  述：导出excel
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表头文文字</param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(DataTable dtSource, Hashtable opertypeparameters, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            try
            {
                // 设置编码和附件格式
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode(strFileName + DateTime.Now.ToString("yyyy-MM-dd_hh-mm"), Encoding.UTF8) + ".xls");

                curContext.Response.BinaryWrite(Export(dtSource, strFileName, opertypeparameters).GetBuffer());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //curContext.Response.End();
        }

        /// <summary>
        /// 描  述：读取模板Excel初始化
        /// 作  者：林明龙 (linml@kingpointcn.com)
        /// 时  间：2011年8月22日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static HSSFWorkbook InitializeWorkbook(string filePath, string subject)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfWorkbook = new HSSFWorkbook(file);
            DataFormat format = hssfWorkbook.CreateDataFormat();
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            hssfWorkbook.DocumentSummaryInformation = dsi;
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = subject;
            hssfWorkbook.SummaryInformation = si;

            return hssfWorkbook;
        }



        /// <summary>
        /// 描  述：导出excel
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表头文文字</param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(DataTable dtSource, DataTable dtSource1, string strHeaderText, string strFileName, string strFileName1)
        {
            HttpContext curContext = HttpContext.Current;
            try
            {
                // 设置编码和附件格式
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = Encoding.UTF8;
                curContext.Response.Charset = "";
                curContext.Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" + HttpUtility.UrlEncode(strFileName + DateTime.Now.ToString("yyyy-MM-dd_hh-mm"), Encoding.UTF8) + ".xls");

                curContext.Response.BinaryWrite(Export(dtSource, dtSource1, strHeaderText, strFileName, strFileName1).GetBuffer());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //curContext.Response.End();
        }



        /// <summary>
        /// 描  述：DataTable导出到Excel的MemoryStream 
        /// 时  间：2010年9月15日
        /// 修  改：
        /// 原  因：
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText">表标题</param>
        /// <returns></returns>
        public static MemoryStream Export(DataTable dtSource, DataTable dtSource1, string strHeaderText, string sheetname, string sheetname1)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                 HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(sheetname);
                HSSFSheet sheet1 = (HSSFSheet)workbook.CreateSheet(sheetname1);
 
                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "";
                    //workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = ""; //填加xls文件作者信息
                    si.ApplicationName = ""; //填加xls文件创建程序信息
                    si.LastAuthor = ""; //填加xls文件最后保存者信息
                    si.Comments = ""; //填加xls文件作者信息
                    si.Title = ""; //填加xls文件标题信息
                    si.Subject = "";//填加文件主题信息
                    si.CreateDateTime = DateTime.Now;
                    //workbook.SummaryInformation = si;
                }
                #endregion

                HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");


                #region 表1
                //取得列宽
                int[] arrColWidth = new int[dtSource.Columns.Count];
                foreach (DataColumn item in dtSource.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }



                int rowIndex = 0;

                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = (HSSFSheet)workbook.CreateSheet();
                        }
 

                        #region 列头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);


                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);


                            foreach (DataColumn column in dtSource.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                            }
                            //headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
                #endregion


                #region 表2
                //取得列宽
                arrColWidth = new int[dtSource1.Columns.Count];
                foreach (DataColumn item in dtSource1.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource1.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource1.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource1.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                rowIndex = 0;

                foreach (DataRow row in dtSource1.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet1 = (HSSFSheet)workbook.CreateSheet();
                        }


                        #region 列头及样式
                        {
                            HSSFRow headerRow = (HSSFRow)sheet1.CreateRow(0);
       
                            HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                            HSSFFont font = (HSSFFont)workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);


                            foreach (DataColumn column in dtSource1.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet1.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                            }
                            //headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    HSSFRow dataRow = (HSSFRow)sheet1.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource1.Columns)
                    {
                        HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);

                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
                #endregion




                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    sheet.Dispose();
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






    }

}