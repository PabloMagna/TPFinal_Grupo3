using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace TP_Final
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Script para incluir Jquery (para validacion sin obstrucciones en form de alta)
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.3.1.min.js",
                DebugPath = "~/scripts/jquery-3.3.1.js",
                CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js",
                CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.js"
            });
        }
    }
}