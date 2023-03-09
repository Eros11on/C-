using System;
namespace Model
{
	/// <summary>
	/// transInfo:实体类(交易信息)
	/// </summary>
	[Serializable]
	public class transInfo
	{
		public transInfo()
		{ }
		#region Model
		private DateTime _transdate = DateTime.Now;
		private string _cardid;
		private string _transtype;
		private decimal _transmoney;
		private string _remark;
		/// <summary>
		/// 交易日期
		/// </summary>
		public DateTime transDate
		{
			set { _transdate = value; }
			get { return _transdate; }
		}
		/// <summary>
		/// 银行卡号
		/// </summary>
		public string cardID
		{
			set { _cardid = value; }
			get { return _cardid; }
		}
		/// <summary>
		/// 交易类型 存入/支取
		/// </summary>
		public string transType
		{
			set { _transtype = value; }
			get { return _transtype; }
		}
		/// <summary>
		/// 交易金额
		/// </summary>
		public decimal transMoney
		{
			set { _transmoney = value; }
			get { return _transmoney; }
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set { _remark = value; }
			get { return _remark; }
		}
		#endregion Model

	}
}