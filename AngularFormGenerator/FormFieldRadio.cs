using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularFormGenerator
{
    class FormFieldRadio : FormField
    {
        public List<string> options { get; set; }

        public FormFieldRadio()
        {
            options = new List<string>();
        }

        override
        public string GenerateField(string Entity, string InputTagOptions = "", string Value = "")
        {
            string Field = "<p>"+Name+"</p>";
            foreach (var option in options)
            {
                Field += "<p>";
                Field += "  <input type='" + Type + "'ng-model='" + Name + "' name='" + Name + "' id='" + option + "' " + InputTagOptions + " value='" + option + "'/>\n";
                Field += "  <label for='" + option + "'>" + option + "</label>\n";
                Field += "</p>";
            }
                    
            return Field;
        }
    }
}
