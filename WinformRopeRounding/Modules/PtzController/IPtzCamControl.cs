namespace WinformRopeRounding.Modules.PtzController
{
    public interface IPtzCamControl
    {
        string ErrorMessage { get; }
        bool Initialised { get; }

        void ActionCommand(int dir);
        string GetPosition();
        void HomePosition();
        Task<bool> InitialiseAsync(string cameraAddress, string userName, string password);
        void PanLeft();
        void PanRight();
        Task SetPositionAsync(string text);
        void Stop();
        void TiltDown();
        void TiltUp();
        void ZoomIn();
        void ZoomOut();
    }
}