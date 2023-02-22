using SQLite;
using SQLITEDemo.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo.MVVM.Models
{
    [Table("Customers")]
    public class Customer : TableData
    {
        // [PrimaryKey, AutoIncrement]
        // public int Id { get; set; }
        
        [Column("Name"), Indexed, NotNull]
        public string Name { get; set; }
        
        [Unique]
        public string Phone { get; set; }
        
        public int Age { get; set; }
        
        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung => Age < 50;
        /*
         * OneToOne Relation
        [ForeignKey(typeof(Passport))]
        public int PassportId { get; set; }

        [OneToOne(CascadeOperations =
              CascadeOperation.CascadeInsert
            | CascadeOperation.CascadeRead
            | CascadeOperation.CascadeDelete)]
        [OneToOne(CascadeOperations = CascadeOperation.All)]

        public Passport Passport { get; set; }
        */


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Passport> Passports { get; set; }
        

    }
}
