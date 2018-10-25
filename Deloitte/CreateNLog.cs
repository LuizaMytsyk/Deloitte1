using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte
{
    public class CreateNLog
    {       
            private static Logger logger = LogManager.GetLogger("Logger");
            public static void NLogCreate()
            {
                var className = TestContext.CurrentContext.Test.ClassName;
                var testName = TestContext.CurrentContext.Test.Name;
                var result = TestContext.CurrentContext.Result.Outcome;

                logger.Debug(className);
                logger.Debug(testName);
                logger.Debug(result.Status);

            }
       
    }
}
