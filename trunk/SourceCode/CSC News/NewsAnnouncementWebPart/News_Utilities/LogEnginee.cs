using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsAnnouncementWebPart.News_Utilities
{
    public class LogEnginee : SPDiagnosticsServiceBase
    {
        public static string CSCNewsDiagnosticName = NewsString.projectName;
        private static LogEnginee _Current;
        public static LogEnginee Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new LogEnginee();
                }
                return _Current;
            }
        }

        private LogEnginee()
            : base(NewsString.LogginEngineeName, SPFarm.Local)
        {
            
        }

        protected override IEnumerable<SPDiagnosticsArea> ProvideAreas()
        {
            List<SPDiagnosticsArea> areas = new List<SPDiagnosticsArea>
        {
            new SPDiagnosticsArea(CSCNewsDiagnosticName, new List<SPDiagnosticsCategory>
            {
                new SPDiagnosticsCategory("WebParts", TraceSeverity.Unexpected, EventSeverity.Error)
            })
        };

            return areas;
        }

        public static void LogError(String categoryName, String errorMessage)
        {
            SPDiagnosticsCategory category = LogEnginee.Current.Areas[CSCNewsDiagnosticName].Categories[categoryName];
            LogEnginee.Current.WriteTrace(0, category, TraceSeverity.Unexpected, errorMessage);
        }

        public static void WriteTrace(Exception ex)
        {
            SPDiagnosticsService diagSvc = SPDiagnosticsService.Local;
            diagSvc.WriteTrace(0,
                new SPDiagnosticsCategory("CSCV_News",
                    TraceSeverity.Monitorable,
                    EventSeverity.Error),
                TraceSeverity.Monitorable,
                "An exception occurred: {0}",
                new object[] { ex });
        }
    }
}
