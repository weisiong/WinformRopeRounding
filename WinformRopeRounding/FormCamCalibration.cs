using SimpleRTSPPlayerWinforms;
using System.Diagnostics;
using WinformRopeRounding.Classes;
using WinformRopeRounding.UserControls;

namespace WinformRopeRounding
{
    public partial class FormCamCalibration : Form
    {       
        private ucCamPtzPanel _ctrpanel;
        private PtzCamControl _controller;
        public string CameraIP { get; set; }
        public string CamUsername { get; set; }
        public string CamPassword { get; set; }
        public string RtspPath { get; set; }
        public Image SnapshootImage { get; internal set; }

        private VideoControl videoControl;
        public FormCamCalibration(string Title, string value)
        {
            InitializeComponent();
            this.Text = Title;
            this.txtValue.Text = value;
        }

        private async void FormCamCalibration_Load(object sender, EventArgs e)
        {
            videoControl = new VideoControl();
            if (!splitContainer1.Panel1.Controls.Contains(videoControl))
            {
                splitContainer1.Panel1.Controls.Add(videoControl);
                videoControl.Dock = DockStyle.Fill;
                videoControl.HandleStreamStartedEvent += VideoControl_HandleStreamStartedEvent;
                videoControl.HandleStreamStoppedEvent += VideoControl_HandleStreamStoppedEvent;
            }

            _ctrpanel = ucCamPtzPanel1;
            _ctrpanel.OnActionButtonDown += Ctrpanel_OnButtonMouseDown;
            _ctrpanel.OnActionButtonUp += Ctrpanel_OnButtonMouseUp;
            _ctrpanel.OnActionButtonClick += _ctrpanel_OnActionButtonClick;
            _controller = new PtzCamControl();
            var success = await _controller.InitialiseAsync(CameraIP, CamUsername, CamPassword);
            if (success)
            {
                //_controller.SetPosition(txtValue.Text);
                PlayStream();
            }
        }

        private void VideoControl_HandleStreamStoppedEvent(object sender, EventArgs e)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Steam Stop";
        }

        private void VideoControl_HandleStreamStartedEvent(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        private void _ctrpanel_OnActionButtonClick(object sender, int e)
        {
            _controller.ActionCommand(e);
        }

        bool IsMouseDown = false;
        private async void Ctrpanel_OnButtonMouseDown(object sender, int e)
        {
            IsMouseDown = true;
            while (IsMouseDown)
            {
                _controller.ActionCommand(e);
                await Task.Delay(100);
            }
        }

        private void Ctrpanel_OnButtonMouseUp(object sender, int e)
        {
            IsMouseDown = false;
            _controller.Stop();
        }

        private void PlayStream()
        {
            var RtspPath = $"rtsp://{CamUsername}:{CamPassword}@{CameraIP}";
            if (!videoControl.IsPlaying)
                videoControl.StartPlay(RtspPath);
        }

        private void StopStream()
        {
            if (videoControl.IsPlaying)
                videoControl.Stop();
        }

        public string InputValue
        {
            get
            {
               return txtValue.Text;
            }
        }

        private async Task btnGetPosition_ClickAsync(object sender, EventArgs e)
        {
                txtValue.Text =await _controller.GetPosition();
        }

        private void FrmLocInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ctrpanel.OnActionButtonDown -= Ctrpanel_OnButtonMouseDown;
            _ctrpanel.OnActionButtonUp -= Ctrpanel_OnButtonMouseUp;
            _ctrpanel.OnActionButtonClick -= _ctrpanel_OnActionButtonClick;
            StopStream();
            videoControl.Dispose();
            videoControl = null;
            _controller = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SnapshootImage = Snapshoot();
        }


        private Image Snapshoot()
        {
            Image img = null;
            try
            {
                var img1 = videoControl.GetCurrentFrame();
                img = new Bitmap(img1); //, new Size(1920, 1080));
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return img;
        }


    }
}
