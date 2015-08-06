﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL;


/// <summary>
/// 分页控件数据提供类
/// </summary>
public class PageData
{
    private int _PageSize = 10;
    private int _PageIndex = 1;
    private int _PageCount = 0;
    private int _TotalCount = 0;
    private string _TableName;//表名
    private string _QueryFieldName = "*";//表字段FieldStr
    private string _OrderStr = string.Empty; //排序_SortStr
    private string _QueryCondition = string.Empty;//查询的条件 RowFilter
    private string _PrimaryKey = string.Empty;//主键
    private bool _isQueryTotalCounts = true;//是否查询总的记录条数
    /// <summary>
    /// 是否查询总的记录条数
    /// </summary>
    public bool IsQueryTotalCounts
    {
        get { return _isQueryTotalCounts; }
        set { _isQueryTotalCounts = value; }
    }
    /// <summary>
    /// 显示页数
    /// </summary>
    public int PageSize
    {
        get
        {
            return _PageSize;

        }
        set
        {
            _PageSize = value;
        }
    }
    /// <summary>
    /// 当前页
    /// </summary>
    public int PageIndex
    {
        get
        {
            return _PageIndex;
        }
        set
        {
            _PageIndex = value;
        }
    }
    /// <summary>
    /// 总页数
    /// </summary>
    public int PageCount
    {
        get
        {
            return _PageCount;
        }
    }
    /// <summary>
    /// 总记录数
    /// </summary>
    public int TotalCount
    {
        get
        {
            return _TotalCount;
        }
    }
    /// <summary>
    /// 表名，包括视图
    /// </summary>
    public string TableName
    {
        get
        {
            return _TableName;
        }
        set
        {
            _TableName = value;
        }
    }
    /// <summary>
    /// 表字段FieldStr
    /// </summary>
    public string QueryFieldName
    {
        get
        {
            return _QueryFieldName;
        }
        set
        {
            _QueryFieldName = value;
        }
    }
    /// <summary>
    /// 排序字段
    /// </summary>
    public string OrderStr
    {
        get
        {
            return _OrderStr;
        }
        set
        {
            _OrderStr = value;
        }
    }
    /// <summary>
    /// 查询条件
    /// </summary>
    public string QueryCondition
    {
        get
        {
            return _QueryCondition;
        }
        set
        {
            _QueryCondition = value;
        }
    }
    /// <summary>
    /// 主键
    /// </summary>
    public string PrimaryKey
    {
        get
        {
            return _PrimaryKey;
        }
        set
        {
            _PrimaryKey = value;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DataSet QueryDataTable()
    {
        SqlParameter[] parameters = {
                    new SqlParameter("@Tables", SqlDbType.VarChar, 255),
                    new SqlParameter("@PrimaryKey" , SqlDbType.VarChar , 255),    
                    new SqlParameter("@Sort", SqlDbType.VarChar , 255 ),
                    new SqlParameter("@CurrentPage", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),                                    
                    new SqlParameter("@Fields", SqlDbType.VarChar, 255),
                    new SqlParameter("@Filter", SqlDbType.VarChar,1000),
                    new SqlParameter("@Group" ,SqlDbType.VarChar , 1000 )
                    };
        parameters[0].Value = _TableName;
        parameters[1].Value = _PrimaryKey;
        parameters[2].Value = _OrderStr;
        parameters[3].Value = PageIndex;
        parameters[4].Value = PageSize;
        parameters[5].Value = _QueryFieldName;
        parameters[6].Value = _QueryCondition;
        parameters[7].Value = string.Empty;
        DataSet ds = null;// DbHelperSQL.RunProcedure("SP_Pagination", parameters, "dd");
        _TotalCount = GetTotalCount();
        if (_TotalCount == 0)
        {
            _PageIndex = 0;
            _PageCount = 0;
        }
        else
        {
            _PageCount = _TotalCount % _PageSize == 0 ? _TotalCount / _PageSize : _TotalCount / _PageSize + 1;
            if (_PageIndex > _PageCount)
            {
                _PageIndex = _PageCount;

                parameters[4].Value = _PageSize;

                ds = QueryDataTable();
            }
        }
        return ds;
    }
    /// <summary>
    /// 查询TableName的总记录数
    /// </summary>
    /// <returns></returns>
    public int GetTotalCount()
    {
        DBHelp help = new DBHelp();
        string strSql = " select count(1) from " + _TableName;
        if (_QueryCondition != string.Empty)
        {
            strSql += " where " + _QueryCondition;
        }
        return int.Parse(DBHelp.ExecuteScalar(strSql).ToString());
    }
}


