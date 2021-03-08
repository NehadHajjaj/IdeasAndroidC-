using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Helper
{
	
		public interface IProgressInterface
		{
			void Show(string title = "Loading");

			void Hide();
		}
	}

