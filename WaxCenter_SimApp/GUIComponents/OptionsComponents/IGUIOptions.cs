using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaxCenter_SimApp.GUIComponents.OptionsComponents
{
    public enum GUIOptionsType
    {
        RESPOOL
    }
    public interface IGUIOptions
    {
        GUIOptionsType OptionsType { get; }
    }
}
