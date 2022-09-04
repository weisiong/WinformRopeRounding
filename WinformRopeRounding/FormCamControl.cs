using System.Diagnostics;
using System.Runtime.InteropServices;
using WinformRopeRounding.Modules.PtzController;
using WinformRopeRounding.Modules.VideoProcessor;
using WinformRopeRounding.UserControls;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormCamControl : Form
    {       
        private ucCamPtzPanel _ctrpanel;
        private PtzCamControl _controller;
        public string CameraIP { get; set; }
        public string CamUsername { get; set; }
        public string CamPassword { get; set; }
        public Image SnapshootImage { get; internal set; }

        private Emgu.CV.UI.ImageBox cameraImageBox;
        VideoProcessor vp;

        public FormCamControl(string Title, string value)
        {
            InitializeComponent();
            this.Text = Title;
            this.txtValue.Text = value;
        }

        private async void FormCamCalibration_Load(object sender, EventArgs e)
        {
            _ctrpanel = ucCamPtzPanel1;
            _ctrpanel.OnActionButtonDown += Ctrpanel_OnButtonMouseDown;
            _ctrpanel.OnActionButtonUp += Ctrpanel_OnButtonMouseUp;
            _ctrpanel.OnActionButtonClick += _ctrpanel_OnActionButtonClick;
            _controller = new PtzCamControl();
            var success = await _controller.InitialiseAsync(CameraIP, CamUsername, CamPassword);
            if (success)
            {
                cameraImageBox = new Emgu.CV.UI.ImageBox();
                if (!splitContainer1.Panel1.Controls.Contains(cameraImageBox))
                {
                    splitContainer1.Panel1.Controls.Add(cameraImageBox);
                    cameraImageBox.Dock = DockStyle.Fill;
                    cameraImageBox.BackgroundImageLayout = ImageLayout.Stretch;
                    cameraImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;

                    lblMessage.Visible = false;
                    string url = string.Format(GlobalVars.VIDEO_SOURCE_FORMAT, CamUsername, CamPassword, CameraIP);
                    vp = new(url, EnumMediaInput.HTTP);
                    vp.OnFrameReceived += Vp_OnFrameReceived;
                    vp.RunContinuously();
                }
                if(!string.IsNullOrEmpty(txtValue.Text))
                    await _controller.SetPositionAsync(txtValue.Text);
            }
            else
            {
                MessageBox.Show("Failed to access camera!");
            }
        }

        private void Vp_OnFrameReceived(object? sender, VideoProcessorEventArgs e)
        {
            var frame = e.MatSrc;
            if (frame is not null && frame.Ptr != IntPtr.Zero)
            {
                cameraImageBox.BackgroundImage = Emgu.CV.BitmapExtension.ToBitmap(frame);
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

        public string InputValue
        {
            get
            {
               return txtValue.Text;
            }
        }
        private void btnGetPosition_Click(object sender, EventArgs e)
        {
            txtValue.Text = _controller.GetPosition();
        }

        private void FrmLocInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ctrpanel.OnActionButtonDown -= Ctrpanel_OnButtonMouseDown;
            _ctrpanel.OnActionButtonUp -= Ctrpanel_OnButtonMouseUp;
            _ctrpanel.OnActionButtonClick -= _ctrpanel_OnActionButtonClick;
            vp.Stop();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var img = Snapshoot();
            if (img is not null)
                SnapshootImage = img;
            this.Close();
        }


        private Image? Snapshoot()
        {
            Image? img = null;
            try
            {
                var img1 = vp.CurrentFrame;
                img = Emgu.CV.BitmapExtension.ToBitmap(img1);  
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return img;
        }

        private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
        {
            var Left = (splitContainer1.Width - lblMessage.Width) / 2;
            var Top = (splitContainer1.Height - lblMessage.Height) / 2;
            lblMessage.Left = Left;
            lblMessage.Top = Top;
        }

    }
}
