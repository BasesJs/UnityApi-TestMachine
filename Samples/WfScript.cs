using UnityApi.Types;

namespace TestWorkflowScript
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Hyland.Unity;
    using Hyland.Unity.CodeAnalysis;
    using Hyland.Unity.Workflow;


    /// <summary>
    /// [OGC] Delete Envelope on Case Closed
    /// </summary>
    public class WorkflowScript //: Hyland.Unity.IWorkflowScript
    {

        #region IWorkflowScript
        /// <summary>
        /// Implementation of <see cref="IWorkflowScript.OnWorkflowScriptExecute" />.
        /// <seealso cref="IWorkflowScript" />
        /// </summary>
        /// <param name="app"></param>
        /// <param name="args"></param>
        public void OnWorkflowScriptExecute(Hyland.Unity.Application app, UnityApi.Types.WorkflowEventArgs args)
        {
            
        }
        #endregion
    }
}