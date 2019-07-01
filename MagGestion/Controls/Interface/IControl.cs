using System.Windows.Forms;

namespace MagGestion.Controls.Interface
{
    public interface IControl
    {
        Control Parent { get; set; }
        void Load();
    }
}
