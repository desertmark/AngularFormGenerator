using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularFormGenerator
{
    public class FormField
    {
        public string EntityName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public static Dictionary<string, string> AllowedTypes = new Dictionary<string, string>
            {
                { "button", "button" },
                { "checkbox", "checkbox" },
                { "color", "color" },
                { "date", "date" },
                { "datetime", "datetime" },
                { "datetime-local", "datetime-local" },
                { "email", "email" },
                { "file", "file" },
                { "hidden", "hidden" },
                { "image", "image" },
                { "month", "month" },
                { "number", "number" },
                { "password", "password" },
                { "radio", "radio"},
                { "range", "range" },
                { "reset", "reset" },
                { "search", "search" },
                { "submit", "submit" },
                { "tel", "tel" },
                { "text", "text" },
                { "textarea", "textarea"},
                { "time", "time" },
                { "url", "url" },
                { "week", "week" },
                //sobrecargas
                { "int" , "number" },
                { "string" , "text" },
                { "bool" , "checkbox" }
            };

        public virtual string GenerateField(string Entity, string InputTagOptions = "", string Value="")
        {
            string Field = "";
            switch (Type)
            {
                //case "radio":

                //    foreach (var option in options)
                //    {
                //        Field += "<p>";
                //        Field += "  <input type='" + Type + "'ng-model='" + Name + "' name='"+ Name +"' id='" + option + "' " + InputTagOptions + " value='{{" + option + "}}'/>\n";
                //        Field += "  <label for='" + option + "'>" + Name + "</label>\n";
                //        Field += "</p>";
                //    }
                //    //Field += "<p>";
                //    //Field += "  <input type='" + Type + "'ng-model='" + Name + "' name='radio' id='" + Name + "' "+ InputTagOptions + " value='{{" +Value+ "}}'/>\n";
                //    //Field += "  <label for='" + Name + "'>" + Name + "</label>\n";
                //    //Field += "</p>";
                //    break;
                case "checkbox":
                    Field += "<p>";
                    Field += "  <input type='" + Type + "'ng-model='" + Name + "' id='" + Name + "' " + InputTagOptions + " />\n";
                    Field += "  <label for='" + Name + "'>" + Name + "</label>\n";
                    Field += "</p>";
                    break;
                case "date":
                    Field += "<p>";
                    Field += "  <label for='" + Name + "'>" + Name + "</label>\n";
                    Field += "  <input type='" + Type + "'ng-model='" + Name + "' id='" + Name + "' class='datepicker'  " + InputTagOptions + " value='{{" + Value + " | date:'dd / MM / yyyy'}}/>\n";
                    Field += "</p>";
                    break;
                case "textarea":
                    Field += "<label for='" + Name + "'>" + Name + "</label>\n";
                    Field += "<textarea ng-model='" + Name + "' id='" + Name + "'  " + InputTagOptions + " class='materialize-textarea' > " + Value + "</textarea>\n";
                    break;
                default:
                    Field += "<label for='" + Name + "'>" + Name + "</label>\n";
                    Field += "<input type='" + Type + "'ng-model='"+Name+"' name='"+Name+ "' id='" + Name + "'  " + InputTagOptions + " />\n";
                    break;
            }
            return Field;
        }      

    }

    
}
