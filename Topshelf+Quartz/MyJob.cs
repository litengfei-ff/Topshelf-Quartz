
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf_Quartz.ServiceReference;

namespace Topshelf_Quartz
{
    public class MyJob : IJob
    {
        private ILog logger;

        public MyJob()
        {
            logger = LogManager.GetLogger(this.GetType());
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                logger.Info("start");

                ServiceReference.WebServiceSoapClient client = new WebServiceSoapClient();
                var result = client.HelloWorld();
                 
                logger.Info("got it：" + result);

            }
            catch (Exception e)
            {
                logger.Error("出现异常：" + e.Message);
                logger.Error(e.StackTrace);
            }

        }
    }
}
