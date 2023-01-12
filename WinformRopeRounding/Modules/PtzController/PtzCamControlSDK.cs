using System.Runtime.InteropServices;

namespace WinformRopeRounding.Modules.PtzController
{
    public class PtzCamControlSDK : IPtzCamControl
    {
        private uint last_action_cmd = 0;
        private bool initialised = false;
        private uint iLastErr = 0;
        private int m_lUserID = -1;
        private bool m_bInitSDK = false;
        private int m_lRealHandle = -1;
        private string strErr;

        private CHCNetSDK.REALDATACALLBACK RealData = null;
        public CHCNetSDK.NET_DVR_PTZPOS m_struPtzCfg;
        public CHCNetSDK.NET_DVR_FOCUSMODE_CFG m_struFocusModeCfg;
        public CHCNetSDK.NET_DVR_DEVICECFG_V40 m_struDeviceCfg;
        public CHCNetSDK.NET_DVR_NETCFG_V30 m_struNetCfg;
        public CHCNetSDK.NET_DVR_TIME m_struTimeCfg;
        public CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo;
        public CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;

        public string ErrorMessage { get; private set; }
        public bool Initialised { get { return initialised; } }

        public enum ActButtons { None, Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft, Zoom, ZoomOut, ZoomIn, Home, FocusNear, FocusFar };
        public void ActionCommand(int dir)
        {
            var enumDir = (ActButtons)dir;
            uint dwStop = 0;
            uint dwSpeed = 4;
            switch (enumDir)
            {
                case ActButtons.None:
                    dwStop = 1;
                    break;
                case ActButtons.Up:                    
                    last_action_cmd = CHCNetSDK.TILT_UP;               
                    break;
                case ActButtons.UpRight:
                    last_action_cmd = CHCNetSDK.UP_RIGHT;
                    break;
                case ActButtons.Right:
                    last_action_cmd = CHCNetSDK.PAN_RIGHT;
                    break;
                case ActButtons.DownRight:
                    last_action_cmd = CHCNetSDK.DOWN_RIGHT;
                    break;
                case ActButtons.Down:
                    last_action_cmd = CHCNetSDK.TILT_DOWN;
                    break;
                case ActButtons.DownLeft:
                    last_action_cmd = CHCNetSDK.DOWN_LEFT;
                    break;
                case ActButtons.Left:
                    last_action_cmd = CHCNetSDK.PAN_LEFT;
                    break;
                case ActButtons.UpLeft:
                    last_action_cmd = CHCNetSDK.UP_LEFT;
                    break;
                case ActButtons.Zoom:
                    break;
                case ActButtons.ZoomIn:
                    last_action_cmd = CHCNetSDK.ZOOM_IN;
                    dwSpeed = 2;
                    break;
                case ActButtons.ZoomOut:
                    last_action_cmd = CHCNetSDK.ZOOM_OUT;
                    dwSpeed = 2;
                    break;
                case ActButtons.Home:
                    last_action_cmd = CHCNetSDK.GOTO_PRESET;
                    break;
                case ActButtons.FocusNear:
                    last_action_cmd = CHCNetSDK.FOCUS_NEAR;
                    dwSpeed = 2;
                    break;
                case ActButtons.FocusFar:
                    last_action_cmd = CHCNetSDK.FOCUS_FAR;
                    dwSpeed = 2;
                    break;
                default:
                    break;
            }
            CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, 1, last_action_cmd, dwStop, dwSpeed);
        }

