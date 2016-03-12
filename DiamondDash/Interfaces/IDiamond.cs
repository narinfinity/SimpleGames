using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DiamondDash
{
    public interface IDiamond : IDisposable
    {
        void Display();
        void Disappear();
        void Shine();
        void FallTo(int fallHeight);
        bool Locked { get; set; }
        int Index { get; }
        int ImgIndex { get; }        
    }
}
