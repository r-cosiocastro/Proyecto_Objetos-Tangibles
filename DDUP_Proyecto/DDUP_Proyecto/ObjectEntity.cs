using System;

namespace DDUP_Proyecto
{
    public class ObjectEntity
    {
        public string ID { get; set; }
        public String Tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoID { get; set; }

        public ObjectEntity(string id, String type, string name, string description)
        {
            this.ID = id;
            this.Tipo = type;
            this.Nombre = name;
            this.Descripcion = description;
            this.TipoID = 0;
        }

        public ObjectEntity(string id, string name, string description)
        {
            this.ID = id;
            this.Tipo = "Default";
            this.Nombre = name;
            this.Descripcion = description;
            this.TipoID = 0;
        }

        public ObjectEntity(string id, String type, string name, string description, int typeId)
        {
            this.ID = id;
            this.Tipo = type;
            this.Nombre = name;
            this.Descripcion = description;
            this.TipoID = typeId;
        }

        public ObjectEntity getRandomObject()
        {
            return new ObjectEntity("0", "Trash", "Basura", "Basura");
        }
    }
}
