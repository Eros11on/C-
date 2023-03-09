using System;
using System.Data;
using System.Collections.Generic;

using Model;
namespace BLL
{
	/// <summary>
	/// cardinfo
	/// </summary>
	public class cardinfo
	{
		private readonly DAL.cardinfo dal = new DAL.cardinfo();
		public cardinfo()
		{ }
		#region  BasicMethod
		public DataSet search(string PID)
		{
			return dal.search(PID);
		}
		public bool changePwd(string CardID, string oldPwd, string newPwd)
		{
			return dal.changePwd(CardID, oldPwd, newPwd);
		}
		public bool getState(string CardID)
		{
			return dal.getState(CardID);
		}
		public bool ChangeState(string CardID)
		{
			return dal.ChangeState(CardID);
		}
		public bool ZhuanZhang(string CardoutID, string CardInInID, decimal MoneyNum)
		{
			if (!dal.Exists(CardInInID)) { return false; } //接收方卡号不存在
			bool isok = false;
			if (UpdateBalance(CardoutID, -MoneyNum, "给" + CardInInID + "转账支出"))
			{
				isok = true;
				if (!UpdateBalance(CardInInID, MoneyNum, "收" + CardoutID + "的转帐"))
				{
					isok = false;
					UpdateBalance(CardoutID, MoneyNum, "撤销给" + CardInInID + "转账");
				}

			}

			return isok;
		}


		/// <summary>
		/// 存取款
		/// <param name = "CardID" ></ param >
		/// < param name="MoneyNum">负数为取款</param>
		/// <returns></returns>
		/// </summary>
		public bool UpdateBalance(string CardID, decimal MoneyNum, string remark)
		{
			return dal.UpdateBalance(CardID, MoneyNum, remark);
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string cardID, string pwd)
		{
			return dal.Exists(cardID, pwd);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.cardinfo model, out string CardID)
		{
			return dal.Add(model, out CardID);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.cardinfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string cardID)
		{

			return dal.Delete(cardID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cardIDlist)
		{
			return dal.DeleteList(cardIDlist);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.cardinfo GetModel(string cardID)
		{

			return dal.GetModel(cardID);
		}



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.cardinfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.cardinfo> DataTableToList(DataTable dt)
		{
			List<Model.cardinfo> modelList = new List<Model.cardinfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.cardinfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
		//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}