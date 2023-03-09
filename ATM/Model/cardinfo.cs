using System;
namespace Model
{
	/// <summary>
	/// cardinfo:实体类(银行卡信息)
	/// </summary>
	[Serializable]
	public class cardinfo
	{
		public cardinfo()
		{ }
		#region Model
		private string _cardid;
		private string _curtype = "RMB";
		private string _savingtype;
		private DateTime _opendate = DateTime.Now;
		private decimal _openmoney = 0M;
		private decimal _balance = 0M;
		private string _pass = "888888";
		private bool _isreportloss = false;
		private int _customerid;
		/// <summary>
		/// 银行卡号
		/// </summary>
		public string cardID
		{
			set { _cardid = value; }
			get { return _cardid; }
		}
		/// <summary>
		/// 货币类型
		/// </summary>
		public string curType
		{
			set { _curtype = value; }
			get { return _curtype; }
		}
		/// <summary>
		/// 存款类型 活期/定活两便/定期
		/// </summary>
		public string savingType
		{
			set { _savingtype = value; }
			get { return _savingtype; }
		}
		/// <summary>
		/// 开户日期
		/// </summary>
		public DateTime openDate
		{
			set { _opendate = value; }
			get { return _opendate; }
		}
		/// <summary>
		/// 开户金额
		/// </summary>
		public decimal openMoney
		{
			set { _openmoney = value; }
			get { return _openmoney; }
		}
		/// <summary>
		/// 账户余额
		/// </summary>
		public decimal balance
		{
			set { _balance = value; }
			get { return _balance; }
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string pass
		{
			set { _pass = value; }
			get { return _pass; }
		}
		/// <summary>
		/// 是否已挂失
		/// </summary>
		public bool IsReportLoss
		{
			set { _isreportloss = value; }
			get { return _isreportloss; }
		}
		/// <summary>
		/// 客户编号
		/// </summary>
		public int customerID
		{
			set { _customerid = value; }
			get { return _customerid; }
		}
		#endregion Model

	}
}