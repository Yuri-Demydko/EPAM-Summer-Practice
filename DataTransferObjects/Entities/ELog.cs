using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ELog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        [Column(TypeName ="Xml")]
        public string Properties { get; set; }
        public string LogEvent { get; set; }
    }
}