using System;
using Novell.Directory.Ldap;

string ldapHost = "ad.pu.ru";
int ldapPort = 389; 
string username = "";
string password = ""; 
string searchBase = "DC=ad,DC=pu,DC=ru";
string searchFilter = "(&(objectClass=person)(memberOf=CN=АкадемГруппа_22.Б11-мм,OU=АкадемГруппа,OU=Группы,DC=ad,DC=pu,DC=ru))";

var connection = new LdapConnection();
connection.Connect(ldapHost, ldapPort);
connection.Bind(username, password);

var results = connection.Search(
    searchBase,
    LdapConnection.SCOPE_SUB,
    searchFilter,
    new[] { "sAMAccountType" }, 
    false
);

while (results.hasMore())
{
    var entry = results.next();
    Console.WriteLine(entry.getAttribute("sAMAccountType").StringValue);
}

connection.Disconnect();

