using System;
using NewCode1.BST;
using NewCode1.Data;

namespace NewCode1
{
    class Program
    {
        static void Main()
        {
            var tree = CreateBinarySearchTreeAndPopulateWithTestContactsUsingTheirNameAsTheKey();

            var contact = tree.FindByKey("Sigourney H. Holman");
            if (!IsContactFound(contact))
            {
                PrintContactNotFound();
                return;
            }

            PrintContact(contact);
            WaitForReturnToBePressedBeforeExiting();
        }

        static Tree<string, Contact> CreateBinarySearchTreeAndPopulateWithTestContactsUsingTheirNameAsTheKey()
        {
            var tree = new Tree<string, Contact>();
            foreach (var contact in TestData.Contacts)
            {
                try
                {
                    tree.AddNode(contact.Name, contact);
                }
                catch(Exception e)
                {
                    // Note this would typically be logged to a file and potentially stop the adding of additional nodes and return an empty tree.
                    Console.WriteLine(e.Message); 
                }
            }

            return tree;
        }

        static bool IsContactFound(Contact contact)
        {
            // Added default check as i return default in previous methods (generics check).
            return contact != null && contact != default;
        }

        static void PrintContactNotFound()
        {
            Console.WriteLine("Could not find the contact");
        }

        static void PrintContact(Contact contact)
        {
            Console.WriteLine("Id: {0} Name: {1} Company: {2}", contact.Id, contact.Name, contact.Company);
        }

        static void WaitForReturnToBePressedBeforeExiting()
        {
            Console.WriteLine("Press the Enter key to exit");
            Console.ReadLine();
        }
    }
}
