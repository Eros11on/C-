using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace DAL
{
	/// <summary>
	/// 数据访问类:cardinfo
	/// </summary>
	public class cardinfo
	{
		public cardinfo()
		{ }
		#region  Method
		/// <summary>
		/// 根据身份证查账户
		/// </summary>
		/// <param name="PID">身份证</param>
		/// <returns>账户数据集</returns>
		public DataSet search(string PID)
		{
			string sql = @"SELECT cardID,curType,savingType,openDate,
                            balance,[IsReportLoss],userInfo.customerName
                            FROM cardinfo, userInfo
                            where cardinfo.customerID = userInfo.customerID 
                            and userInfo.pID = '" + PID + "'";
			DataSet ds = DbHelperSQL.Query(sql);
			return ds;
		}

		/// <summary>
		/// 获取挂失状态。
		/// </summary>
		/// <param name="CardID">卡号</param>
		/// <returns>true为已挂失</returns>
		public bool getState(string CardID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select IsReportLoss from cardinfo ");
			strSql.Append(" where cardID='" + CardID + "'");
			object r = DbHelperSQL.GetSingle(strSql.ToString());
			bool re = false;

			string xxx = r.ToString();
			if (r.ToString() == "True") { re = true; }
			return re;
		}

		public bool changePwd(string CardID, string oldPwd, string newPwd)
		{
			string sql = "update  cardinfo set  pass='" + newPwd + "' where cardID='" + CardID + "' and pass='" + oldPwd + "'  and IsReportLoss=0";
			int n = DbHelperSQL.ExecuteSql(sql);
			if (n >= 1)
			{
				return true;
			}
			else
			{ return false; }
		}

		//更改状态。
		public bool ChangeState(string CardID)
		{

			string sql = "update  cardinfo set  IsReportLoss=((IsReportLoss+1) % 2) where cardID='" + CardID + "' ";
			int n = DbHelperSQL.ExecuteSql(sql);
			if (n >= 1)
			{
				return true;
			}
			else
			{ return false; }
		}
		public bool UpdateBalance(string CardID, decimal MoneyNum, string remark)
		{
			//增加交易记录
			Model.transInfo t = new Model.transInfo();
			t.cardID = CardID;
			t.transDate = DateTime.Now;
			t.transMoney = Math.Abs(MoneyNum);
			t.transType = "存入";
			t.remark = remark;
			string sql = "update  cardinfo set balance=balance+" + MoneyNum + " where cardID='" + CardID + "' and IsReportLoss=0";
			if (MoneyNum < 0)
			{
				//先判断余额是否足
				Model.cardinfo c = GetModel(CardID);
				if (c != null)
				{
					if (c.balance < Math.Abs(MoneyNum))//余额不足
					{ return false; }
				}
				else
				{
					return false;

				}

				t.transType = "支取";
			}
			if (DbHelperSQL.ExecuteSql(sql) >= 1)//存取款成功 则增加交易记录
			{
				DAL.transInfo dalt = new DAL.transInfo();
				dalt.Add(t);
				return true;
			}

			return false;
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cardID, string pwd)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from cardinfo");
			strSql.Append(" where cardID='" + cardID + "' and pass='" + pwd + "'");
			return DbHelperSQL.Exists(strSql.ToString());
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cardID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from cardinfo");
			strSql.Append(" where cardID='" + cardID + "'");
			return DbHelperSQL.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.cardinfo model, out string cardID)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSql1 = new StringBuilder();
			StringBuilder strSql2 = new StringBuilder();

			cardID = "";
			//62212611  。1-6表示银行 7-8省份。9-15位才是自己的账户号，最后一位仍然是校验码  。中间7位

			//获取最新的银行卡号。新卡的账号。是卡号9-15位的数字+1.。最后一位是随机数
			string ss = getMaxCardID();

			if (ss == "") { cardID = "622126110000001"; } //第一个开卡的人
			else
			{
				int xx = int.Parse(ss.Substring(8, 7)) + 1;
				if (xx == 10000000) { return false; }//超额了
				cardID = ss.Substring(0, 8) + xx.ToString("D7");
			}
			Random r = new Random();
			cardID = cardID + r.Next(0, 10);

			model.cardID = cardID;

			if (model.cardID != null)
			{
				strSql1.Append("cardID,");
				strSql2.Append("'" + model.cardID + "',");
			}
			if (model.curType != null)
			{
				strSql1.Append("curType,");
				strSql2.Append("'" + model.curType + "',");
			}
			if (model.savingType != null)
			{
				strSql1.Append("savingType,");
				strSql2.Append("'" + model.savingType + "',");
			}
			if (model.openDate != null)
			{
				strSql1.Append("openDate,");
				strSql2.Append("'" + model.openDate + "',");
			}
			if (model.openMoney != null)
			{
				strSql1.Append("openMoney,");
				strSql2.Append("" + model.openMoney + ",");
			}
			if (model.balance != null)
			{
				strSql1.Append("balance,");
				strSql2.Append("" + model.balance + ",");
			}
			if (model.pass != null)
			{
				strSql1.Append("pass,");
				strSql2.Append("'" + model.pass + "',");
			}
			if (model.IsReportLoss != null)
			{
				strSql1.Append("IsReportLoss,");
				strSql2.Append("" + (model.IsReportLoss ? 1 : 0) + ",");
			}
			if (model.customerID != null)
			{
				strSql1.Append("customerID,");
				strSql2.Append("" + model.customerID + ",");
			}
			strSql.Append("insert into cardinfo(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				//增加交易记录
				Model.transInfo t = new Model.transInfo();
				t.cardID = model.cardID;
				t.transDate = model.openDate;
				t.transMoney = model.openMoney;
				t.transType = "存入";
				t.remark = "开户存入";

				DAL.transInfo dalt = new DAL.transInfo();
				dalt.Add(t);

				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 获取最新开卡人的账号
		/// </summary>
		/// <returns></returns>
		public string getMaxCardID()
		{
			string s = "";
			string sql = "select top 1 cardID from cardinfo order by openDate desc";
			object obj = DbHelperSQL.GetSingle(sql);
			if (!Object.Equals(obj, null))
			{
				s = obj.ToString();
			}
			return s;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.cardinfo model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update cardinfo set ");
			if (model.curType != null)
			{
				strSql.Append("curType='" + model.curType + "',");
			}
			else
			{
				strSql.Append("curType= null ,");
			}
			if (model.savingType != null)
			{
				strSql.Append("savingType='" + model.savingType + "',");
			}
			if (model.openDate != null)
			{
				strSql.Append("openDate='" + model.openDate + "',");
			}
			else
			{
				strSql.Append("openDate= null ,");
			}
			if (model.openMoney != null)
			{
				strSql.Append("openMoney=" + model.openMoney + ",");
			}
			if (model.balance != null)
			{
				strSql.Append("balance=" + model.balance + ",");
			}
			if (model.pass != null)
			{
				strSql.Append("pass='" + model.pass + "',");
			}
			else
			{
				strSql.Append("pass= null ,");
			}
			if (model.IsReportLoss != null)
			{
				strSql.Append("IsReportLoss=" + (model.IsReportLoss ? 1 : 0) + ",");
			}
			else
			{
				strSql.Append("IsReportLoss= null ,");
			}
			if (model.customerID != null)
			{
				strSql.Append("customerID=" + model.customerID + ",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where cardID='" + model.cardID + "' ");
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
		public bool Delete(string cardID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from cardinfo ");
			strSql.Append(" where cardID='" + cardID + "' ");
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
		public bool DeleteList(string cardIDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from cardinfo ");
			strSql.Append(" where cardID in (" + cardIDlist + ")  ");
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
		public Model.cardinfo GetModel(string cardID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" cardID,curType,savingType,openDate,openMoney,balance,pass,IsReportLoss,customerID ");
			strSql.Append(" from cardinfo ");
			strSql.Append(" where cardID='" + cardID + "' ");
			Model.cardinfo model = new Model.cardinfo();
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
		public Model.cardinfo DataRowToModel(DataRow row)
		{
			Model.cardinfo model = new Model.cardinfo();
			if (row != null)
			{
				if (row["cardID"] != null)
				{
					model.cardID = row["cardID"].ToString();
				}
				if (row["curType"] != null)
				{
					model.curType = row["curType"].ToString();
				}
				if (row["savingType"] != null)
				{
					model.savingType = row["savingType"].ToString();
				}
				if (row["openDate"] != null && row["openDate"].ToString() != "")
				{
					model.openDate = DateTime.Parse(row["openDate"].ToString());
				}
				if (row["openMoney"] != null && row["openMoney"].ToString() != "")
				{
					model.openMoney = decimal.Parse(row["openMoney"].ToString());
				}
				if (row["balance"] != null && row["balance"].ToString() != "")
				{
					model.balance = decimal.Parse(row["balance"].ToString());
				}
				if (row["pass"] != null)
				{
					model.pass = row["pass"].ToString();
				}
				if (row["IsReportLoss"] != null && row["IsReportLoss"].ToString() != "")
				{
					if ((row["IsReportLoss"].ToString() == "1") || (row["IsReportLoss"].ToString().ToLower() == "true"))
					{
						model.IsReportLoss = true;
					}
					else
					{
						model.IsReportLoss = false;
					}
				}
				if (row["customerID"] != null && row["customerID"].ToString() != "")
				{
					model.customerID = int.Parse(row["customerID"].ToString());
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
			strSql.Append("select cardID,curType,savingType,openDate,openMoney,balance,pass,IsReportLoss,customerID ");
			strSql.Append(" FROM cardinfo ");
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
			strSql.Append(" cardID,curType,savingType,openDate,openMoney,balance,pass,IsReportLoss,customerID ");
			strSql.Append(" FROM cardinfo ");
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
			strSql.Append("select count(1) FROM cardinfo ");
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
				strSql.Append("order by T.cardID desc");
			}
			strSql.Append(")AS Row, T.*  from cardinfo T ");
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