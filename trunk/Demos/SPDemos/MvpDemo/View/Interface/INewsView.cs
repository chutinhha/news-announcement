using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvpDemo.View.Interface
{
    public interface INewsView
    {
        IEnumerable<Part> Parts { get; set; }
        void DataBind();
        string ErrorMessage { get; set; }

    }
}
