﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

using Core.UI;

using static Core.Layers.DEF_System;
using static Core.Layers.DEF_Common;
using static Core.Layers.DEF_Error;
using static Core.Layers.DEF_Error;

using static Core.Layers.DEF_Thread;
using static Core.Layers.DEF_DataManager;
using static Core.Layers.DEF_System.EObjectLayer;
using static Core.Layers.DEF_SocketClient;

using static Core.Layers.DEF_MeStage;
using static Core.Layers.DEF_SerialPort;

using static Core.Layers.DEF_MTrsInterface;


namespace Core.Layers
{
    public class MSysCore : MObject, IDisposable
    {
        // static common data
        public static bool bUseOnline { get; private set; }
        public static bool bInSfaTest { get; private set; }
        public static ELanguage Language { get; private set; } = ELanguage.KOREAN;

        ///////////////////////////////////////////////////////////////////////
        // Common Class
        public MSystemInfo m_SystemInfo { get; private set; }
        public MDataManager m_DataManager { get; private set; }

        ///////////////////////////////////////////////////////////////////////
        // Hardware Layer

        public MGigE m_GigE;


        ///////////////////////////////////////////////////////////////////////
        // Function Layer

        public MFuncInspection m_FuncInspection;

        // Stage
        public MFuncAlignment    m_MeStage;     


        ///////////////////////////////////////////////////////////////////////
        // Process Layer
        public MTrsInterface m_trsAutoManager { get; private set; }        
        public MTrsStage1 m_trsStage1 { get; private set; }

        public FormIntro intro;

        public MSysCore(CObjectInfo objInfo)
            : base(objInfo)
        {
        }

        ~MSysCore()
        {
            Dispose();
        }

        public void Dispose()
        {
            // close handle
            
        }

        public void CloseSystem()
        {
            StopThreads();

        }
        
        public void GetParameterInfo(string group, string name, out CParaInfo pinfo)
        {
            m_DataManager.LoadParaInfo(group, name, out pinfo);
        }

        public CAlarm GetAlarmInfo(int alarmcode, int pid = 0, bool saveLog = true)
        {
            CAlarm alarm = new CAlarm();
            // Process ID가 400부터 시작하기 때문에
            alarm.ProcessID = (pid == 0) ? 400 : pid + 400 - 1; 
            if(pid < 400)
            {
                if (pid == 0) alarm.ProcessID = 400;
                else alarm.ProcessID = pid + 400 - 1;
            } else
            {
                alarm.ProcessID = pid;
            }
            alarm.ObjectID = (int)((alarmcode & 0xffff0000) >> 16);
            alarm.ErrorBase = (int)((alarmcode & 0x0000ffff) / 100) * 100;
            alarm.ErrorCode = (int)((alarmcode & 0x0000ffff) % 100);

            alarm.ProcessName = m_SystemInfo.GetObjectName(alarm.ProcessID);
            alarm.ProcessType = m_SystemInfo.GetTypeName(alarm.ProcessID);
            alarm.ObjectName = m_SystemInfo.GetObjectName(alarm.ObjectID);
            alarm.ObjectType = m_SystemInfo.GetTypeName(alarm.ObjectID);
            m_DataManager.LoadAlarmInfo(alarm.GetIndex(), out alarm.Info);

            if(saveLog == true)
            {
                m_DataManager.SaveAlarmHistory(alarm);
            }
            return alarm;
        }

        public string GetAlarmText(int alarmcode, ELanguage language = ELanguage.ENGLISH)
        {
            CAlarm alarm = GetAlarmInfo(alarmcode, 0, false);
            return alarm.Info.Description[(int)language];
        }

        public string GetAlarmSolution(int alarmcode, ELanguage language = ELanguage.ENGLISH)
        {
            CAlarm alarm = GetAlarmInfo(alarmcode, 0, false);
            return alarm.Info.Solution[(int)language];
        }

        public void ShowAlarmWhileInit(int alarmcode)
        {
            string str = GetAlarmText(alarmcode);
            CMainFrame.DisplayMsg(str);
        }

