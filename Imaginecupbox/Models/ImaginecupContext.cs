using Imaginecupbox.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Imaginecupbox.Models
{
    //Enable-Migrations -EnableAutomaticMigrations
    //update-database
    public class ImaginecupContext : DbContext
    {
        public ImaginecupContext()
            : base("name=imaginecup")
        {
            
        }
        
        public DbSet<Aluno> Alunos { get; set; }

        


    }
}