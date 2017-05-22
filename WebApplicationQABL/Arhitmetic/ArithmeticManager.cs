//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;

using WebApplicationQABL.Sum;


namespace WebApplicationQABL.Arhitmetic
{
   public class ArithmeticManager : IArithmeticManager
   {
      #region Members

      private readonly ISumManager _sumManager;

      #endregion

      #region Constructors

      public ArithmeticManager(ISumManager sumManager)
      {
         if (null == sumManager) {
            throw new ArgumentNullException();
         }

         _sumManager = sumManager;
      }

      #endregion

      #region Interface Members

      public int CalculateFourNumberSum(int a, int b, int c, int d)
      {
         if (a < -1 || b < -1 || c < -1 || d < -1) {
            return -1;
         }

         int firstSum = _sumManager.AddTwoNumbers(a, b);
         int secondSum = _sumManager.AddTwoNumbers(c, d);
         int finalResult = _sumManager.AddTwoNumbers(firstSum, secondSum);

         return finalResult;
      }

      public int MultiplyTwoNumbers(int a, int b)
      {
         if (a == 0 || b == 0) {
            return -1;
         }

         int result = 0;

         for (int i = 0; i < b; i++) {
            result = result + _sumManager.AddTwoNumbers(a, 0);
         }

         return result;
      }

      public int Power(int number, int powerFactor)
      {
         if (powerFactor == 0) {
            return 1;
         }

         if (powerFactor == 1) {
            return number;
         }

         int result = 1;

         for (int i = 0; i < powerFactor; i++) {
            result = MultiplyTwoNumbers(number, result);
         }

         return result;
      }

      #endregion
   }
}