        /// <summary>
        /// UI 와의 연결을 위해서 form 과 MDataManager를 먼저 define
        /// </summary>
        /// <param name="form1"></param>
        /// <param name="dataManager"></param>
        /// <returns></returns>
        public int Initialize(CMainFrame form1, out MDataManager dataManager)
        {
            int iResult = SUCCESS;

            intro = new FormIntro();

            intro.Show();
            intro.SetStatus("Init Common Class", 10);

            ////////////////////////////////////////////////////////////////////////
            // 0. Common Class
            ////////////////////////////////////////////////////////////////////////
            // init data file name
            CDBInfo dbInfo;
            InitDataFileNames(out dbInfo);
            CObjectInfo.DBInfo = dbInfo;
            MLog.DBInfo = dbInfo;
            CMainFrame.DBInfo = dbInfo;

            CObjectInfo objInfo;
            m_SystemInfo = new MSystemInfo();

            // self set MSysCore
            m_SystemInfo.GetObjectInfo((int)OBJ_SYSTEM, out objInfo);
            this.ObjInfo = objInfo;

            // DataManager
            m_SystemInfo.GetObjectInfo((int)OBJ_DATAMANAGER, out objInfo);
            m_DataManager = new MDataManager(objInfo, dbInfo);
            dataManager = m_DataManager;
            iResult = m_DataManager.Initialize();
            CMainFrame.DisplayAlarmOnly(iResult);

            Sleep(200);
            
            intro.SetStatus("Init Hardware Layer", 20);

            ////////////////////////////////////////////////////////////////////////
            // 1. Hardware Layer
            ////////////////////////////////////////////////////////////////////////

            int iCam0Status = 0;
            int iCam1Status = 0;
            int iCam2Status = 0;
            int iCam3Status = 0;

            m_GigE = new MGigE(1);
            m_GigE.ConnectGige(1, out iCam0Status, out iCam1Status, out iCam2Status, out iCam3Status);

            Sleep(200);

            intro.SetStatus("Init Camera ", 30);

            ////////////////////////////////////////////////////////////////////////
            // Vision

            Sleep(200);

            ////////////////////////////////////////////////////////////////////////
            // 2. Function Layer
            ////////////////////////////////////////////////////////////////////////
            ///
            intro.SetStatus("Init Function Layer", 40);

            // Stage1
            m_SystemInfo.GetObjectInfo(303, out objInfo);
            CreateMeStage(objInfo);

            m_FuncInspection = new MFuncInspection();
            m_FuncInspection.InitialControl("SDI");

            Sleep(200);


            ////////////////////////////////////////////////////////////////////////
            // 3. Process Layer
            ////////////////////////////////////////////////////////////////////////
            intro.SetStatus("Init Process Layer", 50);

            m_SystemInfo.GetObjectInfo(400, out objInfo);
            CreateTrsAutoManager(objInfo);

            m_SystemInfo.GetObjectInfo(403, out objInfo);
            CreateTrsStage1(objInfo);

            // temporary set windows
            // m_trsStage1.SetWindows_Form1(form1);
             m_trsAutoManager.SetWindows_Form1(form1);


            Sleep(200);

            ////////////////////////////////////////////////////////////////////////
            // 4. Set Data
            ////////////////////////////////////////////////////////////////////////
            intro.SetStatus("Loading System Data", 70);
            iResult = SetSystemDataToComponent(false);
            CMainFrame.DisplayAlarmOnly(iResult);

            Sleep(200);

            intro.SetStatus("Loading Model Data", 80);
            iResult = SetModelDataToComponent();
            CMainFrame.DisplayAlarmOnly(iResult);


            Sleep(200);

            ////////////////////////////////////////////////////////////////////////
            // 6. Start Thread & System
            ////////////////////////////////////////////////////////////////////////

            intro.SetStatus("Process Start", 100);

            SetThreadChannel();
            StartThreads();
            
            intro.Hide();

            iResult = m_DataManager.Logout(); // logoff maker
            CMainFrame.DisplayAlarmOnly(iResult);

            return SUCCESS;
        }

        void InitDataFileNames(out CDBInfo dbInfo)
        {
            dbInfo = new CDBInfo();
        }


        
        void CreateTrsAutoManager(CObjectInfo objInfo)
        {
            CTrsInterfaceRefComp refComp = new CTrsInterfaceRefComp();     

            CTrsAutoManagerData data = new CTrsAutoManagerData();

            m_trsAutoManager = new MTrsInterface(objInfo, EThreadChannel.TrsAutoManager, m_DataManager, refComp, data);
        }

        void CreateTrsStage1(CObjectInfo objInfo)
        {
            CTrsStage1RefComp refComp = new CTrsStage1RefComp();

            CTrsStage1Data data = new CTrsStage1Data();

            m_trsStage1 = new MTrsStage1(objInfo, EThreadChannel.TrsStage1, m_DataManager, refComp, data);
        }

