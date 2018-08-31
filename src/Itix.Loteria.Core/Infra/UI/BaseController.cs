using Core.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itix.Agenda.Core.Infra.UI
{
    public class BaseController : Controller
    {

        JsonSerializerSettings DefaultJsonSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());


            return settings;
        }

        public ActionResult JsonSuccess(object data)
        {
            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(data, settings);

            return Json(data, DefaultJsonSettings());
        }


        public ActionResult JsonFail(List<MessageResult> messages,
            string code = null,
            object data = null,
            int httpStatusCode = 400// inválid request por padrão
            )
        {
            // Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = httpStatusCode;

            return Json(messages, DefaultJsonSettings());
        }


        public JsonResult JsonSuccess()
        {
            return Json(new { status = "ok" });
        }
    }
}
