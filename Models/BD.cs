using System.Net.Mime;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System;
using TP8JS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
namespace TP_DAI_Brodsky_Rizzolo.Models;

public static class BD
{
    
    private static string _connectionString = @"Server=A-PHZ2-AMI-018\SQLEXPRESS;DataBase=BDSeries;Trusted_Connection=True;";
    
private static  List<Pizzas> _ListaPizzas = new List<Pizzas>();
 public static List<Pizzas> ListarPizzas()
   {
    using(SqlConnection db =  new  SqlConnection(_connectionString)){
        string sql = "Select *  FROM Pizzas";
        _ListaSeries= db.Query<Pizzas>(sql).ToList();
    }
    return _ListaPizzas;
   }
}