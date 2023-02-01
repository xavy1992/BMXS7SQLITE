using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BMXS7SQLITE
{
    public class Cancha


    {

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [MaxLength(50)]
            public string NombreCancha { get; set; }

            [MaxLength(50)]

            public string Direccion { get; set; }

            [MaxLength(50)]

            public string Precio { get; set; }

        [MaxLength(50)] 
        public string Estado { get; set; }
        }
    }

