﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Logic.Models;

namespace Logic.ViewModels
{
	public abstract class BaseViewModel
	{
		protected List<Action> RefreshView { get; } = new List<Action>();
		public TimeSheetsModel Model { get; set; }

		protected BaseViewModel(TimeSheetsModel model)
		{
			Model = model;
			Model.PropertyChanged += OnModelPropertyChanged;
		}

		protected virtual void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			foreach (var action in RefreshView)
			{
				action();
			}
		}

		public void Subscribe(Action refreshFunc)
		{
			if (!RefreshView.Contains(refreshFunc))
			{
				RefreshView.Add(refreshFunc);
			}
		}

		public void Unsubscribe(Action refreshFunc)
		{
			RefreshView.Remove(refreshFunc);
		}
	}
}