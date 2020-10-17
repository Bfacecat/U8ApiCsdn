using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace U8ApiCsdn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取u8登录对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sSubId = "ST";
                string sAccId = "002";
                string sYear = "2020";
                string sUserId = "demo";
                string sPassword = "123456";
                string sServer = "127.0.0.1";
                string sSerial = "";
                string sDate = DateTime.Now.ToString("yyyy-MM-dd");
                U8Login.clsLogin u8login = GetU8Login(sSubId, sAccId, sYear, sUserId, sPassword, sDate, sServer, sSerial);
                string DbName = u8login.UfDbName;
                string UserName = u8login.cUserName;
                u8login.ShutDown();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 构建登录对象
        /// </summary>
        /// <param name="sSubId">U8子模块</param>
        /// <param name="sAccId">账套ID</param>
        /// <param name="sYear">年份</param>
        /// <param name="sUserId">用户账号</param>
        /// <param name="sPassword">用户密码</param>
        /// <param name="sDate">登陆日期</param>
        /// <param name="sServer">登陆服务器地址</param>
        /// <param name="sSerial">默认空</param>
        /// <returns></returns>
        public static U8Login.clsLogin GetU8Login(String sSubId, String sAccId, String sYear, String sUserId, String sPassword, String sDate, String sServer, String sSerial)
        {
            U8Login.clsLogin U8Login = new U8Login.clsLogin();
            bool bSucess = false;
            try
            {
                bSucess = U8Login.Login(ref sSubId, ref sAccId, ref sYear, ref sUserId, ref sPassword, ref sDate, ref sServer, ref sSerial);
                if (bSucess == false)
                {
                    String errMsg = "登陆失败,原因:" + U8Login.ShareString;
                    throw new Exception(errMsg);
                }
                else
                {
                    return U8Login;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnVerifyOtherin_Click(object sender, EventArgs e)
        {
            ADODB.Connection con = null;
            try
            {

                string sSubId = "ST";
                string sAccId = "002";
                string sYear = "2020";
                string sUserId = "demo";
                string sPassword = "123456";
                string sServer = "127.0.0.1";
                string sSerial = "";
                string Msg = "";
                string VouchId = "1000000030";
                string sDate = DateTime.Now.ToString("yyyy-MM-dd");
                U8Login.clsLogin u8login = GetU8Login(sSubId, sAccId, sYear, sUserId, sPassword, sDate, sServer, sSerial);
                con = new ADODB.Connection();
                con.ConnectionString = u8login.UfDbName;
                con.Open();
                con.BeginTrans();
                //初始化co接口
                var VCO = new USERPCO.VoucherCO();
                VCO.IniLogin(u8login, ref Msg);
                if (!string.IsNullOrEmpty(Msg))
                {
                    throw new Exception(Msg);
                }
                object TimeStamp = null;
                MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocumentClass();
                bool bCheck = true, bBeforCheckStock = true, bList = false;
                bool bsuccess = VCO.Verify("08", VouchId, ref Msg, ref con, ref TimeStamp, ref domMsg, ref bCheck, ref bBeforCheckStock, ref bList);
                string errxml = domMsg.xml;
                if (!string.IsNullOrEmpty(Msg))
                {
                    throw new Exception(Msg);
                }
                con.CommitTrans();
            }
            catch (Exception ex)
            {
                con.RollbackTrans();
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
            }
        }

    }
}
