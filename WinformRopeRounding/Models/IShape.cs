using Cyotek.Windows.Forms;

namespace WinformRopeRounding.Models
{
    interface IShape
    {
        List<Point> Points { get; set; }

        void AddNewImagePoint(ImageBox imgBox, Point e);
        void Reset();
        void Draw(Image img);
        void DrawRubberLine(Control ctr, Point currentLocation);
        void Draw(Image image, Color color);
    }
}
