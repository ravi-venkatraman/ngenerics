/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.UI.DataStructures.General
{
	public partial class ObservableSkipList<TKey, TValue> : INotifyCollectionChanged, INotifyPropertyChanged
	{
		#region Globals


		/// <inheritdoc />
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		private readonly SimpleMonitor monitor;



		/// <inheritdoc />
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

	
		#region Construction


		/// <inheritdoc />
        public ObservableSkipList()
        {
            monitor = new SimpleMonitor();
        }


		/// <inheritdoc />
        public ObservableSkipList(IComparer<TKey> comparer)
            : base(comparer)
        {
            monitor = new SimpleMonitor();
        }

  
		/// <inheritdoc />
		public ObservableSkipList(int maximumLevel, double probability, IComparer<TKey> comparer): base(maximumLevel,probability,comparer)
        {
            monitor = new SimpleMonitor();
        }

        #endregion
		/// <summary>
		/// Raises the <see cref="CollectionChanged"/> event.
		/// </summary>
		/// <param name="e">A <see cref="NotifyCollectionChangedAction"/> that contains the event data.</param>
		[SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
		protected virtual void OnCollectionChanged( NotifyCollectionChangedEventArgs e)
		{
			if (CollectionChanged != null)
			{
				using (BlockReentrancy())
				{
					CollectionChanged(this, e);
				}
			}
		}


		/// <summary>
		/// Called when the specified properties change.
		/// </summary>
		/// <param name="propertyNames">The property names.</param>
		protected virtual void OnPropertyChanged(params string[] propertyNames)
		{
			for (var i = 0; i < propertyNames.Length; i++)
			{
				OnPropertyChanged(new PropertyChangedEventArgs(propertyNames[i]));
			}
		}


		/// <summary>
		/// Raises the <see cref="PropertyChanged"/> event.
		/// </summary>
		/// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
		[SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, e);
			}
		}


        /// <inheritdoc cref="ObservableCollection{T}.BlockReentrancy"/>
		protected IDisposable BlockReentrancy()
		{
			monitor.Enter();
			return monitor;
		}


        /// <inheritdoc cref="ObservableCollection{T}.CheckReentrancy"/>
		protected void CheckReentrancy()
		{
			if ((monitor.Busy && (CollectionChanged != null)) && (CollectionChanged.GetInvocationList().Length > 0))
			{
				throw new InvalidOperationException("re-entrancy not allowed.");
			}
		}

	}
}