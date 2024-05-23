using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityApi.Types;
using UnityApi.Interfaces;

namespace UnityScriptTester
{
    internal class Program
    {
        public static string username = "MANAGER";
        public static string password = "P@ssw0rd";
        public static string appserver = @"https://dev-onbase/app/service.asmx";
        public static string datasource = "OnBase";
        public static string lifecycleName = "RRM - UF - Record Request Form Processing";
        public static string queueName = "Initial";
        public static long document = 149;        
        static void Main(string[] args)
        {
            IDictionary<string, object> sessionPb = new Dictionary<string, object>();
            /* ADD ANY SESSION PROPERTIES */
            IDictionary<string, object> scopedPb = new Dictionary<string, object>();
            /* ADD ANY SCOPED PROPERTIES */
            IDictionary<string, object> persistentPb = new Dictionary<string, object>();
            /* ADD ANY PERSISTANT PROPERTIES */

            /* CONNECT TO ONBASE */
            OnBaseConnection conn = OnBaseConnection.Create(username, password, appserver, datasource);
            conn.Connect();

            /* New Script */
            WorkflowScript script = new WorkflowScript();

            /* Build Script Args */ 
            Hyland.Unity.Document doc = conn.Application.Core.GetDocumentByID(document);
            Hyland.Unity.Workflow.LifeCycle lifecycle = conn.Application.Workflow.LifeCycles.Find(lifecycleName);
            Hyland.Unity.Workflow.Queue queue = conn.Application.Workflow.Queues.Find(queueName);
            UnityApi.Types.PropertyBag sessionPropertyBag = new PropertyBag(sessionPb);
            UnityApi.Types.PropertyBag scopedPropertyBag = new PropertyBag(scopedPb);
            UnityApi.Types.PropertyBag persistentPropertyBag = new PropertyBag(persistentPb);
            WorkflowEventArgs wfArgs = new WorkflowEventArgs(doc, queue, sessionPropertyBag, scopedPropertyBag, persistentPropertyBag, 1, false);
            
            try
            {
                script.OnWorkflowScriptExecute(conn.Application, wfArgs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