        void SetThreadChannel()
        {
            // AutoManager
            m_trsAutoManager.LinkThread(EThreadChannel.TrsSelfChannel, m_trsAutoManager);
            m_trsAutoManager.LinkThread(EThreadChannel.TrsAutoManager, m_trsAutoManager);
            m_trsAutoManager.LinkThread(EThreadChannel.TrsStage1, m_trsStage1);            

            // Stage1
            m_trsStage1.LinkThread(EThreadChannel.TrsSelfChannel, m_trsStage1);
            m_trsStage1.LinkThread(EThreadChannel.TrsAutoManager, m_trsAutoManager);
        }

        void StartThreads()
        {
            m_trsStage1.ThreadStart();
            m_trsAutoManager.ThreadStart();
        }

        public void StopThreads()
        {
            m_trsStage1.ThreadStop();
            m_trsAutoManager.ThreadStop();
        }

        public int SaveSystemData(CSystemData system = null)
        {
            int iResult = SUCCESS;

            // save
            iResult = m_DataManager.SaveSystemData(system);
            if (iResult != SUCCESS) return iResult;

            // set
            iResult = SetSystemDataToComponent();
            if (iResult != SUCCESS) return iResult;

            return SUCCESS;
        }

        private int SetSystemDataToComponent(bool bLoadFromDB = true)
        {
            int iResult = SUCCESS;
            if (bLoadFromDB)
            {
                iResult = m_DataManager.LoadSystemData();
                if (iResult != SUCCESS) return iResult;
                iResult = m_DataManager.LoadModelList();
                if (iResult != SUCCESS) return iResult;
            }

            CSystemData systemData = m_DataManager.SystemData;

            MSysCore.Language   = systemData.Language;

            // set system data to each component

            //////////////////////////////////////////////////////////////////
            // Hardware Layer

            //////////////////////////////////////////////////////////////////
            // Function Layer
            

            //////////////////////////////////////////////////////////////////
            // Process Layer
                        


            return SUCCESS;   
        }

        public int SaveModelData(CModelData modelData)
        {
            // save
            int iResult = m_DataManager.SaveModelData(modelData);
            if (iResult != SUCCESS) return iResult;

            // set
            iResult = SetModelDataToComponent();
            if (iResult != SUCCESS) return iResult;

            return SUCCESS;
        }
        

        public int SaveUserData(CUserInfo data)
        {
            // save
            int iResult = m_DataManager.SaveUserData(data);
            if (iResult != SUCCESS) return iResult;

            // set
            //iResult = SetModelDataToComponent();
            //if (iResult != SUCCESS) return iResult;

            return SUCCESS;
        }

        public int SetModelDataToComponent()
        {
            int iResult = SUCCESS;
            //m_DataManager.ChangeModel(m_DataManager.SystemData.ModelName);

            CModelData modelData = m_DataManager.ModelData;

            // set model data to each component


            //////////////////////////////////////////////////////////////////
            // Hardware Layer

            //////////////////////////////////////////////////////////////////
            // Function Layer            

            // Stage 1
            {
                CMeStageData data;
                m_MeStage.GetData(out data);


                m_MeStage.SetData(data);
            }

            //////////////////////////////////////////////////////////////////
            // Process Layer
            
            // Stage1
            {
                CTrsStage1Data data;
                m_trsStage1.GetData(out data);

                m_trsStage1.SetData(data);
            }

            return SUCCESS;
        }



        private int SetPositionDataToComponent(EPositionObject unit = EPositionObject.ALL)
        {
            int iResult = SUCCESS;

            // set position data to each component
            int index;
            //////////////////////////////////////////////////////////////////
            // Hardware Layer

            //////////////////////////////////////////////////////////////////
            // Function Layer
     

            //////////////////////////////////////////////////////////////////
            // Process Layer

            return SUCCESS;
        }
        
        

        void CreateMeStage(CObjectInfo objInfo)
        {
            CMeStageRefComp refComp = new CMeStageRefComp();
            CMeStageData data = new CMeStageData();

                        
            m_MeStage = new MFuncAlignment(objInfo, refComp, data);
        }
        

        public void SetAutoManual(EAutoManual mode)
        {
            // mechanical layer
            m_MeStage.SetAutoManual(mode);

            // process layer
            m_trsAutoManager.SetAutoManual(mode);
            m_trsStage1.SetAutoManual(mode);
        }

        public int EmptyMethod()
        {
            return SUCCESS;
        }
    }
}
