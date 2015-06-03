using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace final
{
    public class RootObject
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class RootObjectProcesos
    {
        public int id { get; set; }
        public int procedure_id { get; set; }
        public int group_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

    public class RootObjectPasos
    {
        public int id { get; set; }
        public int step_id { get; set; }
        public int procedure_id { get; set; }
        public string content { get; set; }
        public string url { get; set; }
    }
    public class Field
    {
        public int id { get; set; }
        public string caption { get; set; }
        public string field_type { get; set; }
        public List<string> possible_values { get; set; }
    }

    public class Branch
    {
        public int field_id { get; set; }
        public string comparison_type { get; set; }
        public string value { get; set; }
    }

    public class Decision
    {
        public List<Branch> branch { get; set; }
        public string go_to_step { get; set; }
    }

    public class Contenido
    {
        public List<Field> Fields { get; set; }
        public List<Decision> Decisions { get; set; }
    }
   /* public class Helado
    {
        public string pregunta { get; set; }
    }

    public class Comida
    {
        public string nombre2 { get; set; }
        public List<Helado> helado { get; set; }
    }

    public class Pc
    {
        public string pregunta { get; set; }
    }

    public class Mantenimiento
    {
        public string nombre2 { get; set; }
        public List<Pc> pc { get; set; }
    }

    public class Proceso
    {
        public string nombre { get; set; }
        public Comida comida { get; set; }
        public Mantenimiento Mantenimiento { get; set; }
    }

    public class RootObject
    {
        public List<Proceso> procesos { get; set; }
    }*/
}
