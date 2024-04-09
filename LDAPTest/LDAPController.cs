using System;
using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;

namespace LDAPTest.Controllers
{
    public class LDAPController : Controller
    {
        public IActionResult Index()
        {
            string ldapServer = "54.242.167.217";
            string ldapUsername = "cn=Nushan Chamara,ou=dev,ou=development,dc=paymedia,dc=lk";
            string ldapPassword = "1515";

            try
            {
                using (var ldapConnection = new LdapConnection())
                {
                    ldapConnection.Connect(ldapServer, 389);
                    ldapConnection.Bind(ldapUsername, ldapPassword);
                    if (ldapConnection.Bound)
                    {
                        return Content("LDAP bind successful");
                    }
                    else
                    {
                        return Content("LDAP bind failed");
                    }
                }
            }
            catch (LdapException lex)
            {
                // Handle LDAP-specific exceptions
                return Content($"LDAP connection failed: {lex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return Content($"An error occurred: {ex.Message}");
            }
        }
    }
}
