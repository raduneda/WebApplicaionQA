//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using WebApplicationQATL;


namespace WebApplicationQADL
{
   public class DatabaseManager : IDatabaseManager
   {
      #region Interface Members

      public bool CreateHomeAbout(AboutDto value)
      {
         bool success = true;

         try {
            bool exists = Database.HomeAbout.Any(m => m.Value == value.Value);

            if (!exists) {
               Database.HomeAbout.Add(value);
            }
         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }

      public bool CreateHomeContact(ContactDto value)
      {
         bool success = true;

         try {

            bool exists = Database.HomeContact.Any(m => m.Value == value.Value);

            if (!exists) {
               Database.HomeContact.Add(value);
            }

         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }

      public bool DeleteHomeAbout(int id)
      {
         bool success = true;

         try {
            Database.HomeAbout.RemoveAt(id);
         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }

      public bool DeleteHomeContact(int id)
      {
         bool success = true;

         try {
            Database.HomeContact.RemoveAt(id);
         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }

      public AboutDto ReadHomeAbout(int id)
      {
         AboutDto dto = new AboutDto();

         //Stored procedure or query
         try {
            List<AboutDto> results = Database.HomeAbout;

            dto = results[id];
         } catch (Exception e) {
            Console.WriteLine(e);
         }

         return dto;
      }

      public ContactDto ReadHomeContact(int id)
      {
         //Stored procedure or query

         ContactDto dto = new ContactDto();

         //Stored procedure or query
         try {
            List<ContactDto> results = Database.HomeContact;

            dto = results[id];
         } catch (Exception e) {
            Console.WriteLine(e);
         }

         return dto;
      }

      public bool UpdateHomeAbout(AboutDto contactDto)
      {
         bool success = true;

         try {
            Database.HomeAbout[contactDto.Id] = contactDto;
         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }

      public bool UpdateHomeContact(ContactDto contactDto)
      {
         bool success = true;

         try {
            Database.HomeContact[contactDto.Id] = contactDto;
         } catch (Exception e) {
            Console.WriteLine(e);
            success = false;
         }

         return success;
      }


      #endregion
   }
}