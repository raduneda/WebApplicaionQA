//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

namespace WebApplicationQABL.Arhitmetic
{
   public interface IArithmeticManager
   {
      #region Methods - Public

      int CalculateFourNumberSum(int a, int b, int c, int d);

      int MultiplyTwoNumbers(int a, int b);

      int Power(int number, int powerFactor);

      #endregion
   }
}