using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:transInfo
	/// </summary>
	public class transInfo
	{
		public transInfo()
		{ }
		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime transDate)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from transInfo");
			strSql.Append(" where transDate='" + transDate + "' ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.transInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			if (model.transDate != null)
			{
				strSql1.Append("transDate,");
				strSql2.Append("'" + model.transDate + "',");
			}
			if (model.cardID != null)
			{
				strSql1.Append("cardID,");
				strSql2.Append("'" + model.cardID + "',");
			}
			if (model.transType != null)
			{
				strSql1.Append("transType,");
				strSql2.Append("'" + model.transType + "',");
			}
			if (model.transMoney != null)
			{
				strSql1.Append("transMoney,");
				strSql2.Append("" + model.transMoney + ",");
			}
			if (model.remark != null)
			{
				strSql1.Append("remark,");
				strSql2.Append("'" + model.remark + "',");
			}
			strSql.Append("insert into transInfo(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.transInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update transInfo set ");
			if (model.cardID != null)
			{
				strSql.Append("cardID='" + model.cardID + "',");
			}
			if (model.transType != null)
			{
				strSql.Append("transType='" + model.transType + "',");
			}
			if (model.transMoney != null)
			{
				strSql.Append("transMoney=" + model.transMoney + ",");
			}
			if (model.remark != null)
			{
				strSql.Append("remark='" + model.remark + "',");
			}
			else
			{
				strSql.Append("remark= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where transDate='" + model.transDate + "' ");
			int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(DateTime transDate)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from transInfo ");
			strSql.Append(" where transDate='" + transDate + "' ");
			int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}       /// <summary>
				/// 批量删除数据
				/// </summary>
		public bool DeleteList(string transDatelist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from transInfo ");
			strSql.Append(" where transDate in (" + transDatelist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.transInfo GetModel(DateTime transDate)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" transDate,cardID,transType,transMoney,remark ");
			strSql.Append(" from transInfo ");
			strSql.Append(" where transDate='" + transDate + "' ");
			Model.transInfo model = new Model.transInfo();
			DataSet ds = DbHelperSQL.Query(strSql.ToString());
			if (ds.Tables[0].Rows.Count > 0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.transInfo DataRowToModel(DataRow row)
		{
			Model.transInfo model = new Model.transInfo();
			if (row != null)
			{
				if (row["transDate"] != null && row["transDate"].ToString() != "")
				{
					model.transDate = DateTime.Parse(row["transDate"].ToString());
				}
				if (row["cardID"] != null)
				{
					model.cardID = row["cardID"].ToString();
				}
				if (row["transType"] != null)
				{
					model.transType = row["transType"].ToString();
				}
				if (row["transMoney"] != null && row["transMoney"].ToString() != "")
				{
					model.transMoney = decimal.Parse(row["transMoney"].ToString());
				}
				if (row["remark"] != null)
				{
					model.remark = row["remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select transDate,cardID,transType,transMoney,remark ");
			strSql.Append(" FROM transInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" transDate,cardID,transType,transMoney,remark ");
			strSql.Append(" FROM transInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM transInfo ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.transDate desc");
			}
			strSql.Append(")AS Row, T.*  from transInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}
