using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularFormGenerator
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter the entity name");
            var EntityName = Console.ReadLine();

            Console.WriteLine("Enter at least one attribute for the entity");
            List<FormField> Attrs = new List<FormField>();

            bool flag = false;
            do
            {

                
                Console.WriteLine("Enter the name of the attribute");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter the type of the attribute");

                string Type = Console.ReadLine();

                while(!FormField.AllowedTypes.TryGetValue(Type, out Type))
                {
                    Console.WriteLine("Enter a valid type");
                    Type = Console.ReadLine();
                }

                
                if (Type=="radio")
                {
                    FormFieldRadio Attr = new FormFieldRadio();
                    Console.WriteLine("How many options for this attribute?");
                    int OptionsNumber;
                    string StringOptionsNumber =Console.ReadLine();
                    while (!int.TryParse(StringOptionsNumber, out OptionsNumber))
                    {
                        Console.WriteLine("Enter a integer number");
                        StringOptionsNumber = Console.ReadLine();
                    }
                    
                    
                    for (int i = 0; i < OptionsNumber; i++)
                    {
                        Console.WriteLine("Enter option " + i);
                        Attr.options.Add(Console.ReadLine());
                    }
                    Attr.Name = Name;
                    Attr.Type = Type;
                    Attrs.Add(Attr);
                }
                else
                {
                    FormField Attr = new FormField();
                    Attr.Name = Name;
                    Attr.Type = Type;
                    Attrs.Add(Attr);
                }

                Console.WriteLine("Do you want to add another attribute? [y/n]");

                string yesOrNo = null;

                do
                {
                    if(yesOrNo!=null)
                    {
                        Console.WriteLine("por favor solo ingrese y o n");
                    }
                    yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        flag = true;
                    }
                    if (yesOrNo == "n")
                    {
                        flag = false;
                    }
                } while (yesOrNo != "y" && yesOrNo != "n");

            } while (flag);

            string path = AppDomain.CurrentDomain.BaseDirectory;

            Form form = new Form(EntityName, Attrs);
            string Index, New, Edit, Show;
            Index = form.GenerateIndex();
            New = form.GenerateNew();
            Show = form.GenerateShow();
            Edit = form.GenerateEdit();
            System.IO.Directory.CreateDirectory(path + "/views");
            string[] paths =  new string[]{ path + "/views/Index.html", path + "/views/New.html", path+"views/Show.html", path + "views/Edit.html" };
            string[] filesContent = new string[]{ Index, New, Show, Edit };
            GenerateFiles(paths, filesContent);
            


        }

        private static void GenerateFiles(string[] paths, string[] FilesContent)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                System.IO.File.WriteAllText(paths[i],FilesContent[i]);
            }
            
            Console.ReadLine();
        }
    }
}
