using System;
namespace Model
{
	/// <summary>
	/// userInfo:实体类(用户信息)
	/// </summary>
	[Serializable]
	public class userInfo
	{
		public userInfo()
		{ }
		#region Model
		private int _customerid;
		private string _customername;
		private string _pid;
		private string _telephone;
		private string _address;
		/// <summary>
		/// 客户编号
		/// </summary>
		public int customerID
		{
			set { _customerid = value; }
			get { return _customerid; }
		}
		/// <summary>
		/// 客户姓名
		/// </summary>
		public string customerName
		{
			set { _customername = value; }
			get { return _customername; }
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string pID
		{
			set { _pid = value; }
			get { return _pid; }
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string telephone
		{
			set { _telephone = value; }
			get { return _telephone; }
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set { _address = value; }
			get { return _address; }
		}
		#endregion Model

	}
}