using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.View
{
    public interface IViewWithParameters
    {
        void InitializeWith(object parameter);
    }
}
