using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularFormGenerator
{
    class Form
    {
        public string EntityName { get; set; }
        public List<FormField> Fields { get; set; }
        public Form(string _EntityName, List<FormField> _Fields)
        {
            this.EntityName = _EntityName;
            this.Fields = _Fields;
        }

        public String GenerateIndex()
        {
            String view = "";
            view+= "<script src='https://code.jquery.com/jquery-2.1.4.min.js'></script>";
            view += "<link rel = 'stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/css/materialize.min.css' >\n";
            view += " <script src = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/js/materialize.min.js' ></script >";
            view += "<div class='angularForm' ng-controller ='" + EntityName + "Controller'>\n";
            view += "   <div class='tableWrap'>\n";
            view += "       <table>\n";
            view += "           <thead>\n";
            view += "               <th>Id</th>\n";

            var columns =
                from col in Fields
                where col.Type == "text" || col.Type == "number" || col.Type == "date"
                select col;

            foreach (var Attr in columns)
            {
                view += "               <th>" + Attr.Name + "</th>\n";
            }
            view += "           </thead>\n";
            view += "           <tbody>\n";
            view += "               <tr ng-repeat='"+ EntityName +" in "+ EntityName +"s'>\n";
            view += "                   <td> {{ " + EntityName + ".Id }} </td>\n";
            foreach (var Attr in columns)
            {
                view += "                   <td> {{ "+EntityName+"."+ Attr.Name +" }} </td>\n";
            }
            view += "               </tr>\n";
            view += "           </tbody>\n";
            view += "       </table>\n";
            
            view += "   </div>\n";
            view += "</div>\n";
            return view;
        }
        public String GenerateNew()
        {
            String view = "";
            view += "<script src='https://code.jquery.com/jquery-2.1.4.min.js'></script>\n";
            view += "<link rel = 'stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/css/materialize.min.css' >\n";
            view += "<script src = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/js/materialize.min.js' ></script >\n";
            view += "<div class='angularForm' ng-controller ='" + EntityName + "Controller'>\n";
            view += "   <form novalidate>\n";
            foreach (var Attr in Fields)
            {
               view += Attr.GenerateField(EntityName);

                //view += "       <p class='attr'>\n";
                //view += "           <label for='" + Attr.Name + "'>" + Attr.Name + "</label>\n";
                //view += "           <input type='" + Attr.Type + "' ng-model='" + Attr.Name + "' name='" + Attr.Name+ "' id='" + Attr.Name + "'>\n";
                //view += "       </p>\n";
            }
            view += "       <button class='btn waves-effect' ng-click='submit()'>Enviar</button>\n";
            view += "   </form>\n";
            view += "</div>\n";
            return view;
        }

        public String GenerateShow()
        {
            String view = "";
            view += "<script src='https://code.jquery.com/jquery-2.1.4.min.js'></script>";
            view += "<link rel = 'stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/css/materialize.min.css' >\n";
            view += "<script src = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/js/materialize.min.js' ></script >\n";
            view += "<div class='angularForm' ng-controller ='" + EntityName + "Controller'>\n";
            view += "   <div class='showDiv'>\n";
            view += "       <h4> Detalle de "+EntityName+"</h4>\n";

            foreach (var Attr in Fields)
            {
                view += Attr.GenerateField(EntityName, "readonly", EntityName + "." + Attr.Name);
                //view += "       <p class='attr'>\n";
                //view += "           <label for='" + Attr.Name + "'>" + Attr.Name + "</label>\n";
                //view += "           <input type='" + Attr.Type + "' ng-model='" + Attr.Name + "' name='" + Attr.Name + "' id='" + Attr.Name + "' value='{{"+EntityName+"."+Attr.Name+"}}' readonly>\n";
                //view += "       </p>\n";
            }
            view += "       <Button class='btn waves-effect' ng-click='delete()'>Eliminar</Button>\n";
            view += "   </div>\n";
            view += "</div>\n";
            return view;
        }

        public String GenerateEdit()
        {
            String view = "";
            view += "<script src='https://code.jquery.com/jquery-2.1.4.min.js'></script>";
            view += "<link rel = 'stylesheet' href = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/css/materialize.min.css' >\n";
            view += "<script src = 'https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.1/js/materialize.min.js' ></script >\n";
            view += "<div class='angularForm' ng-controller ='" + EntityName + "Controller'>\n";
            view += "   <div class='showDiv'>\n";
            view += "       <h4> Detalle de " + EntityName + "</h4>\n";

            foreach (var Attr in Fields)
            {
                view += Attr.GenerateField(EntityName, "",EntityName+"."+Attr.Name);
                //view += "       <p class='attr'>\n";
                //view += "           <label for='" + Attr.Name + "'>" + Attr.Name + "</label>\n";
                //view += "           <input type='" + Attr.Type + "' ng-model='" + Attr.Name + "' name='" + Attr.Name + "' id='" + Attr.Name + "' value='{{" + EntityName + "." + Attr.Name + "}}' >\n";
                //view += "       </p>\n";
            }
            view += "       <Button class='btn waves-effect' ng-click='edit()'>Enviar</Button>\n";
            view += "   </div>\n";
            view += "</div>\n";
            return view;
        }


    }
}
