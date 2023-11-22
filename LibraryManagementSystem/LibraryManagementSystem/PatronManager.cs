using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class PatronManager
    {
        private LibraryManagementSystem.DataAccess.LibraryContext _context;

        public PatronManager(LibraryManagementSystem.DataAccess.LibraryContext context)
        {
            _context = context;
        }


        public void CreateNewPatron(Patron newPatron)
        {
            _context.Patrons.Add(newPatron);
            _context.SaveChanges();
            Console.WriteLine("Patron added successfully!");
        }

        public void DisplayPatrons()
        {
            var patrons = _context.Patrons.ToList();

            if (patrons.Count > 0)
            {
                Console.WriteLine("Patrons in the Library:");
                foreach (var patron in patrons)
                {
                    Console.WriteLine($"ID: {patron.Id}, Name: {patron.Name}, Contact Information: {patron.ContactInformation}");
                    // You can display other patron properties here
                }
            }
            else
            {
                Console.WriteLine("No patrons found in the library.");
            }
        }

        public void UpdatePatron(int patronId)
        {
            var patron = _context.Patrons.Find(patronId);

            if (patron != null)
            {
                Console.Write("Enter the new name for the patron: ");
                string newName = Console.ReadLine();

                Console.Write("Enter the new contact information for the patron: ");
                string newContactInfo = Console.ReadLine();

                patron.Name = newName;
                patron.ContactInformation = newContactInfo;

                _context.SaveChanges();
                Console.WriteLine("Patron updated successfully!");
            }
            else
            {
                Console.WriteLine("Patron not found. Please enter a valid patron ID.");
            }
        }


        public void DeletePatron(int patronId)
        {
            var patron = _context.Patrons.Find(patronId);

            if (patron != null)
            {
                _context.Patrons.Remove(patron);
                _context.SaveChanges();
                Console.WriteLine("Patron deleted successfully!");
            }
            else
            {
                Console.WriteLine("Patron not found. Please enter a valid patron ID.");
            }
        }


        


        public void DisplayPatronById(int patronId)
        {
            var patron = _context.Patrons.Find(patronId);

            if (patron != null)
            {
                Console.WriteLine("Patron details:");
                Console.WriteLine($"Name: {patron.Name}");
                Console.WriteLine($"Contact Information: {patron.ContactInformation}");
               
            }
            else
            {
                Console.WriteLine("Patron not found. Please enter a valid patron ID.");
            }
        }

    }
}
