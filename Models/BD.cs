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
    
    private static string CONNECTION_STRING = @"Server=A-PHZ2-AMI-018\SQLEXPRESS;DataBase=BDSeries;Trusted_Connection=True;";
    

public static List<Pizzas> GetAll() {

string sqlQuery;

List<Pizzas> returnList;

returnList = new List<Pizzas>();

using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {

sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas";

returnList = db.Query<Pizzas>(sqlQuery).ToList();

}

return returnList;

}
public static Pizzas GetById(int id) {

string sqlQuery;

Pizzas returnEntity = null;

sqlQuery = "SELECT Id, Nombre, LibreGluten, Importe, Descripcion FROM Pizzas ";

sqlQuery += "WHERE Id = @idPizza";

using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {

returnEntity = db.QueryFirstOrDefault<Pizzas>(sqlQuery, new { idPizza = id });

}

return returnEntity;

}
public static int Insert(Pizzas pizza) {

string sqlQuery;

int intRowsAffected = 0;

sqlQuery = "INSERT INTO Pizzas (";

sqlQuery += " Nombre , LibreGluten , Importe , Descripcion";

sqlQuery += ") VALUES (";

sqlQuery += " @nombre , @libreGluten , @importe , @descripcion";

sqlQuery += ")";

using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {

intRowsAffected = db.Execute(sqlQuery, new {

nombre = pizza.Nombre,

libreGluten =
pizza.LibreGluten,

importe = pizza.Importe,

descripcion =
pizza.Descripcion

}

);

}

return intRowsAffected;
}
public static int UpdateById(Pizzas pizza) {

string sqlQuery;

int intRowsAffected = 0;

sqlQuery = "UPDATE Pizzas SET ";

sqlQuery += " Nombre = @nombre, ";

sqlQuery += " LibreGluten = @libreGluten, ";

sqlQuery += " Importe = @importe, ";

sqlQuery += " Descripcion = @descripcion ";

sqlQuery += "WHERE Id = @idPizza";

using (var db = new SqlConnection(CONNECTION_STRING)) {

intRowsAffected = db.Execute(sqlQuery, new {

idPizza = pizza.IdPizza,

nombre = pizza.Nombre,

libreGluten = pizza.LibreGluten,

importe = pizza.Importe,

descripcion = pizza.Descripcion

}

);

}

return intRowsAffected;

}
public static int DeleteById(int id) {

string sqlQuery;

int intRowsAffected = 0;

sqlQuery = "DELETE FROM Pizzas WHERE Id = @idPizza";

using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {

intRowsAffected = db.Execute(sqlQuery, new { idPizza = id });

}

return intRowsAffected;

}
}