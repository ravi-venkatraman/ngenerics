/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using NGenerics.Patterns.Visitor;

namespace NGenerics.Tests.Util
{
    class CompletedTrackingVisitor<T> : IVisitor<T>
    {
        #region IVisitor<T> Members

        /// <summary>
        /// Gets a value indicating whether this instance is done performing it's work..
        /// </summary>
        /// <value><c>true</c> if this instance is done; otherwise, <c>false</c>.</value>
        public bool HasCompleted
        {
            get {
                return true;                
            }
        }

        /// <summary>
        /// Visits the specified object.
        /// </summary>
        /// <param name="obj">The object to visit.</param>
        public void Visit(T obj)
        {
            throw new Exception("This visitor has already completed.");
        }

        #endregion
    }
}
