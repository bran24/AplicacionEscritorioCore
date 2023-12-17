using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;
using ORM;
namespace AplicacionEscritorioCore.Cotrolador
{
    public class LoginCtrllr
    {


        public LoginCtrllr()
        {
           
        
        }

        public bool verificarUs(string username, string password)
        {

            using (var context = new OrmContext())
            {
                var resp = context.usuarios.SingleOrDefault(a =>a.username == username && a.password == password) ==null?0:1;


                if(resp == 0)
                {
                    return false;
                }

                return true;
            }

        }









    }
}
