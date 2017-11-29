using Common.Logging;
using Common.Logging.Simple;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Topshelf_Quartz
{

    /// <summary>
    /// 注意把配置文件复制到输出目录
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
            HostFactory.Run(x =>
            {
                x.UseLog4Net();

                x.Service<ServiceRunner>();

                x.SetDescription("123Service");
                x.SetDisplayName("1234Service");
                x.SetServiceName("12345Service");
                x.EnablePauseAndContinue();
            });

            Console.Read();
        }
    }
}
