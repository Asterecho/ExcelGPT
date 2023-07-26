using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
//using FastLogAsync;

namespace ExcelGPT
{
    //https://msdn.microsoft.com/en-us/library/Microsoft.Office.Tools.CustomTaskPane(v=vs.80).aspx  CustomTaskPane Class
    //https://msdn.microsoft.com/zh-cn/library/microsoft.office.tools.customtaskpane(v=vs.100).aspx CustomTaskPane 接口 office2010
    //https://msdn.microsoft.com/zh-cn/library/microsoft.office.tools.customtaskpanecollection(v=VS.100).aspx CustomTaskPaneCollection 接口
    //https://msdn.microsoft.com/zh-cn/library/bb608620.aspx Managing Custom Task Panes in Multiple Application Windows

    //https://msdn.microsoft.com/en-us/library/aa942846.aspx How to: Add a Custom Task Pane to an Application


    //https://msdn.microsoft.com/en-us/library/aa942864.aspx Custom Task Panes
    /*
    Controlling the Task Pane in Multiple Windows 
    
    Custom task panes are associated with a document frame window, which presents a view of a document or item to the user.
    The task pane is visible only when the associated window is visible.
    
    To determine which window displays the custom task pane, 
    use the appropriate Add method overload when you create the task pane:
    1、To associate the task pane with the active window, use the CustomTaskPaneCollection.Add(UserControl, String) method.
    2、To associate the task pane with a document that is hosted by a specified window, use the CustomTaskPaneCollection.Add(UserControl, String, Object) method.
    
    Some Office applications require explicit instructions for when to create or display your task pane when more than one window is open. 
    This makes it important to consider where to instantiate the custom task pane in your code to ensure that the task pane appears with the appropriate documents or items in the application. 
    For more information, see Managing Custom Task Panes in Application Windows.
     */

    //http://www.cnblogs.com/yangecnu/archive/2013/10/18/3375338.html Excel 自定义任务窗体
    //http://blogs.msdn.com/b/vsto/archive/2010/02/02/add-a-custom-task-pane-to-project-2010-norm-estabrook.aspx Add a Custom Task Pane to Project 2010 (Norm Estabrook)

    //考虑到 Excel2013改成了single document interface (SDI)，因此需要在application事件中处理任务窗格，以保证在当前窗体中能够显示。
    //https://msdn.microsoft.com/en-us/library/office/dn251093(v=office.15).aspx#odc_xl15_ta_ProgrammingtheSDIinExcel2013_TaskPanes
    //https://docs.microsoft.com/en-us/office/vba/excel/concepts/programming-for-the-single-document-interface-in-excel

    
    /// <summary>
    /// 任务窗格管理类
    /// </summary>
    public class CTPManager
    {
    	internal const string CTPGUID = "05278343-0FD5-4359-833B-33723C17A96A";
    	internal const string CTPProgID = "DNAForETDemo.CTPHost";
    	internal const string FirstTaskpaneName = "Jupyter";
    
        private static readonly CTPManager _instance = new CTPManager();
        private static Dictionary<string, CustomTaskPane> DicCustomCTP = new Dictionary<string, CustomTaskPane>();
        static CTPManager() { }
        private CTPManager() { }
        
        public static CTPManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void ShowCTP(int hwnd)
        {
            //Office 2013 is SDI(single document interface) https://www.add-in-express.com/creating-addins-blog/2013/02/28/excel2013-single-document-interface-task-panes/
            
            string hwndstring = hwnd.ToString();
            
            if (DicCustomCTP.ContainsKey(hwndstring))
            {
               // Log.Info($"重新显示 CTP，hwnd={hwndstring}");
                CustomTaskPane ctp = DicCustomCTP[hwndstring];
                ctp.Visible = true;
            }
            else
            {
               // Log.Info($"注册 CTP Com Addin");
                //首次执行有效。执行一次即可，多次执行无效。同时要在WPS白名单里面加入CTPProgID
                Guid clsId = new Guid(CTPGUID);
                string progID = CTPProgID;
                CustomTaskPaneFactory.InitCTPFactory(clsId, progID);

                //以下创建窗格
                //Log.Info($"创建 Custom Task Pane");
                CustomTaskPane ctp = CustomTaskPaneFactory.CreateCustomTaskPane(typeof(CTPControls), FirstTaskpaneName);                
                ctp.DockPosition = MsoCTPDockPosition.msoCTPDockPositionRight;                         
                ctp.VisibleStateChange += ctp_VisibleStateChange;                
                ctp.DockPositionRestrict = MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoHorizontal;                
                ctp.Visible = true;                
                ctp.Width = 260;   //显示后有效

                DicCustomCTP.Add(hwndstring, ctp);
            }
        }       
        
        public void DeleteCTP(int hwnd)
        {
            string hwndstring = hwnd.ToString();
            if (DicCustomCTP.ContainsKey(hwndstring))
            {
                CustomTaskPane ctp = DicCustomCTP[hwndstring];                
                ctp.VisibleStateChange -= ctp_VisibleStateChange;
                ctp.Delete();                   // Could hide instead, by calling ctp.Visible = false;

                DicCustomCTP.Remove(hwndstring);                
            }
        }

        void ctp_VisibleStateChange(CustomTaskPane CustomTaskPaneInst)
        {
            //MessageBox.Show("CTP visible: " + CustomTaskPaneInst.Visible);
        }
    }
}
