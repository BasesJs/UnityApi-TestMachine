using System.Runtime.InteropServices;
using UnityApi.Types;
using TestWorkflowScript;

string username = "MANAGER";
string password = "P@ssw0rd";
string appserver = @"https://dev-onbase/app/service.asmx";
string datasource = "OnBase";
string queueName = "queue";
long document = 0;

IDictionary<string, object> sessionPb = new Dictionary<string, object>();
/* ADD ANY SESSION PROPERTIES */
IDictionary<string, object> scopedPb = new Dictionary<string, object>();
/* ADD ANY SCOPED PROPERTIES */
IDictionary<string, object> persistentPb = new Dictionary<string, object>();
/* ADD ANY PERSISTANT PROPERTIES */

OnBaseConnection conn = OnBaseConnection.Create(username, password, appserver, datasource);
conn.Connect();

Hyland.Unity.Document doc = conn.Application.Core.GetDocumentByID(document);
Hyland.Unity.Workflow.Queue queue = conn.Application.Workflow.Queues.Find(queueName);
UnityApi.Types.PropertyBag sessionPropertyBag = new PropertyBag(sessionPb);
UnityApi.Types.PropertyBag scopedPropertyBag = new PropertyBag(scopedPb);
UnityApi.Types.PropertyBag persistentPropertyBag = new PropertyBag(persistentPb);

WorkflowEventArgs wfArgs = new WorkflowEventArgs(doc, queue, sessionPropertyBag, scopedPropertyBag, persistentPropertyBag, 1, false);
WorkflowScript script = new WorkflowScript();
try
{
    script.OnWorkflowScriptExecute(conn.Application, wfArgs);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}


