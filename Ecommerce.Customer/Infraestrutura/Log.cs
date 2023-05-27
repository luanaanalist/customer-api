using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public class Log
    {
        public static void InsereLog(ControllerContext context,
            string mensagem,
            string mensagemEx,
            string stackTrace,
            int? idEntidade = null)
        {
            if (idEntidade.HasValue)
                mensagem += Environment.NewLine + "[Id]: " + idEntidade;
            mensagem += Environment.NewLine + "[Erro]: " + mensagemEx;
            mensagem += "[Stack Trace]: " + stackTrace;

            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
        }
    }
}
