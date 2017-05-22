//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;


namespace WebApplicationQABL.Sum
{
   class SumManager : ISumManager
   {
      #region Static Members

      public const string NEGATIVE_NUMBER_MESSAGE = "Unable to support negative numbers";

      #endregion

      #region Interface Members

      public int AddTwoNumbers(int a, int b)
      {
         if (a < 0 || b < 0) {
            throw new Exception(NEGATIVE_NUMBER_MESSAGE);
         }

         //This can also throw excepton. Think about it :)
         return a + b;
      }

      #endregion
   }
}