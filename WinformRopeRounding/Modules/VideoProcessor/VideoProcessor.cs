using Emgu.CV;

namespace WinformRopeRounding.Modules.VideoProcessor
{
    public class VideoProcessorEventArgs : EventArgs
    {
        public Mat? MatSrc { get; set; }
    }
    public class VideoProcessor
    {
        public event EventHandler<VideoProcessorEventArgs>? OnFrameReceived;

        private bool _isStop = false;
        private bool _isPause = false;
        private readonly EnumMediaInput _mediaInput;

        private VideoCapture cam  = new();
        private readonly string _uri = string.Empty;

        public VideoProcessor(string uri, EnumMediaInput mediaInput)
        {
            CvInvoke.Init();
            _uri = uri;
            _mediaInput = mediaInput;
        }

        //public Mat CurrentFrame => cam.QueryFrame();
        public Mat CurrentFrame { get; internal set; }
        public async void Run()
        {
            if (_mediaInput == EnumMediaInput.RTSP || _mediaInput == EnumMediaInput.VIDEO)
            {
                cam = new VideoCapture(_uri);
                cam.ImageGrabbed += Cam_ImageGrabbed;
                cam.Start();
                //Application.Idle += RefreshFrames;
                
            }
            else
            {
                while (true)
                {
                    if (_isStop) break;

                    while (_isPause)
                    {
                        if (!_isPause) break;
                        if (_isStop) break;
                        Application.DoEvents();
                        await Task.Delay(1000);
                    }

                    if (_mediaInput == EnumMediaInput.PICS)
                    {
                        var files = Directory.GetFiles(_uri);
                        foreach (var file in files)
                        {
                            cam = new VideoCapture(file);
                            RaiseOnFrameReceivedEvent();
                        }
                    }
                    else
                    {
                        if (_mediaInput == EnumMediaInput.HTTP || _mediaInput == EnumMediaInput.PIC)
                            cam = new VideoCapture(_uri);

                        RaiseOnFrameReceivedEvent();
                    }
                    Application.DoEvents();
                    await Task.Delay(100);
                }
            }
        }

        public Mat Snapshot()
        {
            Mat img = new();
            cam = new VideoCapture(_uri);
            if(cam is not null) img = cam.QueryFrame();
            return img; 
        }

        private void RaiseOnFrameReceivedEvent()
        {
            //Mat refMat = cam.QueryFrame();
            CurrentFrame = cam.QueryFrame();
            if (CurrentFrame != null)
            {
                var e = new VideoProcessorEventArgs() { MatSrc = CurrentFrame };
                OnFrameReceived?.Invoke(this, e);
            }
        }
 
        private void Cam_ImageGrabbed(object? sender, EventArgs e)
        {
            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} Cam_ImageGrabbed");
            //Mat refMat = new();
            //cam.Retrieve(refMat);
            Mat refMat = cam.QueryFrame();
            var arg = new VideoProcessorEventArgs() { MatSrc = refMat };
            OnFrameReceived?.Invoke(this, arg);
        }
        public void Start()
        {
            cam.Start();
        }
        public void Stop()
        {
            cam.Stop();
            _isStop = true;
        }

        public void Pause()
        {
            //cam.Pause();
            _isPause = !_isPause;
        }

        public bool IsPlaying {
            get
            {
                return (!_isPause && !_isStop);
            }
        }

    }
}