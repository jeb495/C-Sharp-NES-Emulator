using System.Windows.Forms;

//set interface for controller
namespace dotNES.Controllers
{
    interface IController
    {
        void Strobe(bool on);

        int ReadState();

        void PressKey(KeyEventArgs e);

        void ReleaseKey(KeyEventArgs e);
    }
}
