using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:userInfo
	/// </summary>
	public class userInfo
	{
		public userInfo()
		{ }
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return DbHelperSQL.GetMaxID("customerID", "userInfo");
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int customerID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from userInfo");
			strSql.Append(" where customerID=" + customerID + " ");
			return DbHelperSQL.Exists(strSql.ToString());
		}
		/// <summary>
		/// 用身份证号查询得到一个对象实体
		/// </summary>
		public Model.userInfo GetModel(string PID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" customerID,customerName,pID,telephone,address ");
			strSql.Append(" from userInfo ");
			strSql.Append(" where pID='" + PID + "'");
			Model.userInfo model = new Model.userInfo();
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
		/// 增加一条数据
		/// </summary>
		public int Add(Model.userInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();
			if (model.customerName != null)
			{
				strSql1.Append("customerName,");
				strSql2.Append("'" + model.customerName + "',");
			}
			if (model.pID != null)
			{
				strSql1.Append("pID,");
				strSql2.Append("'" + model.pID + "',");
			}
			if (model.telephone != null)
			{
				strSql1.Append("telephone,");
				strSql2.Append("'" + model.telephone + "',");
			}
			if (model.address != null)
			{
				strSql1.Append("address,");
				strSql2.Append("'" + model.address + "',");
			}
			strSql.Append("insert into userInfo(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.userInfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update userInfo set ");
			if (model.customerName != null)
			{
				strSql.Append("customerName='" + model.customerName + "',");
			}
			if (model.pID != null)
			{
				strSql.Append("pID='" + model.pID + "',");
			}
			if (model.telephone != null)
			{
				strSql.Append("telephone='" + model.telephone + "',");
			}
			if (model.address != null)
			{
				strSql.Append("address='" + model.address + "',");
			}
			else
			{
				strSql.Append("address= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where customerID=" + model.customerID + "");
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
		public bool Delete(int customerID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where customerID=" + customerID + "");
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
		public bool DeleteList(string customerIDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from userInfo ");
			strSql.Append(" where customerID in (" + customerIDlist + ")  ");
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
		public Model.userInfo GetModel(int customerID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" customerID,customerName,pID,telephone,address ");
			strSql.Append(" from userInfo ");
			strSql.Append(" where customerID=" + customerID + "");
			Model.userInfo model = new Model.userInfo();
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
		public Model.userInfo DataRowToModel(DataRow row)
		{
			Model.userInfo model = new Model.userInfo();
			if (row != null)
			{
				if (row["customerID"] != null && row["customerID"].ToString() != "")
				{
					model.customerID = int.Parse(row["customerID"].ToString());
				}
				if (row["customerName"] != null)
				{
					model.customerName = row["customerName"].ToString();
				}
				if (row["pID"] != null)
				{
					model.pID = row["pID"].ToString();
				}
				if (row["telephone"] != null)
				{
					model.telephone = row["telephone"].ToString();
				}
				if (row["address"] != null)
				{
					model.address = row["address"].ToString();
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
			strSql.Append("select customerID,customerName,pID,telephone,address ");
			strSql.Append(" FROM userInfo ");
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
			strSql.Append(" customerID,customerName,pID,telephone,address ");
			strSql.Append(" FROM userInfo ");
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
			strSql.Append("select count(1) FROM userInfo ");
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
				strSql.Append("order by T.customerID desc");
			}
			strSql.Append(")AS Row, T.*  from userInfo T ");
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