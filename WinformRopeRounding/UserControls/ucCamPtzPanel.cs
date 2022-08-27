namespace WinformRopeRounding.UserControls
{
    public partial class ucCamPtzPanel : UserControl
    {
        public event EventHandler<int> OnActionButtonDown;
        public event EventHandler<int> OnActionButtonUp;
        public event EventHandler<int> OnActionButtonClick;
        public ucCamPtzPanel()
        {
            InitializeComponent();
        }

        private void BtnMouseDown(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            var btnIdx = Convert.ToInt16(btn.Tag);
            OnActionButtonDown?.Invoke(sender, btnIdx);
        }

        private void BtnMouseUp(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            var btnIdx = Convert.ToInt16(btn.Tag);
            OnActionButtonUp?.Invoke(sender, btnIdx);
        }

        private void BtnClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var btnIdx = Convert.ToInt16(btn.Tag);
            OnActionButtonClick?.Invoke(sender, btnIdx);
        }

    }
}
