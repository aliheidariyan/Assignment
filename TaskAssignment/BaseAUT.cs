using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAssignment
{
    public class BaseAUT : IDisposable
    {
        public BaseAUT()
        {
            Browsers.Init(Browsers.Platforms.Apk);
        }

        public virtual void Dispose()
        {
            Browsers.Close();
        }

        protected string CurrentUrl => Browsers.Driver.Url;

        protected void WaitAMoment()
        {
            Thread.Sleep(2000);
        }
    }
}
