using System; //.NET System
using System.DirectoryServices;
using System.DirectoryServices.Protocols;//lower-level API for LDAP operations
using System.Net;//handling network credentials and authentication.

namespace backend 
{
    class thebackend
    {
        static void Main(string[] args)
        {
            // Example LDAP connection setup
            string ldapServer = "ldap.example.com";
            int ldapPort = 389; // Default LDAP port or use 636 for LDAPS
            string ldapUser = "cn=admin,dc=example,dc=com";
            string ldapPassword = "password";

            try
            {
                // Create a connection to the LDAP server
                LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier(ldapServer, ldapPort);
                NetworkCredential credential = new NetworkCredential(ldapUser, ldapPassword);
                LdapConnection connection = new LdapConnection(identifier, credential);

                // Bind to the server (authenticate)
                connection.Bind();
                Console.WriteLine("Successfully connected and authenticated to the LDAP server.");

                // Perform LDAP operations here...

                // Close the connection
                connection.Dispose();
            }
            catch (LdapException ldapEx)
            {
                Console.WriteLine($"LDAP Error: {ldapEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }
    }
}