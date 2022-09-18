using System.Globalization;
using WinformRopeRounding.Modules.CamCalibration;
using WinformRopeRounding.Utilities;

namespace WinformRopeRounding
{
    public partial class FormCamCalibration : Form
    {
        private readonly CameraCalibrator camCal;
        private readonly string _camId;

        public FormCamCalibration(string CameraId,string url)
        {
            InitializeComponent();
            _camId = CameraId;
            var bufVal =(int) nudBufferFrame.Value;
            camCal = new CameraCalibrator(url, bufVal);
        }

        private void BtnStartCalibrate_Click(object sender, EventArgs e)
        {
            camCal.Start();
            camCal.OnSavingFrame += CamCalibrator_OnSavingFrame;
            camCal.OnUndistoredFrame += CamCal_OnUndistoredFrame;
            camCal.OnCalibrationDone += CamCal_OnCalibrationDone;
        }

        private void CamCal_OnCalibrationDone(object? sender, double e)
        {
            MessageBox.Show("Intrinsic Calculation Error: " + e.ToString(CultureInfo.InvariantCulture), @"Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CamCal_OnUndistoredFrame(object? sender, Emgu.CV.Mat e)
        {
            Main_Picturebox.Image = e;
        }

        private void CamCalibrator_OnSavingFrame(object? sender, Emgu.CV.Mat e)
        {
            Sub_PicturBox.Image = e;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            camCal.IntrinsicParas = GlobalVars.AppSetting.Cams[_camId].IntrinsicParas;
            camCal.DistortionCoefficients = GlobalVars.AppSetting.Cams[_camId].DistCoeffParas;
            camCal.CurrentMode = CameraCalibrator.Mode.Calibrated;
            camCal.OnSavingFrame += CamCalibrator_OnSavingFrame;
            camCal.OnUndistoredFrame += CamCal_OnUndistoredFrame;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            GlobalVars.AppSetting.Cams[_camId].IntrinsicParas = camCal.IntrinsicParas;
            GlobalVars.AppSetting.Cams[_camId].DistCoeffParas = camCal.DistortionCoefficients;
        }

    }
}