        public void SetFocusAsync(string FocusPos)
        {
            Int32 size = Marshal.SizeOf(m_struFocusModeCfg);//获取结构体大小
            IntPtr ptrCfg = Marshal.AllocHGlobal(size);//设置指针空间大小
            m_struFocusModeCfg.dwFocusPos = Convert.ToUInt16(FocusPos);
            Marshal.StructureToPtr(m_struFocusModeCfg, ptrCfg, false);//结构体转换为指针
            if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_FOCUSMODECFG, 1, ptrCfg, (uint)size))//设置聚焦模式
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                var strErr = "NET_DVR_SetDVRConfig failed, error code= " + iLastErr;
                throw new Exception(strErr);
            }
            Marshal.FreeHGlobal(ptrCfg);//释放指针
        }

        public Task SetPositionAsync(string text)
        {
            int iCount = 6;
            var FocusPos = text.Split()[3];
            var iFocusPos = Convert.ToInt32(FocusPos);
            while(--iCount>0)
            {
                var feedBack = GetFocus();
                var iFeeBack = Convert.ToInt32(feedBack);
                if (Math.Abs(iFocusPos - iFeeBack) > 10)
                {
                    SetFocusAsync(FocusPos);
                    Task.Delay(2000).Wait();
                }
                else
                    break;
            }

            string str1, str2, str3;
            var PanPos = text.Split()[0];
            var TiltPos = text.Split()[1];
            var ZoomPos = text.Split()[2];
            str1 = Convert.ToString(float.Parse(PanPos) * 10);
            m_struPtzCfg.wPanPos = Convert.ToUInt16(str1, 16);
            str2 = Convert.ToString(float.Parse(TiltPos) * 10);
            m_struPtzCfg.wTiltPos = Convert.ToUInt16(str2, 16);
            str3 = Convert.ToString(float.Parse(ZoomPos) * 10);
            m_struPtzCfg.wZoomPos = Convert.ToUInt16(str3, 16); ;

            int nSize = Marshal.SizeOf(m_struPtzCfg);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);

            if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_PTZPOS, 1, ptrPtzCfg, (uint)nSize))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                var strErr = "NET_DVR_SetDVRConfig failed, error code= " + iLastErr;
                throw new Exception(strErr);
            }
            Marshal.FreeHGlobal(ptrPtzCfg);

            System.Diagnostics.Debug.WriteLine($"SetPos: {m_struPtzCfg.wPanPos} {m_struPtzCfg.wTiltPos} {m_struPtzCfg.wZoomPos} {m_struFocusModeCfg.dwFocusPos}");
            return Task.CompletedTask;
        }


        public string GetPosition()
        {
            uint dwReturn = 0;
            int nSize = Marshal.SizeOf(m_struPtzCfg);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);
            string ret;
            //获取参数失败
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_PTZPOS, -1, ptrPtzCfg, (uint)nSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                var strErr = "NET_DVR_GetDVRConfig failed, error code= " + iLastErr;
                throw new Exception(strErr);
            }
            else
            {
                m_struPtzCfg = (CHCNetSDK.NET_DVR_PTZPOS)Marshal.PtrToStructure(ptrPtzCfg, typeof(CHCNetSDK.NET_DVR_PTZPOS));
                Marshal.FreeHGlobal(ptrPtzCfg);//释放指针

                //成功获取显示ptz参数
                ushort wPanPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wPanPos, 16));
                float WPanPos = wPanPos * 0.1f;
                var PanPos = Convert.ToInt16(WPanPos).ToString();
                ushort wTiltPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wTiltPos, 16));
                float WTiltPos = wTiltPos * 0.1f;
                var TiltPos = Convert.ToInt16(WTiltPos).ToString();
                ushort wZoomPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wZoomPos, 16));
                float WZoomPos = wZoomPos * 0.1f;
                var ZoomPos = Convert.ToString(WZoomPos);
                var FocusPos = GetFocus();

                ret = $"{PanPos} {TiltPos} {ZoomPos} {FocusPos}";

                System.Diagnostics.Debug.WriteLine($"GetPos: {m_struPtzCfg.wPanPos} {m_struPtzCfg.wTiltPos} {m_struPtzCfg.wZoomPos} {m_struFocusModeCfg.dwFocusPos}");                
            }
            return ret;
        }

        public string GetFocus()
        {
            uint dwReturn = 0;
            m_struFocusModeCfg = new CHCNetSDK.NET_DVR_FOCUSMODE_CFG();//实例化聚焦模式结构体
            int size = Marshal.SizeOf(m_struFocusModeCfg);//获取结构体大小
            IntPtr ptrCfg = Marshal.AllocHGlobal(size);//设置指针空间大小
            CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_FOCUSMODECFG, 1, ptrCfg, (uint)size, ref dwReturn);//获取聚焦模式信息的指针
            m_struFocusModeCfg = (CHCNetSDK.NET_DVR_FOCUSMODE_CFG)Marshal.PtrToStructure(ptrCfg, typeof(CHCNetSDK.NET_DVR_FOCUSMODE_CFG));//指针转换为聚焦模式结构体
            Marshal.FreeHGlobal(ptrCfg);//释放指针
            var FocusPos = m_struFocusModeCfg.dwFocusPos.ToString();
            return FocusPos;
        }

        public void HomePosition()
        {
            throw new NotImplementedException();
        }

        public PtzCamControlSDK()
        {
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                var strErr = "NET_DVR_Init error!";
                throw new Exception(strErr);
            }
            else
            {
                // save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
        }

        public Task<bool> InitialiseAsync(string cameraAddress, string userName, string password)
        {
            bool result = false;
            if (m_lUserID < 0)
            {
                string DVRIPAddress = cameraAddress;
                short DVRPortNumber = 8000;
                string DVRUserName = userName; 
                string DVRPassword = password; 

                //Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref m_struDeviceInfo);
                if (m_lUserID == -1)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    strErr = "NET_DVR_Login_V30 failed, error code= " + iLastErr;
                    //Failed to login and output the error code
                    throw new Exception(strErr);
                }
                else
                {
                    m_lRealHandle = m_lUserID;
                    var GetPTZPosition = GetPosition();
                    result = true;
                }
            }            
            return Task.FromResult(result);
        }

        public void PanLeft(bool MouseDown)
        {
            throw new NotImplementedException();
        }
        public void PanUPLeft(bool MouseDown)
        {
            throw new NotImplementedException();
        }
        public void PanDnLeft(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        public void PanRight(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        
        public void Stop()
        {
            ActionCommand(0);
        }

        public void TiltDown(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        public void TiltUp(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        public void ZoomIn(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        public void ZoomOut(bool MouseDown)
        {
            throw new NotImplementedException();
        }

        public void PanLeft()
        {
            throw new NotImplementedException();
        }

        public void PanRight()
        {
            throw new NotImplementedException();
        }

        public void TiltDown()
        {
            throw new NotImplementedException();
        }

        public void TiltUp()
        {
            throw new NotImplementedException();
        }

        public void ZoomIn()
        {
            throw new NotImplementedException();
        }

        public void ZoomOut()
        {
            throw new NotImplementedException();
        }
    }
}
