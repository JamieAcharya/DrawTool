using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTool
{
    /// <summary>
    /// Custom Generated Exception Handling
    /// </summary>
    class Exceptions : Exception
    {
    }
}

[Serializable]
class EndloopNotFoundException : Exception
{
    public EndloopNotFoundException()
    {
        
        MessageBox.Show("Include endloop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        return;
    }


    public EndloopNotFoundException(int endloop)
        : base(String.Format("Endloop is an invalid integer (" + endloop.ToString() + ") Include endloop"))
    {
        MessageBox.Show("Endloop has an invalid value: " + endloop + " Make Sure you included endloop!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
}

[Serializable]
class InvalidFileTypeException : Exception
{
    public InvalidFileTypeException()
    {
        MessageBox.Show("File Is Not A Valid Image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    public InvalidFileTypeException(string message)
        : base(String.Format("File Is Not A Valid Image!"))
    {
        MessageBox.Show("File Is Not A Valid Image!l", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

}
