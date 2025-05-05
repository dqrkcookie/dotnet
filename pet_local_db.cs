using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawfect_Care
{
    [SQLite.Table("pet_list")]
    public class pet_local_db
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("id")]
        public int pet_id { get; set; }
        [SQLite.Column("name")]
        public string pet_name { get; set; }
        [SQLite.Column("gender")]
        public string pet_gender { get; set; }
        [SQLite.Column("age")]
        public string pet_age { get; set; }
        [SQLite.Column("breed")]
        public string pet_breed { get; set; }
        [SQLite.Column("image")]
        public string pet_image_path { get; set; }
    }
}
