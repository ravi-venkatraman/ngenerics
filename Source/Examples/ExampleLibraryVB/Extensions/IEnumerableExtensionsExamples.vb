﻿'  
' Copyright 2009 The NGenerics Team
' (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)
'
' This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
' have received a copy of the license along with the source code.  If not, an online copy
' of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
'

Imports System.Collections.Generic
Imports NGenerics.Extensions
Imports NUnit.Framework

Namespace Extensions
  <TestFixture()> _
  Public Class IEnumerableExtensionsExamples

#Region "ForEach"
    <Test()> _
  Public Sub ForEachExample()
      Dim numbers As IEnumerable(Of Long) = New List(Of Long)(New Long() {1, 3, 4, 7, 10})
      Dim oddNumbers As New List(Of Long)()

      ' For each number in the list, add it to the total.
      numbers.ForEach(Function(x) AddIfOdd(x, oddNumbers))
      Assert.AreEqual(oddNumbers.Count, 3)
    End Sub

    Public Function AddIfOdd(ByVal number As Long, ByVal list As List(Of Long)) As Boolean
      If (number Mod 2 = 1) Then
        list.Add(number)
        Return True
      End If

      Return False
    End Function

#End Region

  End Class
End Namespace