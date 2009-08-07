﻿/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NGenerics.Extensions;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Extensions
{
    [TestFixture]
    public class DoubleExtensionsExamples
    {
        #region IsSimilarTo

        [Test]
        public void IsSimilarToExample()
        {
            var d1 = 5.000000000009d;
            var d2 = 5d;

            // Since the difference between the two values are less / equal than the default precision,
            // the following statement returns true :
            Assert.IsTrue(d1.IsSimilarTo(d2));
        }

        #endregion

        #region IsSimilarWithPrecision

        [Test]
        public void IsSimilarWithPrecisionExample()
        {
            var d1 = 5.1d;
            var d2 = 5d;

            // Since the difference between the two values are less / equal than the supplied precision,
            // the following statement returns true :
            Assert.IsTrue(d1.IsSimilarTo(d2, 0.1));
        }

        #endregion
    }
}